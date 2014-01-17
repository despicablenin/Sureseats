#region Directives
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;

using Android.Widget;
using _Fragment = Android.Support.V4.App.Fragment;
using _FragmentActivity = Android.Support.V4.App.FragmentActivity;
using _FragmentManager = Android.Support.V4.App.FragmentManager;
using _FragmentStatePagerAdapter = Android.Support.V4.App.FragmentStatePagerAdapter;
using _FragmentTransaction = Android.Support.V4.App.FragmentTransaction;
using PagerAdapter = Android.Support.V4.View.PagerAdapter;
using ViewPager = Android.Support.V4.View.ViewPager;
#endregion

namespace Ph.Mobext.Sureseats.AndroidApp
{
	[Activity (Label = "Act_BuyMovieTicket")]			
	public class Act_BuyMovieTicket : Act_HomePage
	{
		#region Events
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			RlMovieButton.SetBackgroundResource (Resource.Drawable.ic_movie_pressed);

			_FragmentTransaction ftran = this.SupportFragmentManager.BeginTransaction ();
			ftran.SetCustomAnimations (Resource.Animation.fade_in, Resource.Animation.fade_out);
			ftran.Replace (Resource.Id.Master_fraContent, new Frag_MovieBuyTicket());
			ftran.Commit ();
		}

		protected override void On_MenuClick (object sender, EventArgs e)
		{
			base.On_MenuClick (sender, e);
		}

		public override void OnBackPressed ()
		{
			var intent = new Intent (this, typeof(Act_HomePage));
			intent.PutExtra ("caller", "MoviesHome");
			StartActivity (intent);
			this.Finish ();
			OverridePendingTransition (0, 0);
		}
	
		#endregion

		#region Methods
		protected override void Reset ()
		{
			base.Reset ();
		}

		protected override void Init ()
		{
			base.Init ();
		}
		#endregion
	}
}

