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
    public class InformationPage : Activity
    {

        Button mBackToLogin;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.informationPage);

            mBackToLogin = FindViewById<Button>(Resource.Id.btnBackToLogin);
            mBackToLogin.Click += mBackToLogin_Click;

            // Create your application here
        }

        void mBackToLogin_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Login));
            this.StartActivity(intent);
        }
    }
}