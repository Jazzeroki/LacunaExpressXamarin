using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LacunaExpanseAPIWrapper;

namespace LacunaExpress.AccountManagement
{
	public class AccountModel
	{
		public AccountModel() { }
		public AccountModel(string empireName, string password, string server, string sessionID, bool? SetAsActiveAccount)
		{
			EmpireName = empireName;
			Password = password;
			Server = server;
			SessionID = sessionID;
		}
		public string EmpireName { get; set; }
		public string Password { get; set; }
		public string SessionID { get; set; }
		public string Server { get; set; }
		public bool ActiveAccount { get; set; }
		public DateTime CaptchaLastRenewed { get; set; }
		public DateTime SessionRenewed { get; set; }
		public Dictionary<string, string> Colonies { get; set; }
		public Dictionary<string, string> Stations { get; set; }
		public Dictionary<string, string> AllBodies { get; set; }
	}

}
