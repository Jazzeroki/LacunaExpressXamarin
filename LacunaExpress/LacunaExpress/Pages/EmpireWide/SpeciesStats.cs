using LacunaExpanseAPIWrapper;
using LacunaExpanseAPIWrapper.ResponseModels;
using LacunaExpress.AccountManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;

using LacunaExpress.Styles;

namespace LacunaExpress.Pages.EmpireWide
{
	public class SpeciesStats : ContentPage
	{
		AccountModel account;
		Response response;
		Label Name           = new Label { TextColor = Color.White };
		Label Description    = new Label { TextColor = Color.White };
		Label MinOrbit       = new Label { TextColor = Color.White };
		Label MaxOrbit       = new Label { TextColor = Color.White };
		Label Manufacturing  = new Label { TextColor = Color.White };
		Label Deception      = new Label { TextColor = Color.White };
		Label Research       = new Label { TextColor = Color.White };
		Label Management     = new Label { TextColor = Color.White };
		Label Farming        = new Label { TextColor = Color.White };
		Label Mining         = new Label { TextColor = Color.White };
		Label Science        = new Label { TextColor = Color.White };
		Label Environmental  = new Label { TextColor = Color.White };
		Label Political      = new Label { TextColor = Color.White };
		Label Trade          = new Label { TextColor = Color.White };
		Label Growth         = new Label { TextColor = Color.White };

		public SpeciesStats(AccountModel account)
		{
			this.response = response;
			var mainLayout = new StackLayout
			{
				BackgroundColor = Color.FromRgb (0, 0, 128),
				Children = {
					Name,
					Description,
					MinOrbit,
					MaxOrbit,	
					Manufacturing,					
					Deception,					
					Research,
					Management,
					Farming,
					Mining,
					Science,
					Environmental,
					Political,
					Trade,
					Growth
				}
			};

			Content = mainLayout;
			if (Device.OS == TargetPlatform.iOS)
			{
				mainLayout.Padding = new Thickness (0, 20, 0, 0);
			}

			this.Appearing += async (sender, e) => 
			{
				//AccountManager acntMgr = new AccountManager();
				//account = await acntMgr.GetActiveAccountAsync();
				Name.Text            = "Name: "           + response.result.status.empire.view_species_stats;
//				Description.Text     = "Description: "    + response.result.species.description;
//				MinOrbit.Text        = "Min Orbit: "      + response.result.species.min_orbit;
//				MaxOrbit.Text        = "Max Orbit: "      + response.result.species.max_orbit;
//				Manufacturing.Text   = "Manufacturing: "  + response.result.species.manufacturing_affinity;
//				Deception.Text       = "Deception: "      + response.result.species.deception_affinity;
//				Research.Text        = "Research: "       + response.result.species.research_affinity;
//				Management.Text      = "Management: "     + response.result.species.management_affinity;
//				Farming.Text         = "Farming: "        + response.result.species.farming_affinity;
//				Mining.Text          = "Mining: "         + response.result.species.mining_affinity;
//				Science.Text         = "Science: "        + response.result.species.science_affinity;
//				Environmental.Text   = "Environmental: "  + response.result.species.environmental_affinity;
//				Political.Text       = "Political: "      + response.result.species.political_affinity;
//				Trade.Text           = "Trade: "          + response.result.species.trade_affinity;
//				Growth.Text          = "Growth: "         + response.result.species.growth_affinity;
			};
		}
	}
}

