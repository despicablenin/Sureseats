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
	public class Frag_LogInOne : Frag_Base
	{
		#region Variables
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

		/// <param name="inflater">The LayoutInflater object that can be used to inflate
		///  any views in the fragment,</param>
		/// <param name="container">If non-null, this is the parent view that the fragment's
		///  UI should be attached to. The fragment should not add the view itself,
		///  but this can be used to generate the LayoutParams of the view.</param>
		/// <param name="savedInstanceState">If non-null, this fragment is being re-constructed
		///  from a previous saved state as given here.</param>
		/// <summary>
		/// Called to have the fragment instantiate its user interface view.
		/// </summary>
		/// <returns>To be added.</returns>
		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			mView = inflater.Inflate (Resource.Layout.Frag_LogIn_One, null);
			//return base.OnCreateView (inflater, container, savedInstanceState);
			Init ();
			return mView;
		}
		
		#endregion

		#region Methods
		private void Init() {
			string font = "Droid Sans";
			var etEmailAddress = mView.FindViewById<EditText> (Resource.Id.LogInOne_etEmailAddress);
			TextFormatter (etEmailAddress, 18F, Color.DarkOrange, font, TypefaceStyle.Italic);
			etEmailAddress.InputType = global::Android.Text.InputTypes.TextVariationPassword;
			etEmailAddress.SetHintTextColor (Color.Silver);

			var etPassword = mView.FindViewById<EditText> (Resource.Id.LogInOne_etPassword);
			TextFormatter (etPassword, 18F, Color.DarkOrange, font, TypefaceStyle.Italic);
			etPassword.InputType = global::Android.Text.InputTypes.TextVariationPassword;
			etPassword.SetHintTextColor (Color.Silver);


			var tvLogIn = mView.FindViewById<TextView> (Resource.Id.LogInOne_tvLogIn);
			TextFormatter (tvLogIn, 22F, Color.White, font, TypefaceStyle.Bold);

			tvLogIn.Click += (sender, e) => {
				Context context = Activity;
				var intent = new Intent(context, typeof(Act_HomePage));

				Activity.Finish();
				StartActivity(intent);
				Activity.OverridePendingTransition(0,Resource.Animation.slide_left);
			};
		}
		#endregion
	}
}

