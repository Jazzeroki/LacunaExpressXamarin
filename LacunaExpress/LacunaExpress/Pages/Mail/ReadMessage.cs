using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using LacunaExpanseAPIWrapper;
using LacunaExpress.Data;
using LacunaExpanseAPIWrapper.ResponseModels;

namespace LacunaExpress.Pages.Mail
{
	public class ReadMessage : ContentPage
	{
		Label Date = new Label { BackgroundColor = Color.Black };
		Label From = new Label { BackgroundColor = Color.Black };
		Label To = new Label { BackgroundColor = Color.Black };
		Label Subject = new Label { BackgroundColor = Color.Black };
		Label Message = new Label { BackgroundColor = Color.Black };

		Button Reply = new Button 
		{ 
			TextColor = Color.Black,
			Text = "Reply"
		};
		Button Archive = new Button
		{
			TextColor = Color.Black,
			Text = "Archive"
		};
		Button Forward = new Button
		{
			TextColor = Color.Black,
			Text = "Forward"
		};
		Button Delete = new Button
		{
			TextColor = Color.Black,
			Text = "Delete"
		};
		
		public ReadMessage(string sessionID, string server, Messages message)
		{
			Date.Text = message.date;
			From.Text = message.from;
			To.Text = message.to;
			Subject.Text = message.subject;
			Message.Text = message.body;
			Content = new StackLayout
			{
				Children = {
					Date, From, To, Subject,
					new ScrollView{
						Content = Message,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                    },
					new StackLayout{
						
						Orientation = StackOrientation.Horizontal,
						Children = {Reply, Archive, Forward, Delete},
                        VerticalOptions = LayoutOptions.End, 
                        BackgroundColor = Color.Black
                    }
				}
			};

			Reply.Clicked += async (sender, e) =>{
				//await Navigation.PopAsync();
				await Navigation.PushAsync(new ComposeReply(sessionID, server, message, "Re: "));
			};
			Archive.Clicked += async (sender, e) => 
			{
				var json = Inbox.ArchiveMessages(1, sessionID, message.id);
				var s = new LacunaExpress.Data.Server();
				var response = await s.GetHttpResultAsync(server, Inbox.url, json);
				await Navigation.PopAsync();
			};
			Forward.Clicked += async (sender, e) => 
			{
				//await Navigation.PopAsync();
				await Navigation.PushAsync(new ComposeReply(sessionID, server, message, "Fw: "));
			};
			Delete.Clicked += async (sender, e) => {
				var json = Inbox.TrashMessages(1, sessionID, message.id);
				var s = new LacunaExpress.Data.Server();
				var response = await s.GetHttpResultAsync(server, Inbox.url, json);
				await Navigation.PopAsync();
			};
		}
	}
}
