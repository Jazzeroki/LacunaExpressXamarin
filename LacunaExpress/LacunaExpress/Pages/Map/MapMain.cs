using LacunaExpress.AccountManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using LacunaExpress.Scripts;

using LacunaExpress.Styles;

namespace LacunaExpress.Pages.Map
{
    public class MapMain : ContentPage
    {
        AccountModel activeAccount;
        
        public MapMain()
        {
            Resources = Styles.Styles.StyleDictionary;
            Button cacheStarMapBtn = new Button
            {
                Text = "Cache Map",
                Style = (Style)Styles.Styles.StyleDictionary[Styles.Styles.StyleName.RegularButton.ToString()]
                //TextColor = Color.White,
                //BorderWidth = 2,
                //BorderColor = Color.White,
                //BackgroundColor = Color.Blue,
                //FontAttributes = FontAttributes.Bold
            };
			var mainLayout = new StackLayout
            {
				BackgroundColor = Color.FromRgb (0, 0, 128),
                Children = {
                    cacheStarMapBtn
                }
            };

			Content = mainLayout;
			if (Device.OS == TargetPlatform.iOS)
			{
				mainLayout.Padding = new Thickness (0, 20, 0, 0);
			}

            this.Appearing += async (sender, e) =>
            {
                AccountManagement.AccountManager accountMngr = new AccountManagement.AccountManager();
                activeAccount = await accountMngr.GetActiveAccountAsync();
            };
            cacheStarMapBtn.Clicked += async (sender, e) =>
            {
                var s = await MapScripts.GetAllStarsInRange300(activeAccount, 0, 0);
                Data.FileStorage.SaveStarsAsync(s);
            };
        }
    }
}
