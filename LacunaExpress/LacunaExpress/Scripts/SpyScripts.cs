using LacunaExpanseAPIWrapper;
using LacunaExpanseAPIWrapper.ResponseModels;
using LacunaExpress.AccountManagement;
using LacunaExpress.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LacunaExpanseAPIWrapper.ResponseModels;

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
			}
            if (requests.Count > 0)
            {
                var server = new LacunaExpress.Data.Server();
                server.ThrottledServer(requests);
            }
        }

        public static void TrainSpies(List<LacunaExpanseAPIWrapper.ResponseModels.Spies> spies, AccountModel account, string intelMinID, Building intelMin, Building intelTrain, Building mayhemTrain, Building theftTrain, Building politicalTrain, string planetID, int numToTrain)
        {
            if (intelMin.efficiency == "100")
            {
                List<ThrottledServerRequest> requests = new List<ThrottledServerRequest>();
                int intelCounter = (from counterCount in spies
                                    where counterCount.assignment.Equals("Intel Training")
                                    select counterCount).Count();
                int politicalCounter = (from counterCount in spies
                                        where counterCount.assignment.Equals("Politics Training")
                                        select counterCount).Count();
                int theftCounter = (from counterCount in spies
                                    where counterCount.assignment.Equals("Theft Training")
                                    select counterCount).Count();
                int mayhemCounter = (from counterCount in spies
                                     where counterCount.assignment.Equals("Mayhem Training")
                                     select counterCount).Count();
                int counterEsp = (from counterCount in spies
                                  where counterCount.assignment.Equals("Counter Espionage")
                                  select counterCount).Count();
                int politicalProp = (from counterCount in spies
                                     where counterCount.assignment.Equals("Political Propaganda")
                                     select counterCount).Count();

                var idleSpies = from s in spies
                                where s.assignment.Contains("Idle")
                                select s;

                //350 + $view->{building}{level} * 75
                foreach (var spy in idleSpies)
                {
                    if (Convert.ToInt64(spy.intel) < 350 + (Convert.ToInt64(intelTrain.level) * 75) && intelTrain.efficiency == "100" && intelCounter < numToTrain)
                    {
                        var json = Intelligence.AssignSpy(account.SessionID, intelMinID, spy.id, "Intel Training");
                        requests.Add(new ThrottledServerRequest(account.Server, Intelligence.URL, json));
                        intelCounter++;
                    }
                    else if (Convert.ToInt64(spy.mayhem) < 350 + (Convert.ToInt64(mayhemTrain.level) * 75) && mayhemTrain.efficiency == "100" && mayhemCounter < numToTrain)
                    {
                        var json = Intelligence.AssignSpy(account.SessionID, intelMinID, spy.id, "Mayhem Training");
                        requests.Add(new ThrottledServerRequest(account.Server, Intelligence.URL, json));
                        mayhemCounter++;
                    }
                    else if (Convert.ToInt64(spy.politics) < 350 + (Convert.ToInt64(politicalTrain.level) * 75) && politicalTrain.efficiency == "100" && politicalCounter < numToTrain)
                    {
                        var json = Intelligence.AssignSpy(account.SessionID, intelMinID, spy.id, "Politics Training");
                        requests.Add(new ThrottledServerRequest(account.Server, Intelligence.URL, json));
                        politicalCounter++;
                    }
                    else if (Convert.ToInt64(spy.theft) < 350 + (Convert.ToInt64(theftTrain.level) * 75) && theftTrain.efficiency == "100" && theftCounter < numToTrain)
                    {
                        var json = Intelligence.AssignSpy(account.SessionID, intelMinID, spy.id, "Theft Training");
                        requests.Add(new ThrottledServerRequest(account.Server, Intelligence.URL, json));
                        theftCounter++;
                    }
                    else if (counterEsp < numToTrain)
                    {//Political Propaganda
                        var json = Intelligence.AssignSpy(account.SessionID, intelMinID, spy.id, "Counter Espionage");
                        requests.Add(new ThrottledServerRequest(account.Server, Intelligence.URL, json));
                        counterEsp++;
                    }
                    else if (politicalProp < numToTrain && Convert.ToInt16(spy.mission_count.defensive) < 100)
                    {//Political Propaganda
                        var json = Intelligence.AssignSpy(account.SessionID, intelMinID, spy.id, "Political Propaganda");
                        requests.Add(new ThrottledServerRequest(account.Server, Intelligence.URL, json));
                        politicalProp++;
                    }
                    //var json = Security.ExecutePrisoner(account.SessionID, secMinID, prisoner.id);
                    //requests.Add(new ThrottledServerRequest(account.Server, Security.URL, json));
                }

                if (requests.Count > 0)
                {
                    var server = new LacunaExpress.Data.Server();
                    server.ThrottledServer(requests);
                }
            }
        }

        public async static void MakeSpiesIdle(AccountModel account, string intelMinID, List<LacunaExpanseAPIWrapper.ResponseModels.Spies> spies)
        {
            List<ThrottledServerRequest> requests = new List<ThrottledServerRequest>();
            foreach (var spy in spies)
            {
                if (spy.assignment != "Idle")
                {
                    var json = Intelligence.AssignSpy(account.SessionID, intelMinID, spy.id, "Idle");
                    requests.Add(new ThrottledServerRequest(account.Server, Intelligence.URL, json));
                }
            }
            if (requests.Count > 0)
            {
                var server = new LacunaExpress.Data.Server();
                server.ThrottledServer(requests);
            }
        }

        public async static Task<List<Spies>> FilterSpiesByAssignment(List<Spies> spies, string assignment)
        {
            var filteredSpies = new List<Spies>();
            foreach(var spy in spies)
            {
                if (spy.assignment.Equals(assignment))
                    filteredSpies.Add(spy);
            }
            return filteredSpies;
        }
		public async Task<List<Prisoner>> GetPrisoners(AccountModel account, string SecurityMinstryID, string PlanetID)
		{
			var server = new Data.Server();
			var json = Security.ViewPrisoners(account.SessionID, SecurityMinstryID, "");
			var response = await server.GetHttpResultAsync(account.Server, Security.URL, json);
			if (response != null)
			{
				return response.result.prisoners;
			}
			else
				return new List<Prisoner>();
		}
		public async void ExecutePrisonersOnPlanet(AccountModel account, string SecurityMinstryID, string PlanetID, List<Prisoner> prisonerList)
		{
			List<ThrottledServerRequest> requests = new List<ThrottledServerRequest>();
			foreach (var prisoner in prisonerList)
			{
				var json = Security.ExecutePrisoner(account.SessionID, SecurityMinstryID, prisoner.id);
				requests.Add(new ThrottledServerRequest(account.Server, Security.URL, json));
			}
			var server = new Data.Server();
			server.ThrottledServer(requests);
		}

    }
}
