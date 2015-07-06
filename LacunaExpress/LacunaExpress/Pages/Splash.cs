using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using AccountManager;

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
		Picker accountPicker = new Picker
			{
				Title = "Message Categories",
				VerticalOptions = LayoutOptions.CenterAndExpand
			};


		public Splash()
		{

			Content = new StackLayout
			{
				Children = {
					accountPicker,
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
			foreach (var a in accounts.AccountList)
				accountPicker.Items.Add(a.EmpireName+" " + a.Server);
		}
	}
}
