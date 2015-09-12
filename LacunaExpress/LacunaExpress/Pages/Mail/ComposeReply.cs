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

namespace LacunaExpress.Pages.Mail
{
	public class ComposeReply : ContentPage
	{
        string session, server;
		//AccountModel account;
		Messages message;

		Entry to = new Entry() {
            Placeholder = "To",
			TextColor = Color.Black,
            BackgroundColor = Color.White
        };
		Entry subject = new Entry() { 
			Placeholder = "Subject",
			TextColor = Color.Black,
        	BackgroundColor = Color.White
        };
		Editor body = new Editor()
		{
			VerticalOptions = LayoutOptions.FillAndExpand
		};
        
        
		Button send = new Button	
		{
			Text = "Send",
			//Style = (Style)Styles.Styles.StyleDictionary["buttonWhiteText"]
			TextColor = Color.White, /*BorderWidth = 2,*/ BorderColor = Color.White, BackgroundColor = Color.Blue, FontAttributes = FontAttributes.Bold
		};
		Button cancel = new Button
		{
			Text = "Cancel",
			//Style = (Style)Styles.Styles.StyleDictionary["buttonWhiteText"]
			TextColor = Color.White, /*BorderWidth = 2,*/ BorderColor = Color.White, BackgroundColor = Color.Blue, FontAttributes = FontAttributes.Bold
		};
		public ComposeReply(string sessionID, string server)
		{
			session = sessionID;
            this.server = server;
			to.Placeholder = "To";
			subject.Placeholder = "Subject";
			BuildPage();
		}
		public ComposeReply(string sessionID, string server, Messages message, string type)
		{
			this.message = message;
            session = sessionID;
            this.server = server;
            to.Text = message.from;
			subject.Text = type + message.subject;
			body.Text = message.body;
			BuildPage();
		}
		private void BuildPage()
		{
            StackLayout buttonHolder = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { send, cancel },
                VerticalOptions = LayoutOptions.End,
                BackgroundColor = Color.Black
            };
			var mainLayout = new StackLayout
			{
				BackgroundColor = Color.FromRgb (0, 0, 128),
				Children = {
					to,
					subject,
					new ScrollView {
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Content = body
                    },
					buttonHolder
				}
			};

			Content = mainLayout;
			if (Device.OS == TargetPlatform.iOS)
			{
				mainLayout.Padding = new Thickness (0, 20, 0, 0);
			}

			send.Clicked += async (sender, e) =>
			{
				string json = Inbox.SendMessage(1, session, to.Text, subject.Text, body.Text); 
				var s = new LacunaExpress.Data.Server();
                var response = await s.GetHttpResultAsync(server, Inbox.url, json);
                var x = response;
                if (response.result != null)
                    await Navigation.PopAsync();
            };
			cancel.Clicked += async (sender, e) =>
			{
				await Navigation.PopAsync();
			};
		}
	}
}
