using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;


using Xamarin.Forms;

using LacunaExpress.Styles;

namespace LacunaExpress.Pages
{
	public class Splash : ContentPage
	{
		AccountManagement.AccountManager accountManager = new AccountManagement.AccountManager();

		Label welcome = new Label
		{
			Text = "Welcome to Lacuna Express",
			TextColor = Color.White,
			HorizontalTextAlignment = TextAlignment.Center
		};

		public Splash()
		{
			var mainLayout = new StackLayout
			{
				BackgroundColor = Color.FromRgb (0, 0, 128),
				Padding = new Thickness(5),
				Children = {
					welcome
				}
			};

			Content = mainLayout;
			if (Device.OS == TargetPlatform.iOS)
			{
				mainLayout.Padding = new Thickness (0, 20, 0, 0);
			}

			LoadAccountsIntoPicker();
		}

		async void LoadAccountsIntoPicker()
		{
			AccountManagement.AccountManager accountManger = new AccountManagement.AccountManager();
			var activeAccount = await accountManager.GetActiveAccountAsync();
			if (activeAccount == null)
			{
				await Navigation.PushModalAsync(new LacunaExpress.Pages.AccountPages.Login());
			}
		}
	}
}