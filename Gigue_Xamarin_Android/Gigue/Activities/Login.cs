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

namespace Gigue.Activities
{
    [Activity(MainLauncher = true, Label = "Gigue")]
    public class Login : Activity
    {

        private MobileServiceClient client;

        const string applicationURL = @"https://gigue.azurewebsites.net/api/user/2";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Login);



            // Create your application here
        }


    }
}
