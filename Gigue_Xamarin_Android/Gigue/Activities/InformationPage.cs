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
using Android.Support.V7.App;
using Gigue.ViewModels;
using Newtonsoft.Json;

namespace Gigue.Activities
{
    [Activity(Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class InformationPage : AppCompatActivity
    {
        Button mBackToLogin;
        vmMusicianProfile mRegisteredUser;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.informationPage);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.SetTitleTextColor(Android.Graphics.Color.White);
            SetSupportActionBar(toolbar);

            mBackToLogin = FindViewById<Button>(Resource.Id.btnBackToLogin);
            mBackToLogin.Click += mBackToLogin_Click;

            // Create your application here
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var inflater = MenuInflater;
            inflater.Inflate(Resource.Menu.activity_main, menu);
            return true;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.tool_profile)
            {
                StartActivity(typeof(MusicianProfile));
                return true;
            }
            else if (id == Resource.Id.tool_search)
            {
                mRegisteredUser = retrieveset();
                Intent intent = new Intent(this, typeof(Search));
                intent.PutExtra("User", JsonConvert.SerializeObject(mRegisteredUser));
                StartActivity(intent);
                return true;
            }
            else if (id == Resource.Id.tool_Login)
            {
                StartActivity(typeof(Login));
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }
        void mBackToLogin_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Login));
            this.StartActivity(intent);
            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
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