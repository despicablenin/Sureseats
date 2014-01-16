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
	public class Frag_PromoDetail : Frag_Base
	{
		#region Variables
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

		}
		#endregion
	}
}

