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
    public class Thanks : RegistrationActivity
    {

        Button mThankYou;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.thanks);

            mThankYou = FindViewById<Button>(Resource.Id.button9);
            mThankYou.Click += mThankYou_Click;


            // Create your application here
        }
        void mThankYou_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Search));
            this.StartActivity(intent);
        }
    }
}