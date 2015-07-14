using System;
using Android.App;
using Android.Content.PM;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using LacunaExpress;

namespace LacunaExpressTest
{
	//[Activity(Label = "LacunaExpressTest", MainLauncher = true, Icon = "@drawable/icon")]
	[Activity(Label = "LacunaExpress", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]

	//public class MainActivity : Activity
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		int count = 1;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new App());

			// Set our view from the "main" layout resource
			//SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			//Button button = FindViewById<Button>(Resource.Id.MyButton);

			//.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
		}
	}
}

