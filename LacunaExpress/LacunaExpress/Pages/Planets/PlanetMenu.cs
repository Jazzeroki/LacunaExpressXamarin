using LacunaExpress.Pages.Spies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;

namespace LacunaExpress.Pages.Planets
{
	public class PlanetMenu : ContentPage
	{
		string selectedPlanet;
		AccountManagement.AccountModel activeAccount;
		Picker planetPicker = new Picker
		{
			Title = "Select Planet",
			VerticalOptions = LayoutOptions.CenterAndExpand
		};
		Button spyOptions = new Button
		{
			Text = "Spy Tools"
		};
		Button shipOptions = new Button
		{
			Text = "Ship Tools"
		};
		Button buildingOptions = new Button
		{
			Text = "Building Tools"
		};
		Button tradeOptions = new Button
		{
			Text = "Trade Tools"
		};
		Button buildingsBtn = new Button
		{
			Text = "Buildings"
		};
		Button planetMapBtn = new Button
		{
			Text = "Planet Map"
		};
		public PlanetMenu()
		{


			Content = new StackLayout
			{
				Children = {
					planetPicker,
					spyOptions,
					shipOptions,
					buildingOptions,
					tradeOptions,
					buildingsBtn,
					planetMapBtn

				}
			};
			this.Appearing += async (sender, e) =>
			{
				AccountManagement.AccountManager accountMngr = new AccountManagement.AccountManager();
				activeAccount = await accountMngr.GetActiveAccountAsync();

				selectedPlanet = activeAccount.Capital;


				var plist = activeAccount.Colonies.Values.ToList();
				plist.Sort();

				foreach (var p in plist)
				{
					planetPicker.Items.Add(p);
				}
				planetPicker.SelectedIndex = planetPicker.Items.IndexOf(selectedPlanet);
			};
			planetPicker.SelectedIndexChanged += async (sender, e) =>
			{
				selectedPlanet = planetPicker.Items[planetPicker.SelectedIndex];
			};

			buildingsBtn.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new PlanetBuildings(activeAccount, selectedPlanet));
			};
			spyOptions.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new SpiesMain(activeAccount, selectedPlanet));
			};
			buildingOptions.Clicked += async (sender, e) =>
				{
					await Navigation.PushAsync(new BuildingToolsView(activeAccount, selectedPlanet));
				};
			shipOptions.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new ShipTools(activeAccount, selectedPlanet));
			};
			planetMapBtn.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new PlanetMap(activeAccount, selectedPlanet));
			};
		}
	}
}
