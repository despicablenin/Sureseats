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
	public class Frag_MovieTermsAndCondition : Frag_Base
	{
		#region Variables
		LinearLayout m_linBase;
		TextView m_tvConfirmationCode, m_tvMovieTitle, m_tvMTRCBRating;

		TextView m_tvTheaterValue, m_tvCinemaValue, m_tvScheduleDateValue, m_tvTimeValue, m_tvSeatingValue, m_tvTicketPriceValue;
		TextView m_tvQuantityValue, m_tvWebAdminFeeValue, m_tvTotalAmountDueValue, m_tvSeatNumbersValue, m_tvSourceValue, m_tvStatusValue;
		TextView m_tvTransactionNumberValue, m_tvTransactionDateValue, m_tvPaidViaCreditCardValue, m_tvNameOnCardValue;
		TextView m_tvTermsAndCondition;

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
			//base.OnCreateView (inflater, container, savedInstanceState);
			m_vwView = inflater.Inflate (Resource.Layout.Frag_MovieTermsAndCondition, null);
			m_linBase = (LinearLayout)m_vwView.FindViewById (Resource.Id.MTandC_linBase);
			Init ();
			return m_vwView;
		}
		
		#endregion

		#region Methods
		/// <summary>
		/// Init this instance.
		/// </summary>
		private void Init() {
			string font = "Droid Sans";

			LayoutInflater inflater = (LayoutInflater)Activity.GetSystemService (Context.LayoutInflaterService);
			inflater.Inflate (Resource.Layout.Frag_MovieTermsAndConditionDetail, m_linBase);

			#region Master
			m_tvConfirmationCode = m_vwView.FindViewById<TextView> (Resource.Id.MTandC_tvConfirmationCode);
			TextFormatter (m_tvConfirmationCode, 12F, Color.Black, font, TypefaceStyle.Bold);

			m_tvMovieTitle = m_vwView.FindViewById<TextView> (Resource.Id.MTandC_tvMovieTitle);
			TextFormatter (m_tvMovieTitle, 12F, Color.Black, font, TypefaceStyle.Bold);

			m_tvMTRCBRating = m_vwView.FindViewById<TextView> (Resource.Id.MTandC_tvMTRCB);
			TextFormatter (m_tvMTRCBRating, 12F, Color.White, font, TypefaceStyle.Bold);
			#endregion

			#region Details
			var tvTheater = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvTheater);
			m_tvTheaterValue = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvTheaterValue);

			var tvCinema = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvCinema);
			m_tvCinemaValue = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvCinemaValue);

			var tvScheduleDate = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvScheduleDate);
			m_tvScheduleDateValue = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvScheduleValue);

			var tvTime = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvTime);
			m_tvTimeValue = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvTimeValue);

			var tvSeating = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvSeating);
			m_tvSeatingValue = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvSeatingValue);

			var tvTicketPrice = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvTicketPrice);
			m_tvTicketPriceValue = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvTicketPriceValue);

			var tvQuantity = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvQuantity);
			m_tvQuantityValue = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvQuantityValue);

			var tvWebAdminFee = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvWebAdminFee);
			m_tvWebAdminFeeValue = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvWebAdminFeeValue);

			var tvTotalAmountDue = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvTotalAmountDue);
			m_tvTotalAmountDueValue = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvTotalAmountDueValue);

			var tvSeatNumbers = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvSeatNos);
			m_tvSeatNumbersValue = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvSeatNosValue);

			var tvSource = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvSource);
			m_tvSourceValue = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvSourceValue);

			var tvStatus = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvStatus);
			m_tvStatusValue = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvStatusValue);

			var tvTransactionNumber = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvTransactionNumber);
			m_tvTransactionNumberValue = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvTransactionNumberValue);

			var tvTransactionDate = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvTransactionDate);
			m_tvTransactionDateValue = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvTransactionDateValue);

			var tvPaidViaCreditCard = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvPaidViaCreditCard);
			m_tvPaidViaCreditCardValue = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvPaidViaCreditCard);

			var tvNameOnCard = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvNameOnCard);
			m_tvNameOnCardValue = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvNameOnCardValue);
			#endregion

			m_tvTermsAndCondition = m_vwView.FindViewById<TextView> (Resource.Id.MTandCDetail_tvTermAndCondition);
			TextFormatter (m_tvTermsAndCondition, 16F, Color.White, font, TypefaceStyle.Bold);

			List<TextView> lstDetails = new List<TextView> ();
			lstDetails.AddRange (
				new TextView[] {
					tvTheater, tvCinema, tvScheduleDate, tvTime, tvSeating, tvTicketPrice,	
					tvQuantity, tvWebAdminFee, tvTotalAmountDue, tvSeatNumbers, tvSource, 
					tvStatus, tvTransactionNumber, tvTransactionDate, tvPaidViaCreditCard, tvNameOnCard,
					m_tvTheaterValue, m_tvCinemaValue, m_tvScheduleDateValue, m_tvTimeValue, m_tvSeatingValue, 
					m_tvTicketPriceValue, m_tvQuantityValue, m_tvWebAdminFeeValue, m_tvTotalAmountDueValue, 
					m_tvSeatNumbersValue, m_tvSourceValue, m_tvStatusValue, m_tvTransactionNumberValue, 
					m_tvTransactionDateValue, m_tvPaidViaCreditCardValue, m_tvNameOnCardValue
				});

			foreach (var t in lstDetails) {
				TextFormatter (t, 12F, Color.Black, font, TypefaceStyle.Normal);
			}

		}
		#endregion
	}
}

