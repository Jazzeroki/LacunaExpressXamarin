using LacunaExpanseAPIWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;

namespace LacunaExpress.Pages.Mail
{
	public class ComposeReply : ContentPage
	{
		AccountManagement.AccountModel account;
		Response.Messages message;

		Entry to = new Entry() { Placeholder = "To"};
		Entry subject = new Entry() { 
		Placeholder = "Subject"};
		Editor body = new Editor()
		{
			VerticalOptions = LayoutOptions.FillAndExpand
		};
		Button send = new Button
		
		{
			Text = "Send"
		};
		Button cancel = new Button
		{
			Text = "Cancel"
		};
		public ComposeReply(AccountManagement.AccountModel account)
		{
			this.account = account;
			to.Placeholder = "To";
			subject.Placeholder = "Subject";
			BuildPage();
		}
		public ComposeReply(string sessionID, string server, Response.Messages message, string type)
		{
			this.message = message;

			to.Text = message.to;
			subject.Text = type + message.subject;
			body.Text = message.body;
			BuildPage();
		}
		private void BuildPage()
		{
			Content = new StackLayout
			{
				Children = {
					to,
					subject,
					body,
					send,
					cancel
				}
			};
			send.Clicked += async (sender, e) =>
			{
				var json = Inbox.SendMessage(1, account.SessionID, to.Text, subject.Text, body.Text); 
				var s = new LacunaExpress.Data.Server();
				var response = await s.GetHttpResultAsync(account.Server, Inbox.url, json);
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
