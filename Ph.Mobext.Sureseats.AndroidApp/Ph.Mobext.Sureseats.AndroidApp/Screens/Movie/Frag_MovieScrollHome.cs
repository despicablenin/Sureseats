#region Directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
#endregion

namespace Ph.Mobext.Sureseats.AndroidApp
{
	public class Frag_MovieScrollHome : Frag_Base
	{
		#region Variables
		View m_vwView;
		LinearLayout m_linHorizontalLayout;

		int m_intMin = 0;
		int m_intMax;
		#endregion

		#region Events

		#region Overriden
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
			m_vwView = inflater.Inflate (Resource.Layout.Frag_MovieScrollHome, null);

			m_vwView.SetBackgroundDrawable (
				new global::Android.Graphics.Drawables.BitmapDrawable (
					Ph.Mobext.Sureseats.AndroidApp.BmpFactory.Singleton.DecodeSampledBitmapFromResource (
						Activity.Resources,
						Resource.Drawable.bg_body,
						m_vwView.Width,
						m_vwView.Height)));

			m_linHorizontalLayout = m_vwView.FindViewById<LinearLayout>(Resource.Id.MovieScrollHome_linLayout);
			m_intMax = 10;
			Init (); //must be preceded by the assigning of View to avoid error. :D
			return m_vwView;
		}

		public override void OnLowMemory ()
		{
			this.Dispose ();
		}

		public override void OnDestroyView ()
		{
			base.OnDestroyView ();
			m_vwView.Dispose ();
			m_linHorizontalLayout.Dispose ();
			this.Dispose ();
		}
	
		#endregion

		#endregion

		#region Methods / Functions
		/// <summary>
		/// Init this instance.
		/// </summary>
		public void Init() {
			var tvDate = m_vwView.FindViewById<TextView> (Resource.Id.MovieScrollHome_tvDate);
			TextFormatter (tvDate, 18F, global::Android.Graphics.Color.Black, "Droid Sans", global::Android.Graphics.TypefaceStyle.Bold);
			tvDate.Gravity = GravityFlags.Center;

			LinearLayout.LayoutParams paramsTvDate =
				new LinearLayout.LayoutParams (
					ViewGroup.LayoutParams.FillParent,
					ViewGroup.LayoutParams.WrapContent);
			tvDate.LayoutParameters = paramsTvDate;

			var imgLeft = m_vwView.FindViewById<ImageView> (Resource.Id.MovieScrollHome_imgLeft);
			imgLeft.SetImageBitmap (
				new Android.Graphics.Drawables.BitmapDrawable (
					BmpFactory.Singleton.DecodeSampledBitmapFromResource (
						m_vwView.Resources,
						Resource.Drawable.ic_left,
						24, 24))
				.Bitmap);
			//imgLeft.SetImageBitmap(Android.Graphics.BitmapFactory.DecodeResource(m_vwView.Resources, Resource.Drawable.ic_left));

			var imgRight = m_vwView.FindViewById<ImageView> (Resource.Id.MovieScrollHome_imgRight);
			imgRight.SetImageBitmap (
					new Android.Graphics.Drawables.BitmapDrawable (
						BmpFactory.Singleton.DecodeSampledBitmapFromResource (
							m_vwView.Resources,
						Resource.Drawable.ic_right,
						24, 24))
				.Bitmap);
			//imgRight.SetImageBitmap(Android.Graphics.BitmapFactory.DecodeResource(m_vwView.Resources, Resource.Drawable.ic_right));

			//tvDate.SetPadding (0, 0, 0, -20);
			int[] resourceIds = new int[] {
				Resource.Drawable.img_IronMan3,
				Resource.Drawable.img_Oz,
				Resource.Drawable.img_AfterEarth,
				Resource.Drawable.img_Gijoe
			  };

			for (int i = m_intMin; i < m_intMax; i++) {
				MovieItem item = new MovieItem (Activity, "Testing", Resource.Drawable.dude, "Movie #" + i.ToString (), i * new Random ().Next (1000, 2000) + new Random ().Next (0, 99));
				LinearLayout linItem = 	item.GetItem ();
				linItem.Click += item.ItemClick;
				m_linHorizontalLayout.AddView (linItem);
			}
			resourceIds = null;

		}

		/// <summary>
		/// Gets the previous.
		/// </summary>
		private void GetPrevious(){
			//TODO: Navigation of screen
		}

		/// <summary>
		/// Gets the next.
		/// </summary>
		private void GetNext(){
			//TODO: Navigation of screen
		}


		#endregion
	}
}