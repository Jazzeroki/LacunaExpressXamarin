using LacunaExpanseAPIWrapper;
using LacunaExpress.AccountManagement;
using LacunaExpress.Data;
using LacunaExpress.DataModels;
using LacunaExpress.ViewCells;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

using LacunaExpress.Styles;

namespace LacunaExpress.Pages.Stations
{
    public class StationBuildings : ContentPage
    {
        AccountModel account;
        ObservableCollection<BuildingData> buildingList = new ObservableCollection<BuildingData>();
        ListView buildingListView = new ListView { SeparatorColor = Color.Red, HasUnevenRows = true };

        public StationBuildings(AccountModel account, string stationName)
        {
            this.account = account;
            Content = new StackLayout
            {
				BackgroundColor = Color.FromRgb (0, 0, 128),
                Children = {
                    buildingListView
                }
            };
            this.Appearing += (sender, e) =>
            {
                var planetID = (from b in account.Stations
                                where b.Value.Equals(stationName)
                                select b.Key).First();
                LoadBuildingsAsync(planetID);
            };
            buildingList.Add(new BuildingData());
            buildingListView.ItemsSource = buildingList;
            buildingListView.ItemTemplate = new DataTemplate(typeof(BuildingViewCell));
            buildingListView.ItemTapped += (sender, e) =>
            {
                buildingListView.SelectedItem = null;
            };
			buildingListView.BackgroundColor = Color.FromRgb (0, 0, 128);
        }

        async void LoadBuildingsAsync(string bodyID)
        {
            var json = Body.GetBuildings(1, account.SessionID, bodyID);
            var s = new Server();
            LacunaExpanseAPIWrapper.ResponseModels.Response response = await s.GetHttpResultAsync(account.Server, Body.url, json);
            if (response.result != null)
            {
                buildingList.Clear();
                foreach (var bd in response.result.buildings.OrderBy(x => x.Value.name))
                {
                    var b = new BuildingData();
                    b.BuildingName = bd.Value.name;
                    b.BuildingLevel = bd.Value.level;
                    b.Efficiency = bd.Value.efficiency;
                    b.BuildingID = bd.Key;
                    b.ImageName = bd.Value.image;
                    b.url = "https://raw.githubusercontent.com/plainblack/Lacuna-Assets/master/planet_side/100/" + bd.Value.image + ".png";
                    b.BuildingURL = bd.Value.url;
                    buildingList.Add(b);
                }

            }
        }
    }
}
