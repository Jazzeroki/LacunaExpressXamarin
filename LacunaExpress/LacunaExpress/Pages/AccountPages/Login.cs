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
using LacunaExpress.Styles;

namespace LacunaExpress.Pages.AccountPages
{
	public class Login : ContentPage
	{
		Entry Username = new Entry() { Placeholder = "Empire Name" };
		Entry Password = new Entry() { Placeholder = "Pass Code" };


		Label Serverlbl = new Label() { Text = "https://us1.lacunaexpanse.com", TextColor = Color.White };
		Label Usernamelbl = new Label() { Text = "Empire Name", TextColor = Color.White };
		Label Passwordlbl = new Label() { Text = "Password", TextColor = Color.White };
		Label Resultlbl = new Label() { Text = "" };

		Button Submit = new Button() { Text = "Submit", Style = (Style)Styles.Styles.StyleDictionary[Styles.Styles.StyleName.RegularButton.ToString()] };

		StackLayout switchLayout = new StackLayout
		{
			Orientation = StackOrientation.Horizontal
		};
		Label activeLbl = new Label
		{
			Text = "Make Account Primary"
		};
		Switch activeSwitch = new Switch
		{
			IsToggled = false
		};


		public Login()
		{
            //This gets the styles Dictionary and sets it on this page.
            Resources = Styles.Styles.StyleDictionary;
			BoxView topheader = new BoxView
			{
				VerticalOptions = LayoutOptions.StartAndExpand
			};

            #region controls
			Entry Username = new Entry()
			{
				Placeholder = "Empire Name",
				Style = (Style)Styles.Styles.StyleDictionary[Styles.Styles.StyleName.EntryStyle.ToString()]
			};
			Entry Password = new Entry()
			{
				Placeholder = "Pass Code",
				Style = (Style)Styles.Styles.StyleDictionary[Styles.Styles.StyleName.EntryStyle.ToString()]
			};

			Label ServerTitle = new Label()
			{
				VerticalOptions = LayoutOptions.Center,
				Text = "Server",
				Style = (Style)Styles.Styles.StyleDictionary[Styles.Styles.StyleName.TitleLabel.ToString()],
			};
			Label Serverlbl = new Label()
			{
				Text = "https://us1.lacunaexpanse.com",
				TextColor = Color.Gray,
				FontAttributes = FontAttributes.Italic,
			};
			Label Usernamelbl = new Label()
			{
				VerticalOptions = LayoutOptions.Center,
				Text = "Empire Name",
				Style = (Style)Styles.Styles.StyleDictionary[Styles.Styles.StyleName.TitleLabel.ToString()],
			};
			Label Passwordlbl = new Label() { Text = "Password", Style = (Style)Styles.Styles.StyleDictionary[Styles.Styles.StyleName.TitleLabel.ToString()], };
            Label Resultlbl = new Label() { Text = "" };

            Button Submit = new Button()
            {
				VerticalOptions = LayoutOptions.EndAndExpand,
                Text = "Submit",
				Style = (Style)Styles.Styles.StyleDictionary[Styles.Styles.StyleName.RegularButton.ToString()]
            };

            StackLayout switchLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            Label activeLbl = new Label
            {
                Text = "Make Account Primary",
				Style = (Style)Styles.Styles.StyleDictionary[Styles.Styles.StyleName.TitleLabel.ToString()],
			};
            Switch activeSwitch = new Switch
            {
                IsToggled = false
            };
            #endregion

            switchLayout.Children.Add(activeLbl);
			switchLayout.Children.Add(activeSwitch);
			var mainLayout = new StackLayout
			{
				Padding = new Thickness(6, 6, 6, 6),
				BackgroundColor = Color.FromRgb (0, 0, 128),
				Children = {
					topheader,
					Usernamelbl,
					Username,
					Passwordlbl,
					Password,
					Serverlbl,
					switchLayout,
					Submit,
					Resultlbl
				}
			};

			Content = mainLayout;
			if (Device.OS == TargetPlatform.iOS)
			{
				mainLayout.Padding = new Thickness (0, 20, 0, 0);
			}

			Submit.Clicked += async (sender, e) =>
			{
				activeSwitch.IsEnabled = false;
				Submit.IsEnabled = false;
				var aMgr = new AccountManagement.AccountManager();
				var status = await aMgr.CreateAndAddAccountAsync(Username.Text, Password.Text, Serverlbl.Text, activeSwitch.IsToggled);
				if (status)
				{
					
					//await Navigation.PushAsync(new MessageList());
					await Navigation.PopModalAsync();
				}
				else
					Resultlbl.Text = "Request Failed, try again";
				activeSwitch.IsEnabled = true;
				Submit.IsEnabled = true;

			};
			
		}
	}
}
