using LacunaExpress.AccountManagement;
using LacunaExpress.Pages.Bodies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;

using LacunaExpress.Styles;

namespace LacunaExpress.Pages.EmpireWide
{
	public class EmpireWideMain : ContentPage
	{
		AccountModel account;
		Button planetStatusCheck = new Button
		{
			Text = "Planet Status Check",
			//Style = (Style)Styles.Styles.StyleDictionary["labelWhiteText"],
			Style = (Style)Styles.Styles.StyleDictionary[Styles.Styles.StyleName.RegularButton.ToString()]
		};
		Button stationStatusCheck = new Button
		{
			Text = "Station Status Check",
			//Style = (Style)Styles.Styles.StyleDictionary["labelWhiteText"]
			Style = (Style)Styles.Styles.StyleDictionary[Styles.Styles.StyleName.RegularButton.ToString()]
		};
        
		public EmpireWideMain()
		{
			
			var mainLayout = new StackLayout
			{
				BackgroundColor = Color.FromRgb (0, 0, 128),
				Children = {
					planetStatusCheck,
					stationStatusCheck
				}
			};

			Content = mainLayout;
			if (Device.OS == TargetPlatform.iOS)
			{
				mainLayout.Padding = new Thickness (0, 20, 0, 0);
			}

			planetStatusCheck.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new BodyStatus(account, false));
			};
			stationStatusCheck.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new BodyStatus(account, true));
			};

			this.Appearing += async (sender, e) =>
			{
				AccountManager acntMgr = new AccountManager();
				account = await acntMgr.GetActiveAccountAsync();
			};
		}
	}
}
