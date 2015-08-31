using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LacunaExpress.ViewCells
{
    class PlanetStatusViewCell : ViewCell
    {
        StackLayout OuterVertical = new StackLayout { Orientation = StackOrientation.Vertical, BackgroundColor = Color.Transparent };
        StackLayout InnerHorizontal = new StackLayout { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.Transparent };
        Label Name = new Label { TextColor = Color.White };
        Label Warning = new Label { TextColor = Color.Red };
        Label Star = new Label { TextColor = Color.White };
        Label X = new Label { TextColor = Color.White };
        Label Y = new Label { TextColor = Color.White };
        Label Zone = new Label { TextColor = Color.White };

        public PlanetStatusViewCell()
        {
            Name.SetBinding(Label.TextProperty, "Name");
            Warning.SetBinding(Label.TextProperty, "Status");
            Star.SetBinding(Label.TextProperty, "Star");
            X.SetBinding(Label.TextProperty, "X");
            Y.SetBinding(Label.TextProperty, "Y");
            Zone.SetBinding(Label.TextProperty, "Zone");
            OuterVertical.Children.Add(Name);
            OuterVertical.Children.Add(InnerHorizontal);
            OuterVertical.Padding = new Thickness(6);
            InnerHorizontal.Children.Add(Star);
            InnerHorizontal.Children.Add(X);
            InnerHorizontal.Children.Add(Y);
            InnerHorizontal.Children.Add(Zone);
            InnerHorizontal.Children.Add(Warning);
            View = OuterVertical;
        }
    }
}
