#region Directives
using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using PagerAdapter = Android.Support.V4.View.PagerAdapter;
using _ViewPager = Android.Support.V4.View.ViewPager;
using _Fragment = Android.Support.V4.App.Fragment;
using _FragmentActivity = Android.Support.V4.App.FragmentActivity;
using _FragmentManager = Android.Support.V4.App.FragmentManager;
using _FragmentStatePagerAdapter = Android.Support.V4.App.FragmentStatePagerAdapter;
using _FragmentTransaction = Android.Support.V4.App.FragmentTransaction;
#endregion

namespace Ph.Mobext.Sureseats.AndroidApp
{
	[Activity (Label = "Ph.Mobext.Sureseats.AndroidApp")]
	public class BaseFragmentActivity : _FragmentActivity
	{
		#region Variable
		ImageView m_imgSearch;
		PagerAdapter mPagerAdapter;
		RelativeLayout m_relCheckIn, m_relMovie, m_relMyAccount, m_relPromos;	
		RelativeLayout m_relPrevious;
		RelativeLayout[] relCollection; 
		TextView m_tvBackButton, m_tvScreenTitle;	
		_ViewPager mPager;

		int[] m_intNormal = new int[]{
			Resource.Drawable.ic_movie_normal,
			Resource.Drawable.ic_check_in_normal,
			Resource.Drawable.ic_account_normal,
			Resource.Drawable.ic_star_normal
		};

		int[] m_intPressed = new int[]{
			Resource.Drawable.ic_movie_pressed,
			Resource.Drawable.ic_check_in_pressed,
			Resource.Drawable.ic_account_pressed,
			Resource.Drawable.ic_star_pressed
		};

		bool m_isHome;
		protected FrameLayout FrameLayoutContainer;
		protected _FragmentTransaction FTran;
		//protected int 
		#endregion



		#region Properties
		protected  ImageView ImgSearchButton {
			get { return m_imgSearch;}
		}

		public  RelativeLayout RlCheckInButton {
			get { return m_relCheckIn;}
		}

		public  RelativeLayout RlMovieButton {
			get { return m_relMovie;}
		}

		public  RelativeLayout RlMyAccountButton {
			get { return m_relMyAccount;}
		}

		public  RelativeLayout RlPromos {
			get { return m_relPromos;}
		}

		protected  TextView TvBackButton {
			get { return m_tvBackButton;}
		}

		protected  TextView TvScreenTitle{ 
			get{return m_tvScreenTitle;}
		}
		#endregion

		#region Events
		
		protected override void OnCreate (Bundle bundle) {
			RequestWindowFeature (WindowFeatures.NoTitle);
			RequestedOrientation = global::Android.Content.PM.ScreenOrientation.Nosensor;
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Activity_MasterPage);
			FrameLayoutContainer = FindViewById<FrameLayout> (Resource.Id.Master_fraContent);
			RunOnUiThread(() =>Init ());

			FTran = this.SupportFragmentManager.BeginTransaction ();
			FTran.SetCustomAnimations (Resource.Animation.fade_in, Resource.Animation.fade_out);
		}

		/// <summary>
		/// Click event for the buttons (relativelayout)
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		protected virtual void On_MenuClick(object sender, EventArgs e) {

			RelativeLayout relSender = (sender as RelativeLayout);

			if (relSender == m_relPrevious) 
				return;

			FrameLayoutContainer.RemoveAllViews ();

			Reset ();

			relSender.SetBackgroundResource (m_intPressed [(int)relSender.Tag]);

			m_relPrevious = relSender;



			if (relSender == m_relMovie) {

				FTran.Replace(Resource.Id.Master_fraContent, new Frag_MovieScrollHome());
				FTran.AddToBackStack (null);
				FTran.Commit ();

				TvBackButton.Visibility = ViewStates.Invisible;
			} else if (relSender == m_relCheckIn) {
				FTran.Replace (Resource.Id.Master_fraContent, new Frag_CheckIn ());
			} else if (relSender == m_relMyAccount) {
				//fTransaction.Replace (Resource.Id.Master_fraContent, new Frag_MyAccount ());
			} else if (relSender == m_relPromos) {
				//fTransaction.Replace (Resource.Id.Master_fraContent, new TestFragment2());
			} else
				Toast.MakeText (this, "Error", ToastLength.Short).Show ();

			relSender = null;
			FTran = null;
		}


		protected override void OnDestroy ()
		{
			System.GC.Collect ();
			base.OnDestroy ();
		}
		#endregion

