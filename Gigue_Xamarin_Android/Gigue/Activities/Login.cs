using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;

using Android.Widget;
using Android.Views.InputMethods;
using Android.Support.V7.App;
using Newtonsoft.Json;
using Gigue.ViewModels;
using System.Collections.Generic;
using System.Threading;
using Gigue.Classes;

namespace Gigue.Activities
{
    [Activity(MainLauncher = false, WindowSoftInputMode = SoftInput.AdjustResize, Theme = ("@style/Theme.AppCompat.Light.NoActionBar"))]
    public class Login : AppCompatActivity
    {

        //add classes and items for all events on this page
        TextView mMoreInfo;
        TextView mSignUp;
        LinearLayout mLinearLayout;
        EditText mEmailAddress;
        EditText mPassword;
        Button mLogin;
        TextView mForgotPw;
        private Switch mLoggedIn;
        //bool mIsLoggedIn;
        vmMusicianProfile mRegisteredUser;
        int mAppUserId;

        //public SharedPrefs sharedPrefs = new SharedPrefs();

        private int progressBarStatus;



        //private MobileServiceClient client;

        const string applicationURL = @"https://gigue.azurewebsites.net/api/";

        //vmMusicianProfile mRegisteredUser = new vmMusicianProfile();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            

            SetContentView(Resource.Layout.Login);

            //declare all objects on the page
            mMoreInfo = FindViewById<TextView>(Resource.Id.moreInfo);
            mSignUp = FindViewById<TextView>(Resource.Id.signUp);
            mLinearLayout = FindViewById<LinearLayout>(Resource.Id.mainView);
            mEmailAddress = FindViewById<EditText>(Resource.Id.txtEmailAddress);
            mPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            mLogin = FindViewById<Button>(Resource.Id.btnLogin);
            mForgotPw = FindViewById<TextView>(Resource.Id.txtForgotPw);
            mLoggedIn = FindViewById<Switch>(Resource.Id.keepLoggedIn);

            //Click events for every button or item on the page
            mMoreInfo.Click += mMoreInfo_Click;
            mSignUp.Click += mSignUp_Click;
            mLinearLayout.Click += mLinearLayout_Click;
            mLogin.Click += mLogin_Click;
            mForgotPw.Click += mForgotPw_Click;

            //if (mIsLoggedIn == true)
            //{
            mRegisteredUser = retrieveset();
            if (mRegisteredUser.AppUserId > 0)
            {
                mEmailAddress.Text = mRegisteredUser.Email;
                mPassword.Text = mRegisteredUser.PassWord;
                mAppUserId = mRegisteredUser.AppUserId;
            }
            Console.WriteLine("AppUserId = " + mRegisteredUser.AppUserId);
        }

        //Login Button Click event to take you to Search page
        void mLogin_Click(object sender, EventArgs e)
        {
            mRegisteredUser.Email = mEmailAddress.Text.ToString().Trim();
            mRegisteredUser.PassWord = mPassword.Text.ToString().Trim();
            saveset(mRegisteredUser);
            mRegisteredUser = retrieveset();
            //Console.WriteLine(mRegisteredUser.Email);


            ProgressDialog progressBar = new ProgressDialog(this);
            progressBar.SetCancelable(true);
            //progressBar.SetMessage("Page is Loading...");
            progressBar.SetProgressStyle(ProgressDialogStyle.Horizontal);
            progressBar.Progress = 0;
            progressBar.Max = 100;
            progressBar.Show();
            progressBarStatus = 0;

            //Run Thread and increase preogress value
            new Thread(new ThreadStart(delegate
            {

                while (progressBarStatus < 100)
                {
                    progressBarStatus += 10;

                    progressBar.Progress += progressBarStatus;
                    Thread.Sleep(100);
                }
                //    RunOnUiThread(() => { progressBar.SetMessage("File is downloaded..."); });
                //    //progressBar.SetMessage("File is downloaded...");
                //    //Toast.MakeText(this, "File is downloaded", ToastLength.Long).Show();
            })).Start();


            Intent intent = new Intent(this, typeof(MusicianProfile));

            intent.PutExtra("User", JsonConvert.SerializeObject(mRegisteredUser));

            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
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

            intent.PutExtra("User", JsonConvert.SerializeObject(mRegisteredUser));

            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.slide_in_bottom, Resource.Animation.slide_out_top);
        }

        //More Information click event to got to Information Page
        void mMoreInfo_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(InformationPage));
            StartActivity(intent);
            OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }

        //Forgot Password click event to take you to reset password page
        void mForgotPw_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ForgotPassword));
            StartActivity(intent);
            OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }
        public void saveset(vmMusicianProfile user)
        {
            mRegisteredUser = user;
            string musicianProfile = JsonConvert.SerializeObject(mRegisteredUser);
            //store
            var prefs = Application.Context.GetSharedPreferences("GIGUE", FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutString("profile", musicianProfile);
            prefEditor.Apply();

        }

        public vmMusicianProfile retrieveset()
        {
            string strMusicianProfile;
            vmMusicianProfile vmProf;
            //Retreive existing records
            var prefs = Application.Context.GetSharedPreferences("GIGUE", FileCreationMode.Private);
            strMusicianProfile = prefs.GetString("profile", null);
            //If email is null, return new vmMusicianProfile
            if (strMusicianProfile == null)
            {
                mRegisteredUser = new vmMusicianProfile();
                return mRegisteredUser;
            }
            else
            {
                vmProf = JsonConvert.DeserializeObject<vmMusicianProfile>(strMusicianProfile);
                if (vmProf == null)
                {
                    mRegisteredUser = new vmMusicianProfile();
                    return mRegisteredUser;
                }
                else
                {
                    mRegisteredUser = vmProf;
                    return mRegisteredUser;
                }
            }
        }

    }
}