#region Directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using _FragmentManager = Android.Support.V4.App.FragmentManager;
using _FragmentTransaction = Android.Support.V4.App.FragmentTransaction;
using _FragmentActivity = Android.Support.V4.App.FragmentActivity;
#endregion

namespace Ph.Mobext.Sureseats.AndroidApp
{
	[Activity (Label = "LogInPage", MainLauncher = true)]			
	public class Act_LogInPage : BaseFragmentActivity
	{
		#region Variables
		bool sessionExists; //temporary lang to
		//FrameLayout ContentPlaceHolder;
		#endregion

		#region Events

		/// <summary>
		/// Raises the create event.
		/// </summary>
		/// <param name="bundle">Bundle.</param>
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			RequestedOrientation = global::Android.Content.PM.ScreenOrientation.Nosensor;
			SetContentView (Resource.Layout.Activity_LoginMasterPage);
			//ContentPlaceHolder = FindViewById<FrameLayout> (Resource.Id.LoginMaster_fraContent);
			RunOnUiThread(()=> Init ());

			_FragmentTransaction fragmentTransaction = this.SupportFragmentManager.BeginTransaction ();

			//RunOnUiThread(()=> { 
				if (sessionExists) {
					fragmentTransaction.Replace (Resource.Id.LoginMaster_fraContent, new Frag_LogInOne ());
					fragmentTransaction.Commit ();				
				}
				else {
					fragmentTransaction.Replace (Resource.Id.LoginMaster_fraContent, new Frag_LogInTwo ());
					fragmentTransaction.Commit ();
				}
				fragmentTransaction = null;
			//});
		}

		public override void OnBackPressed ()
		{
			base.OnBackPressed ();
			//Finish ();
		}

		protected override void On_MenuClick (object sender, EventArgs e)
		{
			//base.On_MenuClick (sender, e);
		}
		#endregion

		#region Methods
		protected override void Init() {
			string font = "Droid Sans";
			var tvTitle = FindViewById<TextView> (Resource.Id.LoginMaster_Title);
			TextFormatter (tvTitle, 48F, Color.DarkOrange, font, TypefaceStyle.Normal);

			var tvStillDontHaveAnAccount = FindViewById<TextView> (Resource.Id.LoginMaster_tvStillDontHaveAnAccount);
			TextFormatter (tvStillDontHaveAnAccount, 14F, Color.Black, font + " Mono", TypefaceStyle.Normal);

			var tvRegister = FindViewById<TextView> (Resource.Id.LoginMaster_tvRegister);
			TextFormatter (tvRegister, 18F, Color.White, font, TypefaceStyle.Normal);


			var tvHelp = FindViewById<TextView> (Resource.Id.LoginMaster_tvHelp);
			TextFormatter (tvHelp, 14F, Color.Black, font + " Mono", TypefaceStyle.Normal);

			var tvDiv = FindViewById<TextView> (Resource.Id.LoginMaster_tvDiv);
			TextFormatter (tvDiv, 14F, Color.Black, font + " Mono", TypefaceStyle.Normal);

			var tvContactUs = FindViewById<TextView> (Resource.Id.LoginMaster_tvContactUs);
			TextFormatter (tvContactUs, 14F, Color.Black, font + " Mono", TypefaceStyle.Normal);
		}			

		protected override void Reset ()
		{
			//base.Reset ();
		}
		#endregion
	}
}

