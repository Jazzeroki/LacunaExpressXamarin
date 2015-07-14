using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

using LacunaExpanseAPIWrapper;

using LacunaExpress.AccountManagement;
using LacunaExpress.Data;
using LacunaExpress.Pages.AccountPages;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace LacunaExpress.Pages.Bodies
{
	public class BodyStatus : ContentPage
	{
		AccountModel account = null;
		ObservableCollection<BodyStatusModel> bodyList = new ObservableCollection<BodyStatusModel>();

		ListView bodies = new ListView { 
			HasUnevenRows = true,
 			SeparatorColor = Color.Red
		};
		public BodyStatus(AccountModel account, Boolean typeStation)
		{
			//Adding something to the collection otherwise the listview doesn't like to display
			var b = new BodyStatusModel();
			b.Name = "loading bodies";
			bodyList.Add(b);

			bodies.ItemsSource = bodyList;
			bodies.ItemTemplate = new DataTemplate(typeof(MenuItem));
			

			Content = new StackLayout
			{
				Children = {
					bodies
				}
			};
			this.Appearing += async (sender, e) =>
			{
				await LoadPage(typeStation);
				
			};

			bodies.ItemTapped += async (sender, e) =>
			{
				await Navigation.PushModalAsync(new BodyStatusDetail((bodies.SelectedItem as BodyStatusModel).response));
				bodies.SelectedItem = null;
			};
		}
		class MenuItem : ViewCell
		{
			StackLayout OuterVertical = new StackLayout { Orientation = StackOrientation.Vertical };
			StackLayout InnerHorizontal = new StackLayout { Orientation = StackOrientation.Horizontal};


			Label Name = new Label { TextColor = Color.White };
			Label Warning = new Label { TextColor = Color.Red };
			Label Star = new Label { TextColor = Color.White };
			Label X = new Label { TextColor = Color.White };
			Label Y = new Label { TextColor = Color.White };
			Label Zone = new Label { TextColor = Color.White };

			public MenuItem()
			{
				Name.SetBinding(Label.TextProperty, "Name");
				Warning.SetBinding(Label.TextProperty, "Status");
				Star.SetBinding(Label.TextProperty, "Star");
				X.SetBinding(Label.TextProperty, "X");
				Y.SetBinding(Label.TextProperty, "Y");
				Zone.SetBinding(Label.TextProperty, "Zone");
				OuterVertical.Children.Add(Name);
				OuterVertical.Children.Add(InnerHorizontal);
				InnerHorizontal.Children.Add(Star);
				InnerHorizontal.Children.Add(X);
				InnerHorizontal.Children.Add(Y);
				InnerHorizontal.Children.Add(Zone);
				View = OuterVertical;
			}
		}
		
		async Task<bool> LoadPage(Boolean typeStation){
			AccountManager accountMan = new AccountManager();
			account = await accountMan.GetActiveAccountAsync();

			if (typeStation)
			{

			}
			else
			{
				bodyList.Clear();
				foreach (var c in account.Colonies.Keys)
				{
					var json = Body.GetBuildings(1, account.SessionID, c);
					var s = new LacunaExpress.Data.Server();
					var response = await s.GetHttpResultAsync(account.Server, Body.url, json);
					if (response.result != null)
					{
						BodyStatusModel bdy = new BodyStatusModel();
						bdy.response = response;
						bdy.Name = response.result.status.body.name;
						bdy.Star = response.result.status.body.star_name;
						bdy.Zone = response.result.status.body.zone;
						bdy.X = response.result.status.body.x;
						bdy.Y = response.result.status.body.y;
						if (!planetOk(response))
							bdy.Status = "Warning";
						bodyList.Add(bdy);
					}

					//BodyStatus bodyresult = response.result.Bodies;
					//(BodyStatus)bodyresult = 
				}
			}
			return true;
		}

		Boolean planetOk(Response r)
		{
			if(Convert.ToDouble(r.result.status.body.num_incoming_enemy) > 0)
				return false;
			if (Convert.ToDouble(r.result.status.body.plots_available) < 0)
				return false;
			if (Convert.ToDouble(r.result.status.body.water_hour) < 0)
				return false;
			if (Convert.ToDouble(r.result.status.body.ore_hour) < 0)
				return false;
			if (Convert.ToDouble(r.result.status.body.energy_hour) < 0)
				return false;
			if (Convert.ToDouble(r.result.status.body.food_hour) < 0)
				return false;
			if (Convert.ToDouble(r.result.status.body.happiness_hour) < 0)
				return false;
			if (Convert.ToDouble(r.result.status.body.happiness_hour) < Convert.ToDouble(r.result.status.body.waste_hour))
				return false;
			if (Convert.ToDouble(r.result.status.body.waste_stored) == 0)
				return false;
			foreach(var p in r.result.buildings)
			{
				if (Convert.ToDouble(p.Value.efficiency) < 100)
					return false;
				if (p.Value.name.Contains("leeder"))
					return false;
				if (p.Value.name.Contains("issure"))
					return false;
			}
			//if(r.result.buildings.Values.)
			//bleeder check
			//damaged buildings check

			return true;
		}
		public class BodyStatusModel
		{
			public string Status { get; set; }
			public string Name { get; set; }  
			public string Star{ get; set; } 
			public string X{ get; set; } 
			public string Y{ get; set; } 
			public string Zone{ get; set; }
			public Response response { get; set; }
		}
	}
	
}
