using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LacunaExpress.ViewCells
{
	public class SpySelectionViewCell : ViewCell
	{
		Switch SpySelected = new Switch
		{
			IsToggled = false
		};
		Label SpyName = new Label
		{

		};
		Label SpyID = new Label
		{

		};
		Label SpyLevel = new Label
		{

		};
		Label Intel = new Label
		{

		};
		Label Mayhem = new Label
		{

		};
		Label Theft = new Label
		{

		};
		Label Political = new Label
		{

		};
		StackLayout Outer = new StackLayout
		{
			Orientation = StackOrientation.Horizontal
		};
		StackLayout Left = new StackLayout
		{

		};
		StackLayout Top = new StackLayout
		{
			Orientation = StackOrientation.Horizontal
		};
		StackLayout Bottom = new StackLayout
		{
			Orientation = StackOrientation.Horizontal
		};
		public SpySelectionViewCell()
		{
			Outer.Children.Add(Left);
			Outer.Children.Add(SpySelected);

			Top.Children.Add(SpyName);
			Top.Children.Add(SpyLevel);
			Top.Children.Add(SpyID);

			Bottom.Children.Add(Intel);
			Bottom.Children.Add(Mayhem);
			Bottom.Children.Add(Theft);
			Bottom.Children.Add(Political);

			Left.Children.Add(Top);
			Left.Children.Add(Bottom);

			SpyName.SetBinding(Label.TextProperty, "SpyName");
			SpyID.SetBinding(Label.TextProperty, "SpyID");
			SpyLevel.SetBinding(Label.TextProperty, "SpyLevel");
			Intel.SetBinding(Label.TextProperty, "Intel");
			Political.SetBinding(Label.TextProperty, "Political");
			Mayhem.SetBinding(Label.TextProperty, "Mayhem");
			Theft.SetBinding(Label.TextProperty, "Theft");

			View = Outer;
		}
	}
}
