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
using _Fragment = Android.Support.V4.App.Fragment;
#endregion

namespace Ph.Mobext.Sureseats.AndroidApp
{
	public class Frag_Base : _Fragment
	{

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

		public override void OnLowMemory ()
		{
			base.OnLowMemory ();
			this.Dispose ();
		}
		#endregion

		#region Protected Methods
		/// <summary>
		/// Texts the formatter.
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
		#endregion
	}
}

