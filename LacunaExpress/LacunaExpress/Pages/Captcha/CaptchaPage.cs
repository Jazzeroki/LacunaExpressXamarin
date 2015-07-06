using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace LacunaExpress.Pages.Captcha
{
	public class CaptchaPage : ContentPage
	{
		Image captchaImage = new Image();
		Entry answerEntry = new Entry
		{
			Placeholder = "Answer"
		};
		Button answerButton = new Button
		{
			Text = "Answer"
		};
		public CaptchaPage()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
			answerButton.Clicked += async (sender, e) =>{

			};
		}

		async void GetCaptcha()
		{
			var s = new Server();
			var response = await s.GetHttpResultAsync(account.Server, Inbox.url, json);
		}
	}	
}
