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
using Gigue.Activities;

namespace Gigue
{
    [Activity(MainLauncher= true, Theme = ("@android:style/Theme.NoTitleBar"))]
    public class Home : Activity
    {
        Button mLogin;
        Button mRegister;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HomePage);

            mLogin = FindViewById<Button>(Resource.Id.buttonLoginPage);
            mRegister = FindViewById<Button>(Resource.Id.buttonRegisterPage);
            mLogin.Click += mLogin_Click;
            mRegister.Click += mRegister_Click;
        }
        void mLogin_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Login));
            this.StartActivity(intent);
        }
        void mRegister_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(RegistrationActivity));
            this.StartActivity(intent);
        }
    }
}