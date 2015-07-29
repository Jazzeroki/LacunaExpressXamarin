using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace LacunaExpress.Pages.About
{
	public class AboutMain : ContentPage
	{
		Label top = new Label();
		Label donate = new Label();
		Label questions = new Label();
		public AboutMain()
		{
			top.Text = "Lacuna Express is desinged to be a utility and Mail client for The Lacuna Expanse.  Usage of this client is at the users own risk.  Any proceeds from the sale of this client go to help cover the cost of development tools and to pay for account fees with the different app stores.";
			donate.Text = "If you would like to donate to help me cover the costs of tools for writing and deploying this app you can send donations to via paypal falcont40@hotmail.com";
			questions.Text = "If you find any bugs or for suggestions or help send an email to JazzDevStudio@gmail.com or an ingame message to Jazz or TheKi";
			Content = new StackLayout
			{
				Padding = new Thickness(6, 6, 6, 6),
				Children = {
					top,
					donate
				}
			};
		}
	}
}
