using LacunaExpanseAPIWrapper;
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

		public BodyStatusDetail(Response response)
		{
			this.response = response;
			Content = new StackLayout
			{
				Children = {
					planetName,
					planetLocation,
					enemyIncoming,
					damagedBuildings,
					repairBuildings,
					fissures,
					fillFissure,
					bleeders,
					destroyBleeders,
					food,
					water,
					ore,
					energy,
					happiness,
					waste
				}
			};

			planetName.Text = response.result.status.body.name;
			planetLocation.Text = response.result.status.body.name;
			food.Text = "Food "+response.result.status.body.food_stored +"/" +response.result.status.body.food_hour;
			water.Text = "Water " + response.result.status.body.water_stored + "/" + response.result.status.body.water_hour;
			ore.Text = "Ore " + response.result.status.body.ore_stored + "/" + response.result.status.body.ore_hour;
			energy.Text = "Energy " + response.result.status.body.energy_stored + "/" + response.result.status.body.energy_hour;
			happiness.Text = "Happiness " + response.result.status.body.happiness + "/" + response.result.status.body.happiness_hour;
			waste.Text = "Waste " + response.result.status.body.waste_stored + "/" + response.result.status.body.waste_hour;

			enemyIncoming.Text = "Enemy Incoming: "+ response.result.status.body.incoming_enemy_ships;

			int bleederCount = 0;
			int fissureCount = 0;
			int damagedBuildingsCount = 0;
			foreach (var b in response.result.buildings)
			{
				if (Convert.ToInt64(b.Value.efficiency) < 100)
					damagedBuildingsCount ++;
				if (b.Value.name.Contains("eeder"))
					bleederCount++;
				if (b.Value.name.Contains("issure"))
					fissureCount++;
			}

			damagedBuildings.Text = "Damaged Buildings: " + damagedBuildingsCount;
			fissures.Text = "Fissures: " + fissureCount;
			bleeders.Text = "Bleeders: " + bleederCount;

			

		}
	}
}
