using LacunaExpress.AccountManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;
using LacunaExpanseAPIWrapper;

namespace LacunaExpress.Pages.CaptchaPage
{
	public class CaptchaPage : ContentPage
	{
		string guid;
		Image captchaImage = new Image();
		Entry answerEntry = new Entry
		{
			Placeholder = "Answer"
		};
		Button answerButton = new Button
		{
			Text = "Answer"
		};
		public CaptchaPage(AccountModel account)
		{
			Content = new StackLayout
			{
				Children = {
					captchaImage,
					answerEntry,
					answerButton
				}
			};
			answerButton.Clicked += async (sender, e) =>{
				if (answerEntry.Text.Length > 0)
				{
					answerButton.IsEnabled = false;
					var s = new LacunaExpress.Data.Server();
					var json = Captcha.Solve(account.SessionID, guid, answerEntry.Text);
					var response = await s.GetHttpResultStringAsyncAsString(account.Server, Captcha.url, json);
					if (response != null)
					{
						var r = Newtonsoft.Json.JsonConvert.DeserializeObject<CaptchaResponse>(response);
						if(r.result==1){
							var oldacnt = account;
							account.CaptchaLastRenewed = DateTime.Now;
							AccountManager accountMan = new AccountManager();
							accountMan.ModifyAccountAsync(account, oldacnt);
							await Navigation.PopModalAsync();
						}
					}
					else
					{
						answerButton.IsEnabled = true;
					}
				}
			};
			this.Appearing += async (sender, e) =>
			{
				var captchaValidUntil = DateTime.Now.AddMinutes(-25);
				if (account.CaptchaLastRenewed > captchaValidUntil) 
				{
					await Navigation.PopModalAsync();
				}else
				{
					GetCaptcha(account);
				}
			};			
		}

		async void GetCaptcha(AccountModel account)
		{
			var s = new LacunaExpress.Data.Server();
			var json = Captcha.Fetch(account.SessionID);
			var response = await s.GetHttpResultAsync(account.Server, Captcha.url, json);
			if (response.result != null)
			{
				guid = response.result.guid;
				captchaImage.Source = response.result.url;
			}
		}
	}	
}
