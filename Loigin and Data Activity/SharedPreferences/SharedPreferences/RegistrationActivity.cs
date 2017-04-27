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

namespace SharedPreferences
{
    [Activity(Label = "RegistrationActivity")]
    public class RegistrationActivity : Activity
    {
        Button mMusician;
        Button mUser;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Registration);

            mMusician = FindViewById<Button>(Resource.Id.btnMusician);
            mUser = FindViewById<Button>(Resource.Id.btnUser);
            mMusician.Click += mMusician_Click;
            mUser.Click += mUser_Click;
            // Create your application here
        }

        void mMusician_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MusicianActivity));
            this.StartActivity(intent);
        }

        void mUser_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(UserActivity));
            this.StartActivity(intent);
        }
    }
}