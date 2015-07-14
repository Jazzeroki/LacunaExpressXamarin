using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

using LacunaExpanseAPIWrapper;
using LacunaExpress.Data;
using LacunaExpress.Pages.Mail;
using LacunaExpress.AccountManagement;

namespace LacunaExpress.Pages.AccountPages
{
	public class Login : ContentPage
	{
		Entry Username = new Entry() { Placeholder = "Empire Name"};
		Entry Password = new Entry() { Placeholder = "Pass Code" };


		Label Serverlbl = new Label() { Text = "https://us1.lacunaexpanse.com"};
		Label Usernamelbl = new Label() { Text = "Empire Name" };
		Label Passwordlbl = new Label() { Text = "Password" };
		Label Resultlbl = new Label() { Text = "" };

		Button Submit = new Button() { Text = "Submit" };


		public Login()
		{
			Content = new StackLayout
			{
				Children = {
					Usernamelbl,
					Username,
					Passwordlbl,
					Password,
					Serverlbl,
					Submit,
					Resultlbl
				}
			};

			Submit.Clicked += async (sender, e) =>
			{
				var aMgr = new AccountManagement.AccountManager();
				var status = await aMgr.CreateAndAddAccountAsync(Username.Text, Password.Text, Serverlbl.Text, true);
				if (status)
				{
					
					//await Navigation.PushAsync(new MessageList());
					await Navigation.PopModalAsync();
				}
				else
					Resultlbl.Text = "Request Failed, try again";

			};
			
		}
	}
}
