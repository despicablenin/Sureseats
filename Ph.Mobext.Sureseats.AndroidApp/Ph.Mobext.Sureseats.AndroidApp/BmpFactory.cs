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
using Android.Graphics.Drawables;
using Android.Graphics;
using Content = Android.Content;
#endregion

namespace Ph.Mobext.Sureseats.AndroidApp
{
	public class BmpFactory 
	{

		static BmpFactory factory;

		private BmpFactory(){

		}

		public static BmpFactory Singleton {
			get {
				factory = new BmpFactory ();
				return factory;
			}
		}

		public int CalculateInSampleSize( BitmapFactory.Options p_bmfOptions, int p_intRequiredWidth, int p_intRequiredHeight) {
			int height = p_bmfOptions.OutHeight;
			int width = p_bmfOptions.OutWidth;
			int inSampleSize = 1;

			if (height > p_intRequiredHeight || width > p_intRequiredWidth) {
				int halfHeight = height / 2;
				int halfWidth = width / 2;

				while ((halfHeight / inSampleSize) > p_intRequiredHeight
				      && (halfWidth / inSampleSize) > p_intRequiredWidth) {
					inSampleSize *= 2;
				}

			}
			return inSampleSize;
		}

		public Bitmap DecodeSampledBitmapFromResource(Content.Res.Resources p_resource, 
			int p_intResourceId, int p_intRequiredWidth, int p_intRequiredHeight) {
			BitmapFactory.Options options = new BitmapFactory.Options ();
			options.InJustDecodeBounds = true;
			BitmapFactory.DecodeResource (p_resource, p_intResourceId, options);

			//Calculate inSampleSize
			options.InSampleSize = CalculateInSampleSize (options, p_intRequiredWidth, p_intRequiredHeight);

			//Decode Bitmap with inSampleSize set
			options.InJustDecodeBounds = false;
			return BitmapFactory.DecodeResource (p_resource, p_intResourceId, options);
		}
	}
}

