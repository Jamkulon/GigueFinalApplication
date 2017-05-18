﻿using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Gigue.ViewModels;
using Android.Support.V7.App;
using Gigue.Classes;

namespace Gigue.Activities
{
    [Activity(WindowSoftInputMode = SoftInput.AdjustResize, Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class MusicianProfile : AppCompatActivity
    {
        vmMusicianProfile mRegisteredUser;
        public SharedPrefs sharedPrefs = new SharedPrefs();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            Button mEditProfile;
            Button mSearch;
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Profile);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.SetTitleTextColor(Android.Graphics.Color.White);
            SetSupportActionBar(toolbar);

            mSearch = FindViewById<Button>(Resource.Id.btnSearch);
            mSearch.Click += mSearch_Click;

            mRegisteredUser = JsonConvert.DeserializeObject<vmMusicianProfile>(Intent.GetStringExtra("User"));

            mEditProfile = FindViewById<Button>(Resource.Id.btnEditProfile);
            mEditProfile.Click += mEditProfile_Click;

            //var lv = FindViewById<ListView>(Resource.Id.listView);

            //lv.Adapter = new ArrayAdapter<User>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, MainActivity.Users);

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
            if (id == Resource.Id.tool_Login)
            {
                Toast.MakeText(this, "Login clicked", ToastLength.Short).Show();
                    StartActivity(typeof(Login));
                return true;
            }
            else if (id == Resource.Id.tool_search)
            {
                Toast.MakeText(this, "Search clicked", ToastLength.Short).Show();
                    StartActivity(typeof(Search));
                return true;
            }
            else if (id == Resource.Id.tool_infoPage)
            {
                Toast.MakeText(this, "InfoPage clicked", ToastLength.Short).Show();
                StartActivity(typeof(InformationPage));
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        void mSearch_Click(object sender, EventArgs e)
        {

            Intent intent = new Intent(this, typeof(Search));
            intent.PutExtra("User", JsonConvert.SerializeObject(mRegisteredUser));

            this.StartActivity(intent);
        }
        void mEditProfile_Click(object sender, EventArgs e)
        {
            sharedPrefs.retrieveset();
            Intent intent = new Intent(this, typeof(editMusicianProfile));

            intent.PutExtra("User", JsonConvert.SerializeObject(mRegisteredUser));

            this.StartActivity(intent);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }
    }
}