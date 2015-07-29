using LacunaExpanseAPIWrapper;
using LacunaExpanseAPIWrapper.ResponseModels;
using LacunaExpress.AccountManagement;
using LacunaExpress.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpress.Scripts
{
	public class SpyScripts
	{
		public static async void SpyTotals() { }
		public static List<Spies> GetIdleSpiesFromList(List<Spies> spies) 
		{
			var idleSpies = new List<Spies>();
			foreach (var spy in spies)
			{
				if(spy.assignment.Equals("Idle"))
				{
					idleSpies.Add(spy);
				}
			}
			return idleSpies;
			
		}
		public static async void BatchAssignSpies(AccountModel account, List<Spies> spies, string assignment, string intelMinID) 
		{
			List<ThrottledServerRequest> requests = new List<ThrottledServerRequest>();
			foreach (var spy in spies)
			{
				var json = Intelligence.AssignSpy(account.SessionID, intelMinID, spy.id, assignment);
				requests.Add(new ThrottledServerRequest(account.Server, Intelligence.URL, json));
				if (requests.Count > 0)
				{
					var server = new LacunaExpress.Data.Server();
					server.ThrottledServer(requests);
				}
			}
		}
	}
}
