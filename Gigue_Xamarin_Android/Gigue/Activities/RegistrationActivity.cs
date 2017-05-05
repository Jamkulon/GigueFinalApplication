﻿using System;
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

namespace Gigue
{
    [Activity(Label = "RegistrationActivity")]
    public class RegistrationActivity : Activity
    {
        EditText mFirstName;
        EditText mLastName;
        EditText mEmailName;
        EditText mPassword;
        Button mMusician;
        Button mUser;

        public UserData userdata = new UserData();

        RelativeLayout mRelativeLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Registration);

            mFirstName = FindViewById<EditText>(Resource.Id.txtFirstName);
            mLastName = FindViewById<EditText>(Resource.Id.txtLastName);
            mEmailName = FindViewById<EditText>(Resource.Id.txtEmailName);
            mPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            mMusician = FindViewById<Button>(Resource.Id.btnMusician);
            mUser = FindViewById<Button>(Resource.Id.btnUser);
            mMusician.Click += mMusician_Click;
            mUser.Click += mUser_Click;
            // Create your application here

        }

       

        async void mMusician_Click(object sender, EventArgs e)
        {
            // Build appuser object
            DataObjects.AppUser itemToAdd = new DataObjects.AppUser
            {
                FirstName = mFirstName.Text.Trim(),
                LastName = mLastName.Text.Trim(),
                Email = mEmailName.Text.Trim()
            };

            //send post request
            await userdata.AddAppUser(itemToAdd);

            //Switch to Musician Profile
            Intent intent = new Intent(this, typeof(createMusicianProfile));

            this.StartActivity(intent);
        }
        void mUser_Click(object sender, EventArgs e)
        {


            //Switch to  User Profile
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