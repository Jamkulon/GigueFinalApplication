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
    [Activity(MainLauncher = false, WindowSoftInputMode = SoftInput.AdjustResize, Theme = ("@android:style/Theme.NoTitleBar"))]
    public class Login : Activity
    {

        //add classes and items for all events on this page
        TextView mMoreInfo;
        TextView mSignUp;
        LinearLayout mLinearLayout;
        EditText mEmailAddress;
        Button mLogin;
        TextView mForgotPw;

        //private MobileServiceClient client;

        const string applicationURL = @"https://gigue.azurewebsites.net/api/";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Login);


            //declare all objects on the page
            mMoreInfo = FindViewById<TextView>(Resource.Id.moreInfo);
            mSignUp = FindViewById<TextView>(Resource.Id.signUp);
            mLinearLayout = FindViewById<LinearLayout>(Resource.Id.mainView);
            mEmailAddress = FindViewById<EditText>(Resource.Id.txtEmailAddress);
            mLogin = FindViewById<Button>(Resource.Id.btnLogin);
            mForgotPw = FindViewById<TextView>(Resource.Id.txtForgotPw);


            //Click events for every button or item on the page
            mMoreInfo.Click += mMoreInfo_Click;
            mSignUp.Click += mSignUp_Click;
            mLinearLayout.Click += mLinearLayout_Click;
            mLogin.Click += mLogin_Click;
            mForgotPw.Click += mForgotPw_Click;

        }

        //Login Button Click event to take you to Search page
        void mLogin_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Search));

            this.StartActivity(intent);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }

        //makes keyboard dissappear when clicked outside of the layout
        void mLinearLayout_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }

        //sign up button click event to go to Registration
        void mSignUp_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(RegistrationActivity));
            this.StartActivity(intent);
            this.OverridePendingTransition(Resource.Animation.slide_in_bottom, Resource.Animation.slide_out_top);
        }

        //More Information click event to got to Information Page
        void mMoreInfo_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(InformationPage));
            this.StartActivity(intent);
            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }

        //Forgot Password click event to take you to reset password page
        void mForgotPw_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ForgotPassword));
            this.StartActivity(intent);
            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }
    }
}