using LacunaExpress.AccountManagement;
using LacunaExpress.ViewCells.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using LacunaExpress.ViewCells;

namespace LacunaExpress.Pages.Spies
{
	public class SendSpies : ContentPage
	{
		ObservableCollection<SpyViewCellModel> SpyList = new ObservableCollection<SpyViewCellModel>();
		ObservableCollection<ShipsForSpiesModel> ShipSelectionList = new ObservableCollection<ShipsForSpiesModel>();
		Entry toBodyID = new Entry
		{
			Placeholder = "Enter to body ID"
		};
		Button getShips = new Button
		{
			Text = "Get Available Ships"
		};
		Button sendSpies = new Button
		{
			Text = "Send Spies"
		};
		ListView spies = new ListView
		{
			HasUnevenRows = true,
		};
		ListView shipSelector = new ListView
		{

		};
		private string spaceportID;
		public SendSpies(AccountModel account, string intelMinID, string bodyID)
		{
			spies.ItemsSource = SpyList;
			spies.ItemTemplate = new DataTemplate(typeof(SpySelectionViewCell));

			shipSelector.ItemsSource = ShipSelectionList;
			shipSelector.ItemTemplate = new DataTemplate(typeof(ShipsForSpiesViewCell));

			Content = new StackLayout
			{
				Children = {
					toBodyID, getShips, sendSpies, spies
				}
			};

			this.Appearing += async (sender, e) =>
			{
				var json = LacunaExpanseAPIWrapper.Body.GetBuildings(1, account.SessionID, bodyID);
				var server = new LacunaExpress.Data.Server();
				var response = await server.GetHttpResultAsync(account.Server, LacunaExpanseAPIWrapper.Body.url, json);
				if (response.result != null)
				{
					spaceportID = (from s in response.result.buildings
								   where s.Value.url.Contains("paceport") && Convert.ToInt64(s.Value.efficiency) == 100
								   select s.Key).First();								  
				};
				json = LacunaExpanseAPIWrapper.Intelligence.ViewAllSpies(account.SessionID, intelMinID);
				response = await server.GetHttpResultAsync(account.Server, LacunaExpanseAPIWrapper.Intelligence.URL, json);
				if(response.result != null)
				{
					foreach(var s in response.result.spies)
					{
						var spy = new SpyViewCellModel
						{
							SpyName = s.name,
							SpyLevel = s.level,
							SpyID = s.id,
							Intel = s.intel,
							Mayhem = s.mayhem,
							Political = s.politics,
							Theft = s.theft,
						};
						SpyList.Add(spy);
					}
				}
				
			};
			getShips.Clicked += async (sender, e) =>
			{
				var json = LacunaExpanseAPIWrapper.Spaceport.PrepareSendSpies(account.SessionID, bodyID, toBodyID.Text);
				var server = new Data.Server();
				var response = await server.GetHttpResultAsync(account.Server, LacunaExpanseAPIWrapper.Spaceport.URL, json);
				if(response.result != null)
				{
					foreach (var s in response.result.spies)
					{
						var spy = new SpyViewCellModel
						{
							SpyName = s.name,
							SpyLevel = s.level,
							SpyID = s.id,
							Intel = s.intel,
							Mayhem = s.mayhem,
							Political = s.politics,
							Theft = s.theft,
						};
						SpyList.Add(spy);
					}
					//var ships = from s in response.result.ships
					//			select s.type.
				}
			
			};
			sendSpies.Clicked += async (sender, e) =>
			{
				//var json = LacunaExpanseAPIWrapper.Spaceport.SendSpies(account.SessionID, bodyID, toBodyID.Text, shipID, spyIDs);
			};
		}
	}
}
