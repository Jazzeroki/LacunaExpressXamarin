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
using LacunaExpanseAPIWrapper.ResponseModels;
using LacunaExpress.ViewCells.Models;

using LacunaExpress.Styles;

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

		Button notifyAllianceOfStations = new Button { Text = "Notify Allies of Troubled Stations", TextColor = Color.Red, BorderWidth = 2, BorderColor = Color.White, BackgroundColor = Color.Blue, FontAttributes = FontAttributes.Bold };
        List<string> warningStations = new List<string>();
		public BodyStatus(AccountModel account, Boolean typeStation)
		{
            #region controls Declaration

            #endregion
            //Adding something to the collection otherwise the listview doesn't like to display
            var b = new BodyStatusModel();
			b.Name = "loading bodies";
			bodyList.Add(b);

			bodies.ItemsSource = bodyList;
			bodies.ItemTemplate = new DataTemplate(typeof(ViewCells.PlanetStatusViewCell));
			bodies.BackgroundColor = Color.FromRgb (0, 0, 128);


            Content = new StackLayout
            {
				BackgroundColor = Color.FromRgb (0, 0, 128),
				Children = {
					bodies, 
                    notifyAllianceOfStations
				}
			};
			this.Appearing += async (sender, e) =>
			{
				await LoadPage(typeStation);
				
			};

            notifyAllianceOfStations.IsVisible = false;
            notifyAllianceOfStations.Clicked += async (sender, e) =>{
                var bodyString = "The following stations have warning indicators: ";
                foreach (var station in warningStations)
                    bodyString += station + ", \n";
                var json = Inbox.SendMessage(1, account.SessionID, "@ally", "Stations in trouble", bodyString);
                var server = new Data.Server();
                var response = await server.GetHttpResultStringAsyncAsString(account.Server, Inbox.url, json);
                var s = response;
            };
			bodies.ItemTapped += async (sender, e) =>
			{
				await Navigation.PushModalAsync(new BodyStatusDetail((bodies.SelectedItem as BodyStatusModel).response,
					(bodies.SelectedItem as BodyStatusModel).Name));
				bodies.SelectedItem = null;
			};
		}

		
		async Task<bool> LoadPage(Boolean typeStation){
			AccountManager accountMan = new AccountManager();
			account = await accountMan.GetActiveAccountAsync();
            var originalAccount = account;
            if (typeStation)
			{
				bodyList.Clear();
				foreach(var s in account.Stations.Keys)
				{
					var json = LacunaExpanseAPIWrapper.Body.GetBuildings(1, account.SessionID, s);
					var server = new LacunaExpress.Data.Server();
					var response = await server.GetHttpResultAsync(account.Server, LacunaExpanseAPIWrapper.Body.url, json);
					if (response.result != null)
					{
						BodyStatusModel bdy = new BodyStatusModel();
						bdy.response = response;
						bdy.Name     = response.result.status.body.name;
						bdy.Star     = response.result.status.body.star_name;
						bdy.Zone     = response.result.status.body.zone;
						bdy.X        = response.result.status.body.x;
						bdy.Y        = response.result.status.body.y;
                        if (!Scripts.StatusCheckers.StationOk(response))
                        {
                            bdy.Status = "Warning";
                            notifyAllianceOfStations.IsVisible = true;
                            warningStations.Add(bdy.Name +"{ Planet "+bdy.Name+" "+ response.result.status.body.id+" }");                           
                        }
						bodyList.Add(bdy);
                        if (response.result.buildings != null)
                        {
                            foreach(var b in response.result.buildings)
                            {
                                if (account.Parliaments == null)
                                    account.Parliaments = new List<BuildingCache>();
                                if(b.Value.url.Contains(Parliament.URL))
                                    account.Parliaments.Add(new BuildingCache { planetID = b.Value.name, buildingID = b.Key, level = Convert.ToInt16(b.Value.level) });
                            }
                            //var parliament = (from p in response.result.buildings
                            //                  where p.Value.url.Contains(Parliament.URL)
                            //                  select new { id = p.Key, level = p.Value.level, }).First();

                            //account.Parliaments.Add(new BuildingCache { planetID = bdy.Name, buildingID = parliament.id, level = Convert.ToInt16(parliament.level) });

                        }

                    }

				}
                if(account.Parliaments.Count >0)
                    accountMan.ModifyAccountAsync(account, originalAccount);
            }
			else
			{
				bodyList.Clear();
				foreach (var c in account.Colonies.Keys)
				{
					var json = LacunaExpanseAPIWrapper.Body.GetBuildings(1, account.SessionID, c);
					var s = new LacunaExpress.Data.Server();
					var response = await s.GetHttpResultAsync(account.Server, LacunaExpanseAPIWrapper.Body.url, json);
					if (response.result != null)
					{
						BodyStatusModel bdy = new BodyStatusModel();
						bdy.response = response;
						bdy.Name = response.result.status.body.name;
						bdy.Star = response.result.status.body.star_name;
						bdy.Zone = response.result.status.body.zone;
						bdy.X = response.result.status.body.x;
						bdy.Y = response.result.status.body.y;
						if (!Scripts.StatusCheckers.PlanetOk(response))
							bdy.Status = "Warning";
						bodyList.Add(bdy);
					}

					//BodyStatus bodyresult = response.result.Bodies;
					//(BodyStatus)bodyresult = 
				}
			}
			return true;
		}			
	}
	
}
