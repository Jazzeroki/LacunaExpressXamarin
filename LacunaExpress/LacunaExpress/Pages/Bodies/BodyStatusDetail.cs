using LacunaExpanseAPIWrapper;
using LacunaExpanseAPIWrapper.ResponseModels;
using LacunaExpress.AccountManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;

namespace LacunaExpress.Pages.Bodies
{
	public class BodyStatusDetail : ContentPage
	{
        AccountModel account;
        string planetID;
		Response response;
		Label planetName = new Label();
		Label planetLocation = new Label();
		Label food = new Label();
		Label water = new Label();
		Label ore = new Label();
		Label energy = new Label();
		Label waste = new Label();
		Label happiness = new Label();
		Label bleeders = new Label();
		Label fissures = new Label();
		Label enemyIncoming = new Label();
		Label damagedBuildings = new Label();

		Button destroyBleeders = new Button { IsVisible = false, Text = "Destroy Bleeders" };
		Button fillFissure = new Button { IsVisible = false, Text = "Fill Fissure/s" };
		Button repairBuildings = new Button { IsVisible = false, Text = "Repair Building/s" };

		public BodyStatusDetail(Response response, string pName)
		{
			this.response = response;
			Content = new StackLayout
			{
				Children = {
					planetName,
					planetLocation,
					enemyIncoming,
					damagedBuildings,	
					fissures,					
					bleeders,					
					food,
					water,
					ore,
					energy,
					happiness,
					waste,
					repairBuildings,
					destroyBleeders,
					fillFissure
				}
			};

            repairBuildings.Clicked += async (sender, e) =>
            {
                var damagedIDs = LacunaExpress.Scripts.BuildingToolsScripts.GetDamagedBuildingIDs(response.result.buildings);
                
                if(account != null)
                {
					//foreach(var p in account.AllBodies)
					//{
					//	if (p.Value.Equals(planetName.Text))
					//	{
					//		planetID = p.Key;
					//		break;
					//	}
					//}
					
                    //planetID = account.AllBodies.Where(x => x.Value.Equals(planetName)).First().Key;
                    var json = LacunaExpanseAPIWrapper.Body.RepairList(1, account.SessionID, planetID, damagedIDs);
                    var server = new LacunaExpress.Data.Server();
                    var r = await server.GetHttpResultAsync(account.Server, LacunaExpanseAPIWrapper.Body.url, json);
                    var xyz = r;
                }
               
            };

            this.Appearing += async (sender, e) => 
            {
                AccountManager acntMgr = new AccountManager();
                account = await acntMgr.GetActiveAccountAsync();
                planetName.Text = pName;
				planetID = (from i in account.AllBodies
							where i.Value.Equals(planetName.Text)
							select i.Key).First();
                //planetLocation.Text = response.result.status.body.name;
                //planetID = response.result.status.body.id
                food.Text = "Food " + response.result.status.body.food_stored + "/" + response.result.status.body.food_hour;
                water.Text = "Water " + response.result.status.body.water_stored + "/" + response.result.status.body.water_hour;
                ore.Text = "Ore " + response.result.status.body.ore_stored + "/" + response.result.status.body.ore_hour;
                energy.Text = "Energy " + response.result.status.body.energy_stored + "/" + response.result.status.body.energy_hour;
                happiness.Text = "Happiness " + response.result.status.body.happiness + "/" + response.result.status.body.happiness_hour;
                waste.Text = "Waste " + response.result.status.body.waste_stored + "/" + response.result.status.body.waste_hour;

                enemyIncoming.Text = "Enemy Incoming: " + response.result.status.body.incoming_enemy_ships;

                int bleederCount = 0;
                int fissureCount = 0;
                int damagedBuildingsCount = 0;
                foreach (var b in response.result.buildings)
                {
                    if (Convert.ToInt64(b.Value.efficiency) < 100)
                    {
                        damagedBuildingsCount++;
                        repairBuildings.IsVisible = true;
                    }
                    if (b.Value.name.Contains("eeder"))
                        bleederCount++;
                    if (b.Value.name.Contains("issure"))
                        fissureCount++;
                }
                damagedBuildings.Text = "Damaged Buildings: " + damagedBuildingsCount;
                fissures.Text = "Fissures: " + fissureCount;
                bleeders.Text = "Bleeders: " + bleederCount;
            };

			

			

		}
	}
}
