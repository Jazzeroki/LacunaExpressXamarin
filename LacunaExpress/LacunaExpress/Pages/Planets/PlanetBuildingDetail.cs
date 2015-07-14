using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

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
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}
