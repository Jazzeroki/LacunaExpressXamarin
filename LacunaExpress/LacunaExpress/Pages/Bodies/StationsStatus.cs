using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace LacunaExpress.Pages.Bodies
{
	public class StationsStatus : ContentPage
	{
		public StationsStatus()
		{
			Content = new StackLayout
			{
				BackgroundColor = Color.FromRgb (0, 0, 128),
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}
