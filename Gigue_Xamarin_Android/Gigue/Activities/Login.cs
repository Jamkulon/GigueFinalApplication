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
using System.Net;
using Gigue;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.MobileServices;
using Android.Views.InputMethods;

namespace Gigue.Activities
{
    [Activity(MainLauncher = true, Label = "Gigue")]
    public class Login : Activity
    {

        RelativeLayout mRelativeLayout;

        Button mButton;
        EditText mUsername;

        Button mRegister;

        private MobileServiceClient client;

        const string applicationURL = @"https://gigue.azurewebsites.net/api/user/2";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Login);

            mRelativeLayout = FindViewById<RelativeLayout>(Resource.Id.mainView);
            mUsername = FindViewById<EditText>(Resource.Id.txtUserName);
            mButton = FindViewById<Button>(Resource.Id.btnLogin);
            mRegister = FindViewById<Button>(Resource.Id.btnRegister);
            mButton.Click += mButton_Click;
            mRelativeLayout.Click += mRelativeLayout_Click;
            mRegister.Click += mRegister_Click;

        }
        void mRegister_Click(object sender, EventArgs r)
        {
            Intent intent = new Intent(this, typeof(createUserProfile));
            this.StartActivity(intent);
        }

        void mButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(musicianProfile));
            //intent.PutExtra("UserId", 1);
            //intent.PutExtra("Username", "Joseph");

            //James Code
            

            //intent.PutExtra("User", JsonConvert.SerializeObject(user))/*;*/


            this.StartActivity(intent);
            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }

        void mRelativeLayout_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }
    }
}