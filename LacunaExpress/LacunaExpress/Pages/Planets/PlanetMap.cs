using LacunaExpanseAPIWrapper;
using LacunaExpress.AccountManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;

namespace LacunaExpress.Pages.Planets
{
	public class PlanetMap : ContentPage
	{
		Grid grid = new Grid
		{
			VerticalOptions = LayoutOptions.FillAndExpand,
			RowDefinitions = 
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                },
			ColumnDefinitions = 
                {
                    new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
                }
		};

		string planetID;
		Label planetlbl = new Label();
		Label planetBuildingName = new Label();
		Label planetBuildingLevel = new Label();
		StackLayout OuterBuilding = new StackLayout { Orientation = StackOrientation.Horizontal };
		StackLayout InnerBuilding = new StackLayout { Orientation = StackOrientation.Vertical };
		List<BuildingArrangementModel> BuildingArrangements = new List<BuildingArrangementModel>();
		BuildingArrangementModel selectedBuilding;

		Image selectedBuildingImage = new Image();
		Label selectedBuildingName = new Label();

		public PlanetMap(AccountModel account, string planetName)
		{
			planetlbl.Text = planetName;
			ScrollView scrollMap = new ScrollView
			{
				HorizontalOptions = LayoutOptions.Fill,
				Orientation = ScrollOrientation.Horizontal,

				Content = new StackLayout
				{
					Orientation = StackOrientation.Horizontal,
					Children = {
 					grid
				}
				}
			};

			Content = new StackLayout
			{
				Children = {
					planetlbl,
					scrollMap
				}

			};

			this.Appearing += (sender, e) =>
			{
				planetID = (from b in account.Colonies
								where b.Value.Equals(planetName)
								select b.Key).First();
				LoadBuildingsAsync(account, planetID);
			};
		}

		async void LoadBuildingsAsync(AccountModel account, string bodyID)
		{
			var json = Body.GetBuildings(1, account.SessionID, bodyID);
			var s = new LacunaExpress.Data.Server();
			var response = await s.GetHttpResultAsync(account.Server, Body.url, json);
			if (response.result != null)
			{
				
				foreach (var bd in response.result.buildings.OrderBy(x => x.Value.name))
				{
					var imageUri = new Uri(("https://raw.githubusercontent.com/plainblack/Lacuna-Assets/master/planet_side/100/"+bd.Value.image+".png"));
					var x = Convert.ToInt16(bd.Value.x) + 5;
					var y = (Convert.ToInt16(bd.Value.y) + -6) * -1;
					var img = new Image();
					img.Source = imageUri;
					grid.Children.Add(img, x, y);
				}

			}
		}

	}

	public class BuildingArrangementModel
	{
		public string BuildingID { get; set; }
		public string BuildingName { get; set; }
		public string BuildingLevel { get; set; }
		public string BuildingUrl { get; set; }
		public string X { get; set; }
		public string Y { get; set; }
		public int GridLeft { get; set; }
		public int GridTop { get; set; }
	}
	/*
	 * .GestureRecognizers.Add((new TapGestureRecognizer
			{
				Command = new Command(o =>
				{
					Device.OpenUri(new Uri("http://www.mindfiretechnology.com"));
				})
			}));
	 */
}
