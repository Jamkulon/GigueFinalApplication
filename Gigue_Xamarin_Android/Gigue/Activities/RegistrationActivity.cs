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
using Android;
using Gigue.Activities;
using Android.Views.InputMethods;

namespace Gigue
{
    [Activity(Label = "RegistrationActivity")]
    public class RegistrationActivity : Activity
    {
        EditText mFirstName;
        EditText mLastName;
        EditText mUserName;
        EditText mPassword;
        Button mMusician;
        Button mUser;

          RelativeLayout mRelativeLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Registration);

            mFirstName = FindViewById<EditText>(Resource.Id.txtFirstName);
            mLastName = FindViewById<EditText>(Resource.Id.txtLastName);
            mUserName = FindViewById<EditText>(Resource.Id.txtUserName);
            mPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            mMusician = FindViewById<Button>(Resource.Id.btnMusician);
            mUser = FindViewById<Button>(Resource.Id.btnUser);
            mMusician.Click += mMusician_Click;
            mUser.Click += mUser_Click;
            // Create your application here
        }

       

        void mMusician_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(createMusicianProfile));

            this.StartActivity(intent);
        }
        void mUser_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(createUserProfile));

            this.StartActivity(intent);
        }
        void mRelativeLayout_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }
    }
}