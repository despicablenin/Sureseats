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
using Android.Graphics;
using Android.Text;
#endregion

namespace Ph.Mobext.Sureseats.AndroidApp
{
	public class MyDialog : BaseFragmentActivity
	{
		#region Variable
		static MyDialog provider;
		#endregion

		#region Singleton
		public static MyDialog Prompt {
			get {
				provider = new MyDialog ();
				return provider;
			}
		}
		#endregion

		#region Methods/Functions
		public AlertDialog RatingDialog(Context context, string ratingCode, string ratingTitle, string descriptionHtml){
			View view = View.Inflate(context, Resource.Layout.Dialog_MTRCBRating, null);

			var txtRatingCode = view.FindViewById<TextView> (Resource.Id.MRS_tvRatingCode);
			TextFormatter(txtRatingCode, 30F, Color.White, "OpenSans", TypefaceStyle.Bold);

			var txtRating = view.FindViewById<TextView> (Resource.Id.MRS_tvRating);
			TextFormatter(txtRating, 16F, Color.Black, "OpenSans", TypefaceStyle.Bold);

			var txtDetail = view.FindViewById<TextView> (Resource.Id.MRS_tvDetail);
			TextFormatter(txtDetail, 10F, Color.Black, "OpenSans", TypefaceStyle.Normal);

			txtDetail.Text = Html.FromHtml(descriptionHtml).ToString();

			AlertDialog dialog = new AlertDialog.Builder(context).Create();
			var dialogButton = view.FindViewById<Button> (Resource.Id.MRS_btnOk);
			dialogButton.SetTextSize(global::Android.Util.ComplexUnitType.Pt, 5F);
			dialogButton.SetTextColor(Color.Crimson);
			dialogButton.Click += delegate(object sender2, EventArgs e2) {
				(dialog as AlertDialog).Dismiss();
			};

			dialog.SetView(view);
			return dialog;
		}

		public AlertDialog NoRatingDialog(Context context){
			View view = View.Inflate(context, Resource.Layout.Dialog_NoMTRCBRating, null);

			AlertDialog dialog = new AlertDialog.Builder(context).Create();
			var dialogButton = view.FindViewById<Button> (Resource.Id.NoMRS_btnOk);
			dialogButton.SetTextSize(global::Android.Util.ComplexUnitType.Pt, 5F);
			dialogButton.SetTextColor(Color.Crimson);
			dialogButton.Click += delegate(object sender2, EventArgs e2) {
				(dialog as AlertDialog).Dismiss();
			};

			dialog.SetView(view);
			return dialog;
		}
		#endregion

	}
}

