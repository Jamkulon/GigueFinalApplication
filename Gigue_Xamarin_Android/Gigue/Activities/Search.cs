﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Views.InputMethods;
using Gigue.ViewModels;
using Newtonsoft.Json;
using Android.Support.V7.App;

namespace Gigue.Activities
{
    [Activity(WindowSoftInputMode = SoftInput.AdjustResize, Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class Search : AppCompatActivity
    {
        LinearLayout sLinearLayout;
        Button mSearchResults;
        Button mViewProfile;
        Spinner mCity;
        EditText mFirtName;
        EditText MLastName;
        Spinner MPrimeInst;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Set this page's main view//
            SetContentView(Resource.Layout.searchPage);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.SetTitleTextColor(Android.Graphics.Color.White);
            SetSupportActionBar(toolbar);
            //Assign globals
            mCity = FindViewById<Spinner>(Resource.Id.spinnerCity);
            mFirtName = FindViewById<EditText>(Resource.Id.enterFirstName);
            MLastName = FindViewById<EditText>(Resource.Id.enterLastName);
            MPrimeInst = FindViewById<Spinner>(Resource.Id.spinnerInstrumentPlayed);


            //Linear Layout Hide Keyboar//
            sLinearLayout = FindViewById<LinearLayout>(Resource.Id.srchView);
            sLinearLayout.Click += sLinearLayout_Click;

            //Search Results Button Click Event//
            mSearchResults = FindViewById<Button>(Resource.Id.btnResults);
            mSearchResults.Click += mSearchResults_Click;

            //View Profile Click Event
            mViewProfile = FindViewById<Button>(Resource.Id.btnViewProfile);
            mViewProfile.Click += mViewProfile_Click;

            //City Spinner class and method//
            Spinner citySpinner = FindViewById<Spinner>(Resource.Id.spinnerCity);

            citySpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var CityAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.cities_array, Android.Resource.Layout.SimpleSpinnerItem);

            CityAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            citySpinner.Adapter = CityAdapter;

            //Instrument Spinner class and methods//
            Spinner instrumentSpinner = FindViewById<Spinner>(Resource.Id.spinnerInstrumentPlayed);
            instrumentSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var instrumentAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.instrument_array, Android.Resource.Layout.SimpleSpinnerItem);

            instrumentAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            instrumentSpinner.Adapter = instrumentAdapter;

            // Search Click Activity to Send to Search Results Page
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
                Toast.MakeText(this, "Profile clicked", ToastLength.Short).Show();
                return true;
            }
            else if (id == Resource.Id.tool_search)
            {
                Toast.MakeText(this, "Search clicked", ToastLength.Short).Show();
                return true;
            }
            else if (id == Resource.Id.tool_infoPage)
            {
                Toast.MakeText(this, "InfoPage clicked", ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(Search));
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }
        void mSearchResults_Click(object sender, EventArgs r)
        {
            //Build musician search object
            vmMusicianSearch searchParam = new vmMusicianSearch
            {
                FirstName = mFirtName.Text.Trim(),
                LastName = MLastName.Text.Trim(),
                City = mCity.SelectedItem.ToString(),
                PrimeInstrument = MPrimeInst.SelectedItem.ToString()
            };

            Intent intent = new Intent(this, typeof(searchResults));

            //Send the search package
            intent.PutExtra("searchParam", JsonConvert.SerializeObject(searchParam));

            this.StartActivity(intent);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }

        // View Profile Activity to Send to Profile Page
        void mViewProfile_Click(object sender, EventArgs r)
        {
            //Build musician search object
            vmMusicianResult searchParam = new vmMusicianResult
            {
                
                City = mCity.SelectedItem.ToString(),
                PrimeInstrument = MPrimeInst.SelectedItem.ToString()
            };

            Intent intent = new Intent(this, typeof(MusicianProfile));
            this.StartActivity(intent);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }

        //Spinner Item Selected view events//
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            
        }

        //Linear Layout to make keyboard disappear upon clicking off and edit text field//
        void sLinearLayout_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }
    }
}