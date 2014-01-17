#region Directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
#endregion

namespace Ph.Mobext.Sureseats.AndroidApp
{
	public class MovieItem 	{
		#region Variables
		Context m_Context;
		int m_intImageResourceId;
		string m_strMovieTitle;
		string m_strTag;
		int m_intId;
		#endregion

		#region Constructor
		public MovieItem(Context p_context, string p_strTag, int p_intImageResourceId, string p_strMovieTitle, int p_intId) {
			m_Context = p_context;
			m_strTag = p_strTag;
			m_intImageResourceId = p_intImageResourceId;
			m_strMovieTitle = p_strMovieTitle;
			m_intId = p_intId + 300;
		}
		#endregion

		#region Methods / Functions
		/// <summary>
		/// Gets the item.
		/// </summary>
		/// <returns>The item.</returns>
		public LinearLayout GetItem() {
			LinearLayout layout = new LinearLayout (m_Context);
			layout.Orientation = Orientation.Vertical;

			LinearLayout.LayoutParams layoutParams = 
				new LinearLayout.LayoutParams (
					WindowManagerLayoutParams.WrapContent,
					WindowManagerLayoutParams.WrapContent);
			layoutParams.SetMargins (75, 0, 75, 0);
			layout.LayoutParameters = layoutParams;


			#region Tag Layout
			LinearLayout linHeader = new LinearLayout(m_Context);
			LinearLayout.LayoutParams prm_linHeader  =
				new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent,ViewGroup.LayoutParams.WrapContent);

			linHeader.Orientation = Orientation.Horizontal;

			ImageView imgTagIcon = new ImageView (m_Context);
			imgTagIcon.SetMinimumWidth (48);
			imgTagIcon.SetMinimumHeight (48);
			imgTagIcon.SetBackgroundColor (Color.Cyan);
			imgTagIcon.Id = m_intId;
			//imgTagIcon.SetPadding (50, 0, 0, 0);

			TextView tvTag = new TextView (m_Context);
			RelativeLayout.LayoutParams tagParams =
				new RelativeLayout.LayoutParams (
					ViewGroup.LayoutParams.FillParent,
					ViewGroup.LayoutParams.WrapContent);
			tagParams.AddRule (LayoutRules.RightOf,imgTagIcon.Id);
			tagParams.LeftMargin = 25;
			tvTag.Text = m_strTag;
			tvTag.Typeface = Typeface.Create ("Droid Sans", TypefaceStyle.Bold);
			tvTag.SetTextColor (Color.DarkCyan);
			tvTag.SetTextSize (global::Android.Util.ComplexUnitType.Px, 38F);
			tvTag.LayoutParameters = tagParams;

			linHeader.AddView (imgTagIcon);
			linHeader.AddView (tvTag);

			//Now add this to a linearlayout to center it.
			LinearLayout linMainHeader = new LinearLayout(m_Context);
			linMainHeader.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.FillParent,ViewGroup.LayoutParams.WrapContent);
			linMainHeader.SetGravity(GravityFlags.Center);
			linMainHeader.AddView(linHeader);

			layout.AddView (linMainHeader);
			#endregion

			#region Image Movie
			int preferredHeight = (int)((m_Context.Resources.DisplayMetrics.HeightPixels/2)-120);
			int preferredWidth = (int) (m_Context.Resources.DisplayMetrics.WidthPixels-(m_Context.Resources.DisplayMetrics.WidthPixels/2));

			Drawable drwImage = 
				new BitmapDrawable (
					BmpFactory.Singleton.DecodeSampledBitmapFromResource(
						m_Context.Resources, 
						m_intImageResourceId,
						preferredWidth,
						preferredHeight
					));

			ImageView imgMovie = new ImageView (m_Context);
			imgMovie.SetMinimumHeight(preferredHeight);
			imgMovie.SetMinimumWidth(preferredWidth);
			Bitmap bmp = BitmapFactory.DecodeResource (m_Context.Resources, m_intImageResourceId);
			//imgMovie.SetImageBitmap (bmp);
			imgMovie.SetBackgroundDrawable (drwImage);
			//bmp.Recycle ();
			layout.AddView (imgMovie);
			#endregion

			#region Movie Title
				TextView tvMovieTitle = new TextView (m_Context);
				LinearLayout.LayoutParams tvMovieTitleParams =
					new LinearLayout.LayoutParams (
						ViewGroup.LayoutParams.FillParent,
						ViewGroup.LayoutParams.WrapContent);
				tvMovieTitleParams.Gravity = GravityFlags.Center;
				tvMovieTitleParams.SetMargins (5, 0, 0, 0);

				tvMovieTitle.LayoutParameters = tvMovieTitleParams;
				tvMovieTitle.Text = m_strMovieTitle;
				tvMovieTitle.Typeface = Typeface.Create ("Droid Sans", TypefaceStyle.Bold);
				tvMovieTitle.SetTextColor (Color.Black);
				tvMovieTitle.SetTextSize (global::Android.Util.ComplexUnitType.Px, 34F);
				tvMovieTitle.Gravity = GravityFlags.Center;


				layout.AddView (tvMovieTitle);
			#endregion

			LinearLayout mainLayout = new LinearLayout (m_Context);
			mainLayout.LayoutParameters = new LinearLayout.LayoutParams (ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
			mainLayout.Id = m_intId;
			//mainLayout.SetBackgroundColor (Color.Red);
			mainLayout.AddView (layout);
			mainLayout.Focusable = true;
			return mainLayout;
		}


		#endregion

		#region Events
		/// <summary>
		/// Items the click.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		public void ItemClick(object sender, EventArgs e){
			var intent = new Intent (m_Context, typeof(Act_BuyMovieTicket));
			(m_Context as Activity).Finish ();
			(m_Context as Activity).StartActivity (intent);
			(m_Context as Activity).OverridePendingTransition (0, 0);
		}
		#endregion
	}
}

