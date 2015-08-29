using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace LacunaExpress.Pages.Help
{
	public class HelpMain : ContentPage
	{
		public HelpMain()
		{
			//This gets the styles Dictionary and sets it on this page.
			Resources = Styles.Styles.StyleDictionary;

			Label helpOne = new Label () {
				Text = "Hello ContentPage",
				Style = (Style)Resources["labelBlackText"],
			};

			Content = new StackLayout
			{
				Padding = new Thickness(6, 6, 6, 6),
				Children = {
					helpOne
				}
			};
		}
	}
}
