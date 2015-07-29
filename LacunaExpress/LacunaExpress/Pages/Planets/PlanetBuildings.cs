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
using LacunaExpress.Data;

namespace LacunaExpress.Pages.Planets
{
	public class PlanetBuildings : ContentPage
	{
		AccountModel account;
		ObservableCollection<BuildingData> buildingList = new ObservableCollection<BuildingData>();
		ListView buildingListView = new ListView { SeparatorColor = Color.Red, HasUnevenRows = true };
		
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
							b.url = "https://raw.githubusercontent.com/plainblack/Lacuna-Assets/master/planet_side/100/" + bd.Value.image + ".png";
							b.BuildingURL = bd.Value.url;
							buildingList.Add(b);
						}

					}
		}
	}

	public class BuildingViewCell : ViewCell
	{
		Image upgrade = new Image
		{
			Source = ImageSource.FromResource("LacunaExpress.Images.Upgrade.png"),
			HorizontalOptions = LayoutOptions.CenterAndExpand
		};
		Image downgrade = new Image
		{
			Source = ImageSource.FromResource("LacunaExpress.Images.Downgrade.png"),
			HorizontalOptions = LayoutOptions.CenterAndExpand
		};
		Image repair = new Image
		{
			Source = ImageSource.FromResource("LacunaExpress.Images.Repair.png"),
			HorizontalOptions = LayoutOptions.CenterAndExpand
		};
		Label planetName = new Label { TextColor = Color.White };
		Label buildingLevel = new Label { TextColor = Color.White };
		Label efficiency = new Label { TextColor = Color.White };
		Label buildingID = new Label();
		Label buildingUrl = new Label ();
		Label buildingimg = new Label();
		Button up = new Button
		{
			Text = "Up"
		};
		Image buildingImage = new Image { 
			VerticalOptions = LayoutOptions.FillAndExpand,
			Aspect = Aspect.AspectFit, 
			MinimumHeightRequest = 50
		};
		StackLayout layout = new StackLayout { Orientation = StackOrientation.Horizontal };

		public BuildingViewCell()
		{
			layout.Children.Add(buildingImage);
			layout.Children.Add(planetName);
			layout.Children.Add(buildingLevel);
			layout.Children.Add(efficiency);
			layout.Children.Add(buildingID);
			layout.Children.Add(buildingimg);
			layout.Children.Add(repair);
			layout.Children.Add(upgrade);
			layout.Children.Add(downgrade);

			layout.Children.Add(buildingUrl);

			buildingID.SetBinding(Label.TextProperty, "BuildingID");
			
			planetName.SetBinding(Label.TextProperty, "BuildingName");
			buildingLevel.SetBinding(Label.TextProperty, "BuildingLevel");
			efficiency.SetBinding(Label.TextProperty, "Efficiency");
			buildingimg.SetBinding(Label.TextProperty, "ImageName");
			buildingImage.SetBinding(Image.SourceProperty, new Binding("url"));
			buildingUrl.SetBinding(Label.TextProperty, "BuildingURL");
			if (Convert.ToInt16(buildingLevel.Text) < 30)
			{
				up.IsVisible = false;
				up.IsEnabled = false;
			}
			//var uri = new Uri(("https://github.com/plainblack/Lacuna-Assets/tree/master/planet_side/50/" + buildingimg.Text + ".png"));
			//buildingImage.Source = ImageSource.FromUri(uri);
			buildingimg.IsVisible = false;
			buildingUrl.IsVisible = false;

			View = layout;
			upgrade.GestureRecognizers.Add((new TapGestureRecognizer
			{
				Command = new Command(async o =>
				{
					AccountManager acntMgr = new AccountManager();
					var account = await acntMgr.GetActiveAccountAsync();
					var json = Buildings.Upgrade(account.SessionID, buildingID.Text);
					var server = new Server();
					var response = await server.GetHttpResultAsync(account.Server, buildingUrl.Text, json);
				})
			}));

			repair.GestureRecognizers.Add((new TapGestureRecognizer
			{
				Command = new Command(async o =>
				{
					AccountManager acntMgr = new AccountManager();
					var account = await acntMgr.GetActiveAccountAsync();
					var json = Buildings.Repair(account.SessionID, buildingID.Text);
					var server = new Server();
					var response = await server.GetHttpResultAsync(account.Server, buildingUrl.Text, json);
				})
			}));

			downgrade.GestureRecognizers.Add((new TapGestureRecognizer
			{
				Command = new Command(async o =>
				{
					AccountManager acntMgr = new AccountManager();
					var account = await acntMgr.GetActiveAccountAsync();
					var json = Buildings.Downgrade(account.SessionID, buildingID.Text);
					var server = new Server();
					var response = await server.GetHttpResultAsync(account.Server, buildingUrl.Text, json);
				})
			}));
			up.Clicked += async (sender, e) =>
			{
				AccountManager acntMgr = new AccountManager();
				var account = await acntMgr.GetActiveAccountAsync();
				var json = Buildings.Upgrade(account.SessionID, buildingID.Text);
				var server = new Server();
				var response = server.GetHttpResultAsync(account.Server, buildingUrl.Text, buildingID.Text);

			};
		}
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
