using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using LacunaExpanseAPIWrapper;
using LacunaExpress.Pages;

namespace LacunaExpress
{
	public class App : Application
	{
		public App()
		{
			//MainPage = new Login();
			MainPage = new Master();
			////var s = new Empire();
			//var p = Empire.Login(1, "356", "helloworld");
			//// The root page of your application
			//MainPage = new ContentPage
			//{
			//	Content = new StackLayout
			//	{
			//		VerticalOptions = LayoutOptions.Center,
			//		Children = {
			//			new Label {
			//				XAlign = TextAlignment.Center,
			//				Text = p
			//			}
			//		}
			//	}
			//};
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
