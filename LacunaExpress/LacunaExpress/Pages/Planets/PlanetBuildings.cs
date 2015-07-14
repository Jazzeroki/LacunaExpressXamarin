using LacunaExpress.AccountManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;

using System.Collections.ObjectModel;
using LacunaExpanseAPIWrapper;
using LacunaExpress.DataModels;

namespace LacunaExpress.Pages.Planets
{
	public class PlanetBuildings : ContentPage
	{
		AccountModel account;
		ObservableCollection<BuildingData> buildingList = new ObservableCollection<BuildingData>();
		ListView buildingListView = new ListView { SeparatorColor = Color.Red };
		
		public PlanetBuildings(AccountModel account, string planetName)
		{
			this.account = account;
			Content = new StackLayout
			{
				Children = {
					buildingListView
				}
			};
			this.Appearing += (sender, e) =>
			{
				var planetID = (from b in account.Colonies
							   where b.Value.Equals(planetName)
							   select b.Key).First();
				LoadBuildingsAsync(planetID);
			};
			buildingList.Add(new BuildingData());
			buildingListView.ItemsSource = buildingList;
			buildingListView.ItemTemplate = new DataTemplate(typeof(BuildingViewCell));
			buildingListView.ItemTapped += async (sender, e) =>
			{
				buildingListView.SelectedItem = null;
			};
		}

		async void LoadBuildingsAsync(string bodyID)
		{
			var json = Body.GetBuildings(1, account.SessionID, bodyID);
					var s = new LacunaExpress.Data.Server();
					var response = await s.GetHttpResultAsync(account.Server, Body.url, json);
					if (response.result != null)
					{
						buildingList.Clear();
						foreach(var bd in response.result.buildings.OrderBy( x => x.Value.name))
						{
							var b = new BuildingData();
							b.BuildingName = bd.Value.name;
							b.BuildingLevel = bd.Value.level;
							b.Efficiency = bd.Value.efficiency;
							b.BuildingID = bd.Key;
							b.ImageName = bd.Value.image;
							b.url = bd.Value.url;
							buildingList.Add(b);
						}

					}
		}
	}

	public class BuildingViewCell : ViewCell
	{
		Label planetName = new Label { TextColor = Color.White };
		Label buildingLevel = new Label { TextColor = Color.White };
		Label efficiency = new Label { TextColor = Color.White };
		StackLayout layout = new StackLayout { Orientation = StackOrientation.Horizontal };

		public BuildingViewCell()
		{
			layout.Children.Add(planetName);
			layout.Children.Add(buildingLevel);
			layout.Children.Add(efficiency);
			planetName.SetBinding(Label.TextProperty, "BuildingName");
			buildingLevel.SetBinding(Label.TextProperty, "BuildingLevel");
			efficiency.SetBinding(Label.TextProperty, "Efficiency");

			View = layout;
		}
	}

	
}
