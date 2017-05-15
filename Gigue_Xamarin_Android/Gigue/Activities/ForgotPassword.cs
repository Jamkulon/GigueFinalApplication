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

namespace Gigue.Activities
{
    [Activity(Label = "ForgotPassword")]
    public class ForgotPassword : Activity
    {

        Button mResetPassword;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.forgotPassword);

            mResetPassword = FindViewById<Button>(Resource.Id.btnResetPassword);
            mResetPassword.Click += mResetPassword_Click;

            // Create your application here
        }
        void mResetPassword_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Login));
            this.StartActivity(intent);
            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }
    }
}