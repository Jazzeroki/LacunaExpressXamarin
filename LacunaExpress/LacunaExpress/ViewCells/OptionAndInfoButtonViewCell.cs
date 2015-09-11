using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LacunaExpress.ViewCells
{
    public class OptionAndInfoButtonViewCell : ViewCell
    {
        public OptionAndInfoButtonViewCell()
        {
            Label optionName = new Label { };
            Button info = new Button { Text = "?"};
            Label hiddenInfoText = new Label { };

            StackLayout holder = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
            };

            holder.Children.Add(optionName);
            holder.Children.Add(info);
            holder.Children.Add(hiddenInfoText);
            hiddenInfoText.IsVisible = false;

            info.Clicked += async (sender, e) =>
            {

            };
        }
    }
}
