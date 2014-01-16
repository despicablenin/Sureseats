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
using Android.Graphics;
#endregion

namespace Ph.Mobext.Sureseats.AndroidApp
{
	public class Frag_MovieBuyTicket : Frag_Movie_Base
	{
		#region Variables
		LinearLayout[] m_linButtonHolder;
		LinearLayout[] m_linContent;
		TextView[] m_linButton;
		View mv_View;

		//protected FrameLayout mFraBase;
		#endregion

		#region Events

		#region Override
		/// <param name="savedInstanceState">If the fragment is being re-created from
		///  a previous saved state, this is the state.</param>
		/// <summary>
		/// Called to do initial creation of a fragment.
		/// </summary>
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
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
			mv_View = inflater.Inflate (Resource.Layout.Frag_MovieTicket, null);
			Init (); //must be preceded by the assigning of View to avoid error. :D
			return mv_View;
		}


		public override void OnDestroyView ()
		{
			base.OnDestroyView ();
			mv_View = null;
		}
		#endregion

		#region Private
		/// <summary>
		/// Raises the click event of textview (tabcontrols)
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void OnClick(object sender, EventArgs e) {
			Reset ();
			int tag = (int)(sender as TextView).Tag;

			m_linButton [tag].SetTextColor (Color.White);
			m_linContent [tag].Visibility = ViewStates.Visible;
			m_linButtonHolder [tag].SetBackgroundResource (Resource.Drawable.bg_xml_normal_border_orange);
		}
		#endregion


		#endregion

		#region Private Methods
		/// <summary>
		/// Init this instance.
		/// </summary>
		private void Init() {
			string font = "Droid Sans";

			var tvMovieDisplayTitle = mv_View.FindViewById<TextView> (Resource.Id.MT_tvMovieDisplayTitle);
			TextFormatter (tvMovieDisplayTitle, 20F, Color.Orange, font, TypefaceStyle.Bold);

			var tvUserRating = mv_View.FindViewById<TextView> (Resource.Id.MT_tvUserRating);
			TextFormatter (tvUserRating, 10F, Color.Black, font, TypefaceStyle.Normal);

			var tvMiscDetails = mv_View.FindViewById<TextView> (Resource.Id.MT_tvMiscDetails);
			TextFormatter (tvMiscDetails, 10F, Color.Black, font, TypefaceStyle.Normal);

			var tvBuyTicket = mv_View.FindViewById<TextView> (Resource.Id.MT_tvBuyTicket);
			TextFormatter (tvBuyTicket, 16F, Color.White, font, TypefaceStyle.Bold);

			var tvMTRCBRating = mv_View.FindViewById<TextView> (Resource.Id.MT_tvMTRCBRating);
			TextFormatter (tvMTRCBRating, 12F, Color.White, font, TypefaceStyle.Bold);

			tvMTRCBRating.Click += (sender, e) => {
				MyDialog.Prompt.RatingDialog( Activity, "G", 
					"General Patronage", "TEST DATA TEST DATA TEST DATA TEST DATA TEST DATA").Show();
			};

			m_linContent = new LinearLayout[] { 
				mv_View.FindViewById<LinearLayout> (Resource.Id.MT_linDetailContent),
				mv_View.FindViewById<LinearLayout> (Resource.Id.MT_linScheduleContent),
				mv_View.FindViewById<LinearLayout> (Resource.Id.MT_linTrailerContent)
			};

			m_linButtonHolder = new LinearLayout[] { 
				mv_View.FindViewById<LinearLayout> (Resource.Id.MT_linDetail),
				mv_View.FindViewById<LinearLayout> (Resource.Id.MT_linSchedule),
				mv_View.FindViewById<LinearLayout> (Resource.Id.MT_linTrailer)
			};

			m_linButton = new TextView[] { 
				mv_View.FindViewById<TextView> (Resource.Id.MT_tvDetail),
				mv_View.FindViewById<TextView> (Resource.Id.MT_tvSchedule),
				mv_View.FindViewById<TextView> (Resource.Id.MT_tvTrailer)
			};

			var detailView = mv_View.FindViewById<LinearLayout> (Resource.Id.MT_linDetailContent);		
			var scheduleView = mv_View.FindViewById<LinearLayout> (Resource.Id.MT_linScheduleContent);
			var trailerView = mv_View.FindViewById<LinearLayout> (Resource.Id.MT_linTrailerContent);

			Reset ();

			foreach (TextView l in m_linButton) {
				l.Click += OnClick;
			}

			//makes sure the first tab is selected
			m_linButtonHolder [0].SetBackgroundResource (Resource.Drawable.bg_xml_normal_border_orange);
			m_linButton [0].SetTextColor (Color.White);
			m_linContent [0].Visibility = ViewStates.Visible;
		}

		/// <summary>
		/// Reset tab controls to their initial state
		/// </summary>
		private void Reset() {
			for (int i = 0; i < m_linButtonHolder.Length; i++) {
				m_linButton [i].Tag = i;
				m_linButtonHolder[i].SetBackgroundResource (Resource.Drawable.bg_xml_normal_border_silver);
				m_linContent[i].Visibility = ViewStates.Invisible;
				TextFormatter (m_linButton [i], 14F, Color.DarkGray, "Droid Sans", TypefaceStyle.Bold);
			}
		}		
		#endregion
	}
}

