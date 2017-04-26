using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SharedPreferences
{
    [Activity(Label = "Activity2")]
    public class Activity2 : Activity

        

    {
        TextView mUserID;
        TextView mUsername;

        RelativeLayout mRelativeLayout;
        Button pButton;
        User mLoggedOnUser;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Activity2);

            mRelativeLayout = FindViewById<RelativeLayout>(Resource.Id.mainView);
            pButton = FindViewById<Button>(Resource.Id.btnProfile);
            pButton.Click += pButton_Click;

            // Create your application here

            mUserID = FindViewById<TextView>(Resource.Id.userid);
            mUsername = FindViewById<TextView>(Resource.Id.username);

            mLoggedOnUser = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra("User"));


            mUserID.Text = mLoggedOnUser.UserID.ToString();
            mUsername.Text = mLoggedOnUser.UserName;
          


        }

        void pButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Profile));
            this.StartActivity(intent);
        }


    }
}