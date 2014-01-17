#region Directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using FragmentActivity = Android.Support.V4.App.FragmentActivity;
using ViewPager = Android.Support.V4.View.ViewPager;
using PagerAdapter = Android.Support.V4.View.PagerAdapter;
using FragmentStatePagerAdapter = Android.Support.V4.App.FragmentStatePagerAdapter;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;
#endregion

namespace Ph.Mobext.Sureseats.AndroidApp
{
	public class ScreenSlidePagerAdapter : FragmentStatePagerAdapter {
		#region Variables
		List<Fragment> m_lstFragmentList;

		#endregion

		#region Properties
		public int NumberOfPages { 
			get {			
				if (m_lstFragmentList == null)
					return 0;
				if (m_lstFragmentList.Count == 0)
					return 0;
				return m_lstFragmentList.Count;
			}
		}
		#endregion

		#region Constructor
		public ScreenSlidePagerAdapter(FragmentManager fm)
			:base(fm) {
			m_lstFragmentList = new List<Fragment> ();
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Adds a supportFragment to the adapter
		/// </summary>
		/// <param name="supportFragment">Support fragment.</param>
		public void Add(Fragment supportFragment) {
			m_lstFragmentList.Add (supportFragment);
		}

		/// <summary>
		/// Adds a range of supportFragment
		/// </summary>
		/// <param name="supportFragmentList">Support fragment list.</param>
		public void AddRange(List<Fragment> supportFragmentList) {
			m_lstFragmentList.AddRange (supportFragmentList);
		}

		/// <summary>
		/// Adds supportFragments through param array
		/// </summary>
		/// <param name="supportFragment">Support fragment.</param>
		public void AddRange( params Fragment[] supportFragment) {
			m_lstFragmentList.AddRange (supportFragment);
		}
		#endregion

		#region Overriden Methods

		/// <param name="position">To be added.</param>
		/// <summary>
		/// Return the Fragment associated with a specified position.
		/// </summary>
		/// <returns>To be added.</returns>
		public override Fragment GetItem (int position) {
			if (position < 0)
				position = 0;
			if (position == m_lstFragmentList.Count)
				position -= 1;
			//TODO: i can use a switch method here
			//return new ScreenSlidePageFragment();
			return m_lstFragmentList [position];
		}

		/// <summary>
		/// Return the number of views available.
		/// </summary>
		/// <value>To be added.</value>
		public override int Count {
			get {
				return m_lstFragmentList.Count;
			}
		}

		/// <param name="container">The containing View from which the page will be removed.</param>
		/// <param name="position">The page position to be removed.</param>
		/// <summary>
		/// Destroies the item.
		/// </summary>
		/// <param name="object">Object.</param>
		public override void DestroyItem (View container, int position, Java.Lang.Object @object) {
			base.DestroyItem (container, position, @object);
		}
		#endregion
	}
}