		#region Protected Methods
		/// <summary>
		/// Formats the textview or edittext parameter
		/// </summary>
		/// <param name="text">Text.</param>
		/// <param name="size">Size.</param>
		/// <param name="color">Color.</param>
		/// <param name="fontFamily">Font family.</param>
		/// <param name="style">Style.</param>
		protected void TextFormatter(object text, float size, Color color, string fontFamily, TypefaceStyle style)
		{
			if (text is TextView) {
				(text as TextView).SetTextSize (ComplexUnitType.Dip, size);
				(text as TextView).SetTextColor (color);
				(text as TextView).Typeface = Typeface.Create (fontFamily, style);
			} 
			else if (text is EditText) {
				(text as EditText).SetTextSize (ComplexUnitType.Dip, size);
				(text as EditText).SetTextColor (color);
				(text as EditText).Typeface = Typeface.Create (fontFamily, style);
			}
		}


		/// <summary>
		/// Initialize components and variables.
		/// </summary>
		protected virtual void Init() {
			string font = "Droid Sans";
			m_imgSearch = FindViewById<ImageView> (Resource.Id.Master_imgSearch);

			m_relMovie = FindViewById<RelativeLayout> (Resource.Id.Master_relMovie);
			m_relCheckIn = FindViewById<RelativeLayout> (Resource.Id.Master_relCheckIn);
			m_relMyAccount = FindViewById<RelativeLayout> (Resource.Id.Master_relMyAccount);
			m_relPromos = FindViewById<RelativeLayout> (Resource.Id.Master_relPromos);

			var txtTitle = FindViewById<TextView> (Resource.Id.Master_tvHeaderTitle);
			TextFormatter (txtTitle, 24F, Color.DarkOrange, font + " Mono", TypefaceStyle.Normal);

			var txtMovie = FindViewById<TextView> (Resource.Id.Master_tvMovie);
			TextFormatter (txtMovie, 12F, Color.Silver, font, TypefaceStyle.Bold);

			var txtCheckIn = FindViewById<TextView> (Resource.Id.Master_tvCheckIn);
			TextFormatter (txtCheckIn, 12F, Color.Silver, font, TypefaceStyle.Bold);

			var txtMyAccount = FindViewById<TextView> (Resource.Id.Master_tvMyAccount);
			TextFormatter (txtMyAccount, 12F, Color.Silver, font, TypefaceStyle.Bold);

			var txtPromos = FindViewById<TextView> (Resource.Id.Master_tvPromos);
			TextFormatter (txtPromos, 12F, Color.Silver, font, TypefaceStyle.Bold);		

			m_tvBackButton = FindViewById<TextView> (Resource.Id.Master_tvBackNavi);
			TextFormatter (m_tvBackButton, 16F, Color.White, font, TypefaceStyle.Bold);

			m_tvScreenTitle = FindViewById<TextView> (Resource.Id.Master_tvScreenTitle);
			TextFormatter (m_tvScreenTitle, 18F, Color.SlateGray, font, TypefaceStyle.Bold);

			m_relMovie.Click += On_MenuClick;
			m_relMovie.Tag = 0;

			m_relCheckIn.Click += On_MenuClick;
			m_relCheckIn.Tag = 1;

			m_relMyAccount.Click += On_MenuClick;
			m_relMyAccount.Tag = 2;

			m_relPromos.Click += On_MenuClick;
			m_relPromos.Tag = 3;
			Reset ();
		}

		/// <summary>
		/// Reset this instance.
		/// </summary>
		protected virtual void Reset() {
			relCollection = new RelativeLayout[] { RlMovieButton,RlCheckInButton,RlMyAccountButton,RlPromos };
			for (int i = 0; i < relCollection.Length; i++) {
				RunOnUiThread (() => relCollection [i].SetBackgroundResource (m_intNormal [i]));				
			}
		}

		/// <summary>
		/// Nullifies all.
		/// </summary>
		protected virtual void NullifyAll()
		{
			m_imgSearch = null;
			m_intNormal = null;
			m_intPressed = null;
			m_relCheckIn = null;
			m_relMovie = null;
			m_relMyAccount = null;
			m_relPrevious = null;
			m_relPromos = null;
			m_tvBackButton = null;
			m_tvScreenTitle = null;
			FrameLayoutContainer = null;
			mPager = null;
			mPagerAdapter = null;
			relCollection = null;
		}
		#endregion

	}
}


