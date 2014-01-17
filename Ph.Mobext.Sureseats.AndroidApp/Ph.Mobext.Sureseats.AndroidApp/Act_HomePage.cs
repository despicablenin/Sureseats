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
	[Activity (Label = "Act_HomePage", MainLauncher = false)]
	public class Act_HomePage : BaseFragmentActivity
	{
		#region Variables
		string m_strCaller;
		#endregion


		#region Events
		/// <summary>
		/// Raises the create event.
		/// </summary>
		/// <param name="bundle">Bundle.</param>
		protected override void OnCreate (Bundle bundle) {
			base.OnCreate (bundle);
			Init ();
			Reset ();

			m_strCaller = Intent.GetStringExtra ("caller") ?? string.Empty;

			switch (m_strCaller) {
			case "MoviesHome":
				//from buy movie ticket back to scrollhome
				FTran.SetCustomAnimations (0,0);
				FTran.Replace (Resource.Id.Master_fraContent, new Frag_MovieScrollHome ());
				FTran.AddToBackStack (null);
				FTran.Commit ();
				//this.SupportFragmentManager.PopBackStackImmediate();
				//this.SupportFragmentManager.PopBackStack ();
				break;
			}
		}


		public override void OnBackPressed ()
		{
			//base.OnBackPressed ();
			var intent = new Intent (this, typeof(Act_LogInPage));
			this.Finish ();
			StartActivity (intent);
			OverridePendingTransition (0, Resource.Animation.slide_right);
		}

		protected override void On_MenuClick (object sender, EventArgs e)
		{
			base.On_MenuClick (sender, e);
		}

		#endregion    

		#region Methods
		protected override void Init ()
		{
			base.Init ();
		}

		protected override void Reset ()
		{
			base.Reset ();
		}
		#endregion
	}
}