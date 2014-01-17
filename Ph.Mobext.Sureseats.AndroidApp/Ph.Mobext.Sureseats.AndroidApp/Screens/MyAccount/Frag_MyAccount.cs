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
using Android.Views;
using Android.Widget;
#endregion

namespace Ph.Mobext.Sureseats.AndroidApp
{
	[Activity (Label = "Frag_MyAccount")]			
	public class Frag_MyAccount : Frag_Base
	{
		#region Variables
		TextView m_tvMovieTitle;
		TextView m_tvMTRCB, m_tvDurationAndGenre;
		TextView m_tvPurchasedTickets, m_tvPurchasedOn, m_tvTotalAmount;
		TextView m_tvCinemaAndDateTime;
		View m_vwView;
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
			m_vwView = inflater.Inflate (Resource.Layout.Frag_MyAcctTicketListItem, null);
			Init ();
			return m_vwView;
		}
		#endregion

		#region Methods
		/// <summary>
		/// 
		/// </summary>
		private void Init() {
			string font = "HelveticaNeue";

			m_tvMovieTitle = m_vwView.FindViewById<TextView> (Resource.Id.MLTI_tvMovieDisplayTitle);
			TextFormatter (m_tvMovieTitle, 16F, Color.Black, font, TypefaceStyle.Bold);

			m_tvMTRCB = m_vwView.FindViewById<TextView> (Resource.Id.MLTI_tvMTRCBRating);
			TextFormatter (m_tvMTRCB, 11F, Color.White, font, TypefaceStyle.Bold);

			m_tvDurationAndGenre = m_vwView.FindViewById<TextView> (Resource.Id.MLTI_tvDurationAndGenre);
			TextFormatter (m_tvDurationAndGenre, 11F, Color.Black, font, TypefaceStyle.Bold);

			var tvTransactionDetails = m_vwView.FindViewById<TextView> (Resource.Id.MLTI_tvTransactionDetail);
			TextFormatter (tvTransactionDetails, 11F, Color.Black, font, TypefaceStyle.Bold);

			m_tvPurchasedTickets = m_vwView.FindViewById<TextView> (Resource.Id.MLTI_tvPurchasedTickets);
			TextFormatter (m_tvPurchasedTickets, 11F, Color.Orange, font, TypefaceStyle.Normal);

			m_tvPurchasedOn = m_vwView.FindViewById<TextView> (Resource.Id.MLTI_tvPurchasedOn);
			TextFormatter (m_tvPurchasedOn, 11F, Color.Black, font, TypefaceStyle.Normal);

			m_tvTotalAmount = m_vwView.FindViewById<TextView> (Resource.Id.MLTI_tvTotalAmount);
			TextFormatter (m_tvTotalAmount, 11F, Color.Black, font, TypefaceStyle.Normal);

			var tvMovieScreening = m_vwView.FindViewById<TextView> (Resource.Id.MLTI_tvMovieScreening);
			TextFormatter (tvMovieScreening, 11F, Color.Black, font, TypefaceStyle.Bold);

			m_tvCinemaAndDateTime = m_vwView.FindViewById<TextView> (Resource.Id.MLTI_tvCinemaAndDateTime);
			TextFormatter (m_tvCinemaAndDateTime, 11F, Color.Black, font, TypefaceStyle.Normal);

			var tvSwipeToSeeCode = m_vwView.FindViewById<TextView> (Resource.Id.MLTI_tvSwipeToSeeQrCode);
			TextFormatter (tvSwipeToSeeCode, 11F, Color.Black, font, TypefaceStyle.Italic);
		}
		#endregion
	}
}

