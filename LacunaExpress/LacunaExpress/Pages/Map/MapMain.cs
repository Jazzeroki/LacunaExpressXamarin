using LacunaExpress.AccountManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace LacunaExpress.Pages.Map
{
    public class MapMain : ContentPage
    {
        AccountModel activeAccount;
        Button cacheStarMapBtn = new Button { Text = "Cache Map" };
        public MapMain()
        {
            Content = new StackLayout
            {
                Children = {
                    cacheStarMapBtn
                }
            };
            this.Appearing += async (sender, e) =>
            {
                AccountManagement.AccountManager accountMngr = new AccountManagement.AccountManager();
                activeAccount = await accountMngr.GetActiveAccountAsync();
            };
        }
    }
}
