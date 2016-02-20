using LacunaExpanseAPIWrapper;
using LacunaExpanseAPIWrapper.ResponseModels;
using LacunaExpress.AccountManagement;
using LacunaExpress.Data;
using LacunaExpress.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;

using LacunaExpress.Styles;

namespace LacunaExpress.Pages.Spies
{
	public class SpiesMain : ContentPage
	{
		Label planetNameLabel = new Label
		{
			BackgroundColor = Color.Black,
			TextColor = Color.Blue,
			FontAttributes = FontAttributes.Bold,
			HorizontalTextAlignment = TextAlignment.Center,
			HeightRequest = 40,
			VerticalTextAlignment = TextAlignment.Center
		};
		AccountModel account;
		Building intelTrain, mayhemTrain, politicalTrain, theftTrain, intelMinistry;
		List<Prisoner> prisonersList = new List<Prisoner>();
		List<LacunaExpanseAPIWrapper.ResponseModels.Spies> planetSpies = new List<LacunaExpanseAPIWrapper.ResponseModels.Spies>();
		string secMinID, intelMinID, planetName, planetID;
		Label totalSpies 			  = new Label { TextColor = Color.White };
		Label spiesOnCounter 		  = new Label { TextColor = Color.White };
		Label spiesOnIntelTraining 	  = new Label { TextColor = Color.White };
		Label spiesOnPoliticsTraining = new Label { TextColor = Color.White };
		Label spiesOnMayhemTraining   = new Label { TextColor = Color.White };
		Label spiesOnTheftTraining 	  = new Label { TextColor = Color.White };
		Label spiesOnPropaganda 	  = new Label { TextColor = Color.White };
		Label spiesIdle 			  = new Label { TextColor = Color.White };
		Label foreignSpies 			  = new Label { TextColor = Color.White };
		Label prisoners 			  = new Label { TextColor = Color.White };

        StackLayout buttonHolder = new StackLayout();
        ScrollView buttonScroll = new ScrollView();

