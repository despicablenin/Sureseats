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
	public class Frag_MovieBuyTicketDetail : Frag_MovieBuyTicket
	{
		#region Variable
		LinearLayout[] linButtonHolder;
		LinearLayout[] linContent;
		TextView[] linButton;
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
		public override View OnCreateView (LayoutInflater pInflater, ViewGroup pContainer, Bundle pSavedInstanceState)
		{

			LayoutInflater inflater = (LayoutInflater)Activity.GetSystemService (Context.LayoutInflaterService);
			//inflater.Inflate (Resource.Layout.Frag_MovieDetailScreen, base.mFraBase);
			//Init ();
			return OnCreateView (pInflater, pContainer, pSavedInstanceState);
		}


		/// <summary>
		/// Initializes value
		/// </summary>
		private void Init () {
			linContent = new LinearLayout[] { 
				this.View.FindViewById<LinearLayout> (Resource.Id.BTD_linDetailContent),
				this.View.FindViewById<LinearLayout> (Resource.Id.BTD_linScheduleContent),
				this.View.FindViewById<LinearLayout> (Resource.Id.BTD_linTrailerContent)
			};

			linButtonHolder = new LinearLayout[] { 
				this.View.FindViewById<LinearLayout> (Resource.Id.BTD_linDetail),
				this.View.FindViewById<LinearLayout> (Resource.Id.BTD_linSchedule),
				this.View.FindViewById<LinearLayout> (Resource.Id.BTD_linTrailer)
			};

			linButton = new TextView[] { 
				this.View.FindViewById<TextView> (Resource.Id.BTD_txtDetail),
				this.View.FindViewById<TextView> (Resource.Id.BTD_txtSchedule),
				this.View.FindViewById<TextView> (Resource.Id.BTD_txtTrailer)
			};

			var detailView = this.View.FindViewById<LinearLayout> (Resource.Id.BTD_linDetailContent);		
			var scheduleView = this.View.FindViewById<LinearLayout> (Resource.Id.BTD_linScheduleContent);
			var trailerView = this.View.FindViewById<LinearLayout> (Resource.Id.BTD_linTrailerContent);

			foreach (TextView l in linButton) {
				l.Click += OnClick;
			}


			Reset ();
			//makes sure the first tab is selected
			linButtonHolder [0].SetBackgroundColor (Color.Orange);
			linButton [0].SetTextColor (Color.White);
			linContent [0].Visibility = ViewStates.Visible;
		}

		/// <summary>
		/// Reset tab controls to their initial state
		/// </summary>
		private void Reset() {
			foreach (var l in linButtonHolder) {
				l.SetBackgroundColor (Color.Silver);
			}

			foreach (var l in linContent) {
				l.Visibility = ViewStates.Invisible;
			}

			foreach (var l in linButton) {
				TextFormatter (l, 16F, Color.DarkGray, "OpenSans", TypefaceStyle.Bold);
			}
		}

		#region Events
		/// <summary>
		/// Raises the click event of textview (tabcontrols)
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void OnClick(object sender, EventArgs e) {
			Reset ();

			TextView textView = (sender as TextView);
			textView.SetTextColor (Color.White);

			if (textView == linButton [0]) {
				linContent [0].Visibility = ViewStates.Visible;
				linButtonHolder [0].SetBackgroundColor (Color.Orange);
			} 
			else if (textView == linButton [1]) {
				linContent [1].Visibility = ViewStates.Visible;
				linButtonHolder [1].SetBackgroundColor (Color.Orange);
			} 
			else if (textView == linButton [2]) {
				linContent [2].Visibility = ViewStates.Visible;
				linButtonHolder [2].SetBackgroundColor (Color.Orange);
			}
		}
		#endregion


		#endregion
	}
}

