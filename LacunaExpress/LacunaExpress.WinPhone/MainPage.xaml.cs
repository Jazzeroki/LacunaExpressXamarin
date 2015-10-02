using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Xamarin;

namespace LacunaExpress.WinPhone
{
	public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
	{
		public MainPage()
		{
			InitializeComponent();
			SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

			Insights.Initialize("7ac2ff3a51b2790eb6e2dceead2b2f5c6611d7c3");
			global::Xamarin.Forms.Forms.Init();
			LoadApplication(new LacunaExpress.App());
		}
	}
}
