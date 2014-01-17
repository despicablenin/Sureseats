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
using _Fragment = Android.Support.V4.App.Fragment;
#endregion

namespace Ph.Mobext.Sureseats.AndroidApp
{
	public class ScreenSlidePageFragment : _Fragment
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			ViewGroup rootView = (ViewGroup)inflater.Inflate (Resource.Layout.Frag_MovieHome, container, false);
			return rootView;
		}
	}
}

