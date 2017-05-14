using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Views.InputMethods;

namespace Gigue.Activities
{
    [Activity(MainLauncher = false, WindowSoftInputMode = SoftInput.AdjustResize, Theme = ("@android:style/Theme.NoTitleBar"))]
    public class Login : Activity
    {
        
        LinearLayout mLinearLayout;
        Button mLogin;
        EditText mEmailAddress;
        EditText mPassword;
        TextView mSignUp;
        TextView mMoreInfo;
        string spGigueEmail;
        string spPassword;
        


        //private MobileServiceClient client;

        const string applicationURL = @"https://gigue.azurewebsites.net/api/";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Login);

            mMoreInfo = FindViewById<TextView>(Resource.Id.moreInfo);
            mSignUp = FindViewById<TextView>(Resource.Id.signUp);
            mLinearLayout = FindViewById<LinearLayout>(Resource.Id.mainView);
            mEmailAddress = FindViewById<EditText>(Resource.Id.txtEmailAddress);
            mLogin = FindViewById<Button>(Resource.Id.btnLogin);
            mPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            mLogin.Click += mLogin_Click;
            mLinearLayout.Click += mLinearLayout_Click;
            mSignUp.Click += mSignUp_Click;
            mMoreInfo.Click += mMoreInfo_Click;


        }

        //Login Button Click
        void mLogin_Click(object sender, EventArgs e)
        {
            //Store prefs to app settings - Will be removed on exit
            //ISharedPreferences GiguePrefs = PreferenceManager.GetDefaultSharedPreferences(this);
            //ISharedPreferencesEditor editor = GiguePrefs.Edit();
            //editor.PutString(spGigueEmail,mEmailAddress.Text);
            //editor.Apply();

            //Test SharedPreferences
            //var mySetting = GiguePrefs.GetString(spGigueEmail, "");
            //Console.WriteLine(mySetting);
            


            Intent intent = new Intent(this, typeof(Search));

            this.StartActivity(intent);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }

        void mLinearLayout_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }
        void mSignUp_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(RegistrationActivity));
            this.StartActivity(intent);
            this.OverridePendingTransition(Resource.Animation.slide_in_bottom, Resource.Animation.slide_out_top);
        }
        void mMoreInfo_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(InformationPage));
            this.StartActivity(intent);
            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }
    }
}