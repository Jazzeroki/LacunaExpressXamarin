using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using LacunaExpress.Styles;

using Xamarin.Forms;

namespace LacunaExpress.Pages.About
{
	public class AboutMain : ContentPage
	{
		public AboutMain()
		{
			BackgroundColor = Color.FromRgb (0, 0, 128);
			//This gets the styles Dictionary and sets it on this page.
			Resources = Styles.Styles.StyleDictionary;

			Label top = new Label () {
				Text = "Lacuna Express is desinged to be a utility and Mail client for The Lacuna Expanse.  Usage of this client is at the users own risk.  Any proceeds from the sale of this client go to help cover the cost of development tools and to pay for account fees with the different app stores.",
				TextColor = Color.White
				//Style = (Style)Resources["labelWhiteText"]
			};

			Label donate = new Label () {
				Text = "If you would like to donate to help me cover the costs of tools for writing and deploying this app you can send donations to me via paypal at falcont40@hotmail.com.",
				TextColor = Color.White
				//Style = (Style)Resources["labelWhiteText"]
			};

			Label questions = new Label () {
				Text = "If you find any bugs or for suggestions or help send an email to JazzDevStudio@gmail.com or an ingame message to Jazz or TheKi.",
				TextColor = Color.White
				//Style = (Style)Resources["labelWhiteText"]	
			};

			var mainLayout = new StackLayout
			{
				Padding = new Thickness(6, 6, 6, 6),
				Children = {
					top,
					donate,
					questions
				}
			};

			Content = mainLayout;
			if (Device.OS == TargetPlatform.iOS)
			{
				mainLayout.Padding = new Thickness (0, 20, 0, 0);
			}
		}
	}
}
