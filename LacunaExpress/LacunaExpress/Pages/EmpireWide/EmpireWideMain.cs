using LacunaExpress.AccountManagement;
using LacunaExpress.Pages.Bodies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;

namespace LacunaExpress.Pages.EmpireWide
{
	public class EmpireWideMain : ContentPage
	{
		AccountModel account;
		Button planetStatusCheck = new Button
		{
			Text = "Planet Status Check"
		};
		public EmpireWideMain()
		{
			
			Content = new StackLayout
			{
				Children = {
					planetStatusCheck
				}
			};

			planetStatusCheck.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new BodyStatus(account, false));
			};

			this.Appearing += async (sender, e) =>
			{
				AccountManager acntMgr = new AccountManager();
				account = await acntMgr.GetActiveAccountAsync();
			};
		}
	}
}
