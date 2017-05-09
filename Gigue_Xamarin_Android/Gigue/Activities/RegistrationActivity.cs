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
using Android.Views.InputMethods;
using Gigue.Adapters;
using Gigue.Activities;
using Gigue.ViewModels;
using Newtonsoft.Json;

namespace Gigue
{
    [Activity(Label = "Registration")]
    public class RegistrationActivity : Activity
    {

        RelativeLayout rRelativeLayout;

        EditText mFirstName;
        EditText mLastName;
        EditText mEmailName;
        EditText mPassword;
        Button mMusician;
        Button mUser;

        public UserData userdata = new UserData();

        //RelativeLayout mRelativeLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Registration);

            mFirstName = FindViewById<EditText>(Resource.Id.txtFirstName);
            mLastName = FindViewById<EditText>(Resource.Id.txtLastName);
            mEmailName = FindViewById<EditText>(Resource.Id.txtEmail);
            mPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            mMusician = FindViewById<Button>(Resource.Id.btnMusician);
            mUser = FindViewById<Button>(Resource.Id.btnUser);
            mMusician.Click += mMusician_Click;
            mUser.Click += mUser_Click;

            rRelativeLayout = FindViewById<RelativeLayout>(Resource.Id.mainView);
            rRelativeLayout.Click += rRelativeLayout_Click;

            // Create your application here
        }



        async void mMusician_Click(object sender, EventArgs e)
        {
            // Build appuser object
            vmAppUser itemToAdd = new vmAppUser
            {
                AppUserId = 0,
                UserName = "",
                LastName = mLastName.Text.Trim(),
                FirstName = mFirstName.Text.Trim(),
                City = "",
                State = "",
                PostalCode = "",
                Email = mEmailName.Text.Trim(),
                ReceiveAdvertisements = false,
                IsMusician = false
            };

            //send post request
            await userdata.AddAppUser(itemToAdd);

            //Switch to Musician Profile
            Intent intent = new Intent(this, typeof(createMusicianProfile));

            User user = new Gigue.User()
            {
                FirstName = mFirstName.Text.Trim(),
                LastName = mLastName.Text.Trim(),
                Email = mEmailName.Text.Trim()
            };
            intent.PutExtra("User", JsonConvert.SerializeObject(user));

            this.StartActivity(intent);
            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }

        async void mUser_Click(object sender, EventArgs e)
        {
            // Build appuser object
            vmAppUser itemToAdd = new vmAppUser
            {
                AppUserId = 0,
                UserName = "",
                LastName = mLastName.Text.Trim(),
                FirstName = mFirstName.Text.Trim(),
                City = "",
                State = "",
                PostalCode = "",
                Email = mEmailName.Text.Trim(),
                ReceiveAdvertisements = false,
                IsMusician = false
            };

            //send post request
            await userdata.AddAppUser(itemToAdd);

            //Switch to  User Profile
            Intent intent = new Intent(this, typeof(createUserProfile));

            User user = new User()
            {
                FirstName = mFirstName.Text.Trim(),
                LastName = mLastName.Text.Trim(),
                Email = mEmailName.Text.Trim()
            };

            intent.PutExtra("User", JsonConvert.SerializeObject(user));

            this.StartActivity(intent);
            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }
        void rRelativeLayout_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }
    }
}