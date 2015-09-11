using LacunaExpress.AccountManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using LacunaExpanseAPIWrapper.ParamsModels;

using Xamarin.Forms;
using LacunaExpress.ViewCells;

using LacunaExpress.Styles;

namespace LacunaExpress.Pages.Stations
{
    public class Parliament : ContentPage
    {
        Label stationNameLbl = new Label();
        ListView parliamentOptions = new ListView { HasUnevenRows = true, SeparatorColor = Color.Red };

        public Parliament(AccountModel account, string stationName)
        {
            stationNameLbl.Text = stationName;
			stationNameLbl.TextColor = Color.White;

            var options = OptionsLists.ParliamentLockDownProposals;
            parliamentOptions.ItemsSource = options;
            parliamentOptions.ItemTemplate = new DataTemplate(typeof(ParliamentProposalViewCell));
            parliamentOptions.ItemTapped += (sender, e) =>
            {
                //var s = (e as ParliamentProposalViewCell);
                //if (s.PropositionName.Text.Contains("Mining")){ }
                //else if (s.PropositionName.Text.Contains("Colonization")){ }
                //else if (s.PropositionName.Text.Contains("BHG")){ }
                //else if (s.PropositionName.Text.Contains("Excavator")){ }
                //else if (s.PropositionName.Text.Contains("Station")){ }
            };
			//parliamentOptions.BackgroundColor = Color.FromRgb (0, 0, 128);
            Content = new StackLayout
            {
				BackgroundColor = Color.FromRgb (0, 0, 128),
                Children = {
                    stationNameLbl,
                    parliamentOptions
                }
            };
            this.Appearing += (sender, e) =>
            {
                var planetID = (from b in account.Stations
                                where b.Value.Equals(stationName)
                                select b.Key).First();
                //LoadBuildingsAsync(planetID);
            };
        }
    }
}
