using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

using LacunaExpress.Styles;

namespace LacunaExpress.Pages.Planets
{
	public class PlanetBuildingDetail : ContentPage
	{
		Image buildingImage = new Image { };
		Label buildingName = new Label
		{
			TextColor = Color.White
		};
		Label buildingLevel = new Label
		{
			TextColor = Color.White
		};
		Label buildingEffiency = new Label
		{
			TextColor = Color.White
		};
		public PlanetBuildingDetail()
		{
			var mainLayout = new StackLayout
			{
				BackgroundColor = Color.FromRgb (0, 0, 128),
				Children = {
					new Label { Text = "" }
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
