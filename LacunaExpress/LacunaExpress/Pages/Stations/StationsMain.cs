using LacunaExpress.AccountManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;

namespace LacunaExpress.Pages.Stations
{
	public class StationsMain : ContentPage
	{
		string selectedStation;
		AccountModel activeAccount;
		Button viewStation = new Button { Text = "View Station" };
		Button parliamentBtn = new Button { Text = "Parliament" };
		Label pickerLabel = new Label { Text = "Select a Station" };
		Picker stationPicker = new Picker
		{
			Title = "Select Station",
			VerticalOptions = LayoutOptions.CenterAndExpand
		};
		public StationsMain()
		{
			
			Content = new StackLayout
			{
				Children = {
					pickerLabel,
					stationPicker,
					viewStation, 
                    parliamentBtn
				}
			};

			this.Appearing += async (sender, e) =>
			{
				AccountManagement.AccountManager accountMngr = new AccountManagement.AccountManager();
				activeAccount = await accountMngr.GetActiveAccountAsync();
				var stationNames = activeAccount.Stations.Values.ToList();
				stationNames.Sort();
				foreach (var s in stationNames)
				{
					stationPicker.Items.Add(s);
				}
			};
            viewStation.IsVisible = false;
            parliamentBtn.IsVisible = false;
			stationPicker.SelectedIndexChanged += (sender, e) =>
			{
				selectedStation = stationPicker.Items[stationPicker.SelectedIndex];
				ActivateButtons();
			};
            viewStation.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new StationBuildings(activeAccount, selectedStation));
            };
            parliamentBtn.Clicked += async (sender, e) =>
            {
                if(activeAccount.Stations.Count >0)
                    await Navigation.PushAsync(new Parliament(activeAccount, selectedStation));
            };
		}

		private void ActivateButtons()
		{
            viewStation.IsVisible = true;
            parliamentBtn.IsVisible = true;
        }
	}
}
