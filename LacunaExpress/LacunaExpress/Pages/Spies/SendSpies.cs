using LacunaExpress.AccountManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace LacunaExpress.Pages.Spies
{
	public class SendSpies : ContentPage
	{
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
		private string spaceportID;
		public SendSpies(AccountModel account, string intelMinID, string bodyID)
		{
			Content = new StackLayout
			{
				Children = {
					toBodyID, getShips, sendSpies
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
			};
			getShips.Clicked += async (sender, e) =>
			{
				var json = LacunaExpanseAPIWrapper.Spaceport.PrepareSendSpies(account.SessionID, bodyID, toBodyID.Text);
				var server = new Data.Server();
				var response = await server.GetHttpResultAsync(account.Server, LacunaExpanseAPIWrapper.Spaceport.URL, json);
				if(response.result != null)
				{

				}
			};
			sendSpies.Clicked += async (sender, e) =>
			{
				//var json = LacunaExpanseAPIWrapper.Spaceport.SendSpies(account.SessionID, bodyID, toBodyID.Text, shipID, spyIDs);
			};
		}
	}
}
