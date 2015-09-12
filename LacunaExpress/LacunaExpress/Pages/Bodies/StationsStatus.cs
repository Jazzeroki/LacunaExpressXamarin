using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using LacunaExpress.Styles;

using Xamarin.Forms;

namespace LacunaExpress.Pages.Bodies
{
	public class StationsStatus : ContentPage
	{
		public StationsStatus()
		{
			var mainLayout = new StackLayout
			{
				BackgroundColor = Color.FromRgb (0, 0, 128),
				Children = {
					new Label { Text = "Hello ContentPage" }
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
