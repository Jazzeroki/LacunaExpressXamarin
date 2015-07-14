using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;


using Xamarin.Forms;

namespace LacunaExpress.Pages
{
	public class Splash : ContentPage
	{
		AccountManagement.AccountManager accountManager = new AccountManagement.AccountManager();
		Button loadAccount = new Button
		{
			Text = "Load Account"
		};
		Button saveAccount = new Button
		{
			Text = "Save Account"
		};
		Button deletAccount = new Button
		{
			Text = "Delete Account"
		};
		Button captchaButton = new Button
		{
			Text = "Captcha Test"
		};
		Picker accountPicker = new Picker
			{
				Title = "Select Account",
				VerticalOptions = LayoutOptions.CenterAndExpand
			};


		public Splash()
		{

			Content = new StackLayout
			{
				Children = {
					accountPicker,
					captchaButton,
					loadAccount,
					saveAccount,
					deletAccount
				}
			};
			loadAccount.Clicked += async (sender, e) =>
			{
				var account = await accountManager.GetActiveAccountAsync();
				var x = account;
			};
			deletAccount.Clicked += (sender, e) =>
			{
				accountManager.ClearAccount();
			};
			captchaButton.Clicked += async (sender, e) =>
			{
				var accountMgr = new AccountManagement.AccountManager();
				var account = await accountManager.GetActiveAccountAsync();
				await Navigation.PushAsync(new CaptchaPage.CaptchaPage(account));
			};
			accountPicker.SelectedIndexChanged += async (sender, e) =>
			{
				//await LoadMessagesAsync(messageCategories.Items[messageCategories.SelectedIndex]);
			};
			LoadAccountsIntoPicker();
		}

		async void LoadAccountsIntoPicker()
		{
			AccountManagement.AccountManager accountManger = new AccountManagement.AccountManager();
			var accounts = await accountManager.LoadAccountsAsync();
			var activeAccount = await accountManager.GetActiveAccountAsync();
			if (accounts != null)
			{
				foreach (var a in accounts.AccountList)
					accountPicker.Items.Add(a.EmpireName + " " + a.Server);
			}
			else
			{
				await Navigation.PushModalAsync(new LacunaExpress.Pages.AccountPages.Login());
			}
		}
	}
}