		Button trainSpiesBtn 					= new Button { Text = "Train Spies", Style = (Style)Styles.Styles.StyleDictionary[Styles.Styles.StyleName.RegularButton.ToString()] };
		Button runSweepsBtn 					= new Button { Text = "Run Sweeps", Style = (Style)Styles.Styles.StyleDictionary[Styles.Styles.StyleName.RegularButton.ToString()] };
		Button viewSpiesBtn 					= new Button { Text = "View Spies", Style = (Style)Styles.Styles.StyleDictionary[Styles.Styles.StyleName.RegularButton.ToString()] };
		Button executePrisonersBtn				= new Button { Text = "Execute Prisoners", Style = (Style)Styles.Styles.StyleDictionary[Styles.Styles.StyleName.RegularButton.ToString()] };
		Button removeSpiesFromPolicalPropaganda = new Button { Text = "Remove From Political Propaganda", Style = (Style)Styles.Styles.StyleDictionary[Styles.Styles.StyleName.RegularButton.ToString()] };
		Button sendSpies 						= new Button { Text = "Send Available Spies", Style = (Style)Styles.Styles.StyleDictionary[Styles.Styles.StyleName.RegularButton.ToString()] };
		public SpiesMain(AccountModel account, string selectedPlanet)
		{
            buttonScroll.Content = buttonHolder;
            buttonHolder.Children.Add(trainSpiesBtn);
            buttonHolder.Children.Add(runSweepsBtn);
            buttonHolder.Children.Add(viewSpiesBtn);
            buttonHolder.Children.Add(executePrisonersBtn);
            buttonHolder.Children.Add(removeSpiesFromPolicalPropaganda);
            buttonHolder.Children.Add(sendSpies);
            this.account = account;
			var mainLayout = new StackLayout
			{
				//BackgroundColor = Color.FromRgb (0, 0, 128),
				Style = (Style)Styles.Styles.StyleDictionary[Styles.Styles.StyleName.MainLayout.ToString()],
                Children = {
					planetNameLabel,
					totalSpies,
					spiesOnCounter,
					spiesOnIntelTraining,
					spiesOnPoliticsTraining,
					spiesOnMayhemTraining,
					spiesOnTheftTraining,
					spiesOnPropaganda,
					spiesIdle,
					foreignSpies,
					prisoners,
                    buttonScroll

				}

			};

			Content = mainLayout;
			if (Device.OS == TargetPlatform.iOS)
			{
				mainLayout.Padding = new Thickness (0, 20, 0, 0);
			}

			this.Appearing += async (sender, e) =>
			{
                if (!AccountManager.CaptchaStillValid(account))
                {
                    await Navigation.PushModalAsync(new CaptchaPage.CaptchaPage(account));
                }
				planetName = selectedPlanet;			
				planetID = (from b in account.Colonies
								where b.Value.Equals(selectedPlanet)
								select b.Key).First();
				planetNameLabel.Text = selectedPlanet + " " + planetID;
				planetNameLabel.TextColor = Color.White;
				LoadSpyInfo(planetID);
			};
			sendSpies.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new SendSpies(account, intelMinID, planetID));
			};
            removeSpiesFromPolicalPropaganda.Clicked += async (sender, e) =>
            {
                List<LacunaExpanseAPIWrapper.ResponseModels.Spies> spiesOnPoliticalProp = await SpyScripts.FilterSpiesByAssignment(planetSpies, "Political Propaganda");
                SpyScripts.BatchAssignSpies(account, spiesOnPoliticalProp, "Idle", intelMinID);
                if (spiesOnPoliticalProp.Count > 30)
                    await DisplayAlert("Notice", "This may take a couple of minutes to complete", "OK");
            };
			executePrisonersBtn.Clicked += async (sender, e) =>
			{
				var prisoners = await SpyScripts.GetPrisoners(account, secMinID);
				SpyScripts.ExecutePrisonersOnPlanet(account, secMinID, prisoners);
			};
			trainSpiesBtn.Clicked += (sender, e) =>
			{
				if (intelMinID != null)
				{
					SpyScripts.TrainSpies(planetSpies, account, intelMinID, intelMinistry, intelTrain, mayhemTrain, theftTrain, politicalTrain, selectedPlanet, 6);
				}
			};
			runSweepsBtn.Clicked += async (sender, e) =>
			{
                await DisplayAlert("Performance", "This script will run a series of up to 6 sweeps using idle spies", "Ok");
				
				if (intelMinID != null)
				{
					var idleSpies = SpyScripts.GetIdleSpiesFromList(planetSpies);
					var orderedIdleSpies = idleSpies.OrderByDescending(x => x.level);
					var spiesToUse = new List<LacunaExpanseAPIWrapper.ResponseModels.Spies>();
					int i = 0;
					foreach (var spy in orderedIdleSpies)
					{
						spiesToUse.Add(spy);
						i++;
						if (i == 6)
							break;
					}
					foreach (var spy in spiesToUse)
					{
						var server = new Data.Server();
						var json = Intelligence.AssignSpy(account.SessionID, intelMinID, spy.id, "Security Sweep");
						var response = await server.GetHttpResultStringAsyncAsString(account.Server, Intelligence.URL, json);
						if (response != null)
						{

						}
					}
					
				}
			};

		}

		async void Spyrun() { }


		private async void LoadSpyInfo(string bodyID)
		{
			IsBusy = true;
			var json = LacunaExpanseAPIWrapper.Body.GetBuildings(1, account.SessionID, bodyID);
			var s = new LacunaExpress.Data.Server();
			var response = await s.GetHttpResultAsync(account.Server, LacunaExpanseAPIWrapper.Body.url, json);
			if (response.result != null)
			{
				var building = response.result.buildings.Where(x => x.Value.name.Contains("Security")).First();
				var secMinID = response.result.buildings.FirstOrDefault(x => x.Value.name.Contains("Security")).Key;
				intelMinID = response.result.buildings.FirstOrDefault(x => x.Value.name.Contains("Intelligence")).Key;
				intelMinistry = response.result.buildings.FirstOrDefault(x => x.Value.name.Contains("Intelligence")).Value;
				intelTrain = response.result.buildings.FirstOrDefault(x => x.Value.name.Contains("Intel Training")).Value;
				mayhemTrain = response.result.buildings.FirstOrDefault(x => x.Value.name.Contains("Mayhem Training")).Value;
				theftTrain = response.result.buildings.FirstOrDefault(x => x.Value.name.Contains("Theft Training")).Value;
				politicalTrain = response.result.buildings.FirstOrDefault(x => x.Value.name.Contains("Politics Training")).Value;

				if (secMinID.Length > 0 || !secMinID.Contains("Uknown ident"))
				{
					json = Security.ViewForeignSpies(account.SessionID, secMinID, "1");
					s = new LacunaExpress.Data.Server();
					response = await s.GetHttpResultAsync(account.Server, Security.URL, json);
					if (response.result != null)
					{
						foreignSpies.Text = "Foreign Spies Detected: " + response.result.spy_count;
					}
					json = Security.ViewPrisoners(account.SessionID, secMinID, "1");
					s = new LacunaExpress.Data.Server();
					response = await s.GetHttpResultAsync(account.Server, Security.URL, json);
					if (response.result != null)
					{
						prisoners.Text = "Prisoners: " + response.result.prisoners.Count;
						prisonersList = response.result.prisoners;
					}
				}
				if (intelMinID.Length > 0 || !secMinID.Contains("Uknown ident"))
				{
					json = Intelligence.ViewAllSpies(account.SessionID, intelMinID);
					s = new LacunaExpress.Data.Server();
					response = await s.GetHttpResultAsync(account.Server, Intelligence.URL, json);
					if (response.result != null)
					{
						planetSpies = response.result.spies;
						totalSpies.Text = "Total Spies: " + response.result.spies.Count;
						totalSpies.TextColor = Color.White;
						spiesOnCounter.Text = "Counter Espionage: " + (from counterCount in response.result.spies
																	   where counterCount.assignment.Equals("Counter Espionage")
																	   select counterCount).Count().ToString();
						spiesOnCounter.TextColor = Color.White;
						spiesOnIntelTraining.Text = "Intelligence Training: " + (from counterCount in response.result.spies
																				 where counterCount.assignment.Equals("Intel Training")
																				 select counterCount).Count().ToString();
						spiesOnIntelTraining.TextColor = Color.White;
						spiesOnMayhemTraining.Text = "Mayhem Training: " + (from counterCount in response.result.spies
																			where counterCount.assignment.Equals("Mayhem Training")
																			select counterCount).Count().ToString();
						spiesOnMayhemTraining.TextColor = Color.White;
						spiesOnTheftTraining.Text = "Theft Training: " + (from counterCount in response.result.spies
																		  where counterCount.assignment.Equals("Theft Training")
																		  select counterCount).Count().ToString();
						spiesOnTheftTraining.TextColor = Color.White;
						spiesOnPoliticsTraining.Text = "Politics Training: " + (from counterCount in response.result.spies
																				where counterCount.assignment.Equals("Politics Training")
																				select counterCount).Count().ToString();
						spiesOnPoliticsTraining.TextColor = Color.White;
						spiesIdle.Text = "Idle: " + (from counterCount in response.result.spies
													 where counterCount.assignment.Equals("Idle")
													 select counterCount).Count().ToString();
						spiesOnPropaganda.TextColor = Color.White;
						spiesOnPropaganda.Text = "Propaganda: " + (from counterCount in response.result.spies
																   where counterCount.assignment.Equals("Political Propaganda")
																   select counterCount).Count().ToString();

					}
				}
			}

			IsBusy = false;
		}


	}


}


