#region Directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
#endregion

namespace Ph.Mobext.Sureseats.AndroidApp
{
	public class Frag_LogInTwo : Frag_Base
	{
		#region Variable
		View mView;
		#endregion

		#region Events
		/// <param name="savedInstanceState">If the fragment is being re-created from
		///  a previous saved state, this is the state.</param>
		/// <summary>
		/// Called to do initial creation of a fragment.
		/// </summary>
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
//			return base.OnCreateView (inflater, container, savedInstanceState);
			mView = inflater.Inflate (Resource.Layout.Frag_LogIn_Two, null);
			Init ();
			return mView;
		}
		#endregion

		#region Methods
		public void Init() {
			string font = "Droid Sans";
			var tvLoggedAs = mView.FindViewById<TextView> (Resource.Id.LogInTwo_tvLoggedAs);
			TextFormatter (tvLoggedAs, 16F, Color.DarkOrange, font + " Mono", TypefaceStyle.Bold);

			var tvContinue = mView.FindViewById<TextView> (Resource.Id.LogInTwo_tvContinue);
			TextFormatter (tvContinue, 22F, Color.White, font, TypefaceStyle.Bold);

			tvContinue.Click += (sender, e) => {
				var intent = new Intent(Activity, typeof(Act_HomePage));
				Activity.Finish();
				StartActivity(intent);
				Activity.OverridePendingTransition(0,Resource.Animation.slide_left);

			};

			var tvNotYou = mView.FindViewById<TextView> (Resource.Id.LogInOne_tvNotYou);
			TextFormatter (tvNotYou, 14F, Color.Black, font, TypefaceStyle.Normal);
		}
		#endregion
	}
}

