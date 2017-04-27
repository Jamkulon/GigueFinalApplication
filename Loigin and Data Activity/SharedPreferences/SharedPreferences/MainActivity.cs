using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Views.InputMethods;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SharedPreferences
{
    [Activity(Label = "SharedPreferences", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        RelativeLayout mRelativeLayout;

        Button mButton;

        EditText mUsername;

        Button mRegister;

        //Instantiation of the sample data list
        public static List<User> Users = new List<User>();


        protected override void OnCreate(Bundle bundle)
        {

            //Sample data
            Users.Add(new User("Bob", "123"));
            Users.Add(new User("Geoffrey", "123"));
            Users.Add(new User("James", "123"));
            Users.Add(new User("Joel", "123"));



            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

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
            Intent intent = new Intent(this, typeof(RegistrationActivity));
            this.StartActivity(intent);
        }

        void mButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity2));
            //intent.PutExtra("UserId", 1);
            //intent.PutExtra("Username", "Joseph");

            //James Code
            User user = new User(mUsername.Text, "password")
            {
                //UserID = 1,
                UserName = mUsername.Text,
                Password = "password"
            };

            intent.PutExtra("User", JsonConvert.SerializeObject(user));


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

