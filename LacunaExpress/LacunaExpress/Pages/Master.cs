using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using LacunaExpress.Pages.Mail;
using LacunaExpress.Pages.AccountPages;
using LacunaExpress.AccountManagement;
using LacunaExpress.Data;
using LacunaExpanseAPIWrapper;

namespace LacunaExpress.Pages
{
	public class Master : MasterDetailPage
	{
		AccountModel activeAccount;
		Response.Messages messages;
		NavigationPage nav;

		static List<string> menuItems = new List<string>
		{
			"Planets", "Stations", "Mail"
		};

		ListView menu = new ListView { ItemsSource = menuItems };

		public Master()
		{
			nav = new NavigationPage(new Splash());
			nav.Title = "Lacuna Express";
			this.Detail = nav;
			this.Master = new ContentPage
			{
				Title = "Lacuna Express",
				Content = new StackLayout
				{
					Children = {
						menu
					}
				}
			};



			nav.BackgroundColor = Color.Black;
			nav.ToolbarItems.Add(new ToolbarItem
			{
				//Text = "Search",
				Icon = "ham.png",
				Order = ToolbarItemOrder.Primary,
				Command = new Command(() => this.IsPresented = true)
			});

			menu.ItemSelected += async (sender, e) =>
			{
				this.IsPresented = false;
				switch (e.SelectedItem.ToString())
				{
					case "Mail":
						LoadMessages();
						await nav.Navigation.PushAsync(new MessageList());
						break;
				}
			};
			GetActiveAccount();
		}

		async void  GetActiveAccount()
		{
			var accm = new AccountManagement.AccountManager();
			 activeAccount = await accm.GetActiveAccountAsync();
			 if (activeAccount == null)
			{
				await Navigation.PushModalAsync(new Login());
				GetActiveAccount();
			}
		}

		async void LoadMessages()
		{
			var s = new Server();
			var json = Inbox.ViewInbox(activeAccount.SessionID);
			var response = await s.GetHttpResultAsync("https://us1.lacunaexpanse.com", Inbox.url, json);
			s = null;
			if (response.result == null)
			{

			}
			else
			{
				var messageList = response.result.messages;
			}

			//
		}
	}
}
