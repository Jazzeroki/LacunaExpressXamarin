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
		Button viewStations = new Button { Text = "View Stations" };
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
					viewStations
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
			stationPicker.SelectedIndexChanged += async (sender, e) =>
			{
				selectedStation = stationPicker.Items[stationPicker.SelectedIndex];
				ActivateButtons();
			};
		}

		private void ActivateButtons()
		{

		}
	}
}
