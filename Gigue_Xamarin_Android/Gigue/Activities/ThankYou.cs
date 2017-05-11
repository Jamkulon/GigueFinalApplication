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

namespace Gigue.Activities
{

    
    [Activity(Theme = ("@android:style/Theme.NoTitleBar"))]
    public class ThankYou : Activity
    {

        Button mThankYouSearch;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.thankYou);

            mThankYouSearch = FindViewById<Button>(Resource.Id.btnThanks);

            mThankYouSearch.Click += mThankYouSearch_Click;

            // Create your application here
        }

        void mThankYouSearch_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Search));

            this.StartActivity(intent);
            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }
    }
}