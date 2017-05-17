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
using Newtonsoft.Json;
using Gigue.Activities;
using Gigue.ViewModels;
using Gigue.Adapters;
using Android.Support.V7.App;

namespace Gigue
{
    [Activity(WindowSoftInputMode = SoftInput.AdjustResize, Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class editMusicianProfile : MusicianProfile
    {
        Button mEditMusicianProfile;
        EditText mRegisterFirst;
        EditText mRegisterLast;
        EditText mRegisteredEmail;
        User mRegisteredUser;
        int mRegisteredId;
        Spinner mStateSpinner;
        Spinner mCitySpinner;
        Spinner mZipCodeSpinner;
        Spinner mInstrumentSpinner;
        Spinner mGenreSpinner;
        Spinner mLanguageSpinner;

        public UserData userdata = new UserData();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.editMusicianProfile);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.SetTitleTextColor(Android.Graphics.Color.White);
            SetSupportActionBar(toolbar);

            mEditMusicianProfile = FindViewById<Button>(Resource.Id.btnEditMusician);
            mEditMusicianProfile.Click += mEditMusicianProfile_Click;
            // Spinners for 

            mStateSpinner = FindViewById<Spinner>(Resource.Id.spinnerState);
            mCitySpinner = FindViewById<Spinner>(Resource.Id.spinnerCity);
            mZipCodeSpinner = FindViewById<Spinner>(Resource.Id.spinnerZip);
            mInstrumentSpinner = FindViewById<Spinner>(Resource.Id.spinnerInstrumentPlayed);
            mGenreSpinner = FindViewById<Spinner>(Resource.Id.spinnerMusicGenres);
            mLanguageSpinner = FindViewById<Spinner>(Resource.Id.spinnerLanguagesSpoken);


            //state spinner
            mStateSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var StateAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.states_array, Android.Resource.Layout.SimpleSpinnerItem);

            StateAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            mStateSpinner.Adapter = StateAdapter;

            //city spinner
            mCitySpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var CityAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.cities_array, Android.Resource.Layout.SimpleSpinnerItem);

            CityAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            mCitySpinner.Adapter = CityAdapter;

            //Zip Code Spinner Adapter
            mZipCodeSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var zipCodeAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.zip_array, Android.Resource.Layout.SimpleSpinnerItem);

            zipCodeAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            mZipCodeSpinner.Adapter = zipCodeAdapter;

            //Instrument Select Code Spinner Adapter
            mInstrumentSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var instrumentAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.instrument_array, Android.Resource.Layout.SimpleSpinnerItem);

            instrumentAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            mInstrumentSpinner.Adapter = instrumentAdapter;

            //Music Genre Select Spinner
            mGenreSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var genreAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.genre_array, Android.Resource.Layout.SimpleSpinnerItem);

            genreAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            mGenreSpinner.Adapter = genreAdapter;

            //Language Select Spinner
            mLanguageSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var languageAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.language_array, Android.Resource.Layout.SimpleSpinnerItem);

            languageAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            mLanguageSpinner.Adapter = languageAdapter;
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
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;



        }
        private async void mEditMusicianProfile_Click(object sender, EventArgs e)
        {
            // Build appuser object
            vmAppUser itemToAdd = new vmAppUser
            {
                AppUserId = mRegisteredId,
                UserName = "",
                LastName = mRegisterLast.Text.Trim(),
                FirstName = mRegisterFirst.Text.Trim(),
                City = mCitySpinner.SelectedItem.ToString(),
                State = mStateSpinner.SelectedItem.ToString(),
                PostalCode = mZipCodeSpinner.SelectedItem.ToString(),
                Email = mRegisteredEmail.Text.Trim(),
                ReceiveAdvertisements = false,
                IsMusician = true
            };

            //send post request
            vmAppUser currentUser = await userdata.UpdateAppUser(itemToAdd);


            Intent intent = new Intent(this, typeof(MusicianProfile));

            this.StartActivity(intent);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }
    }
}