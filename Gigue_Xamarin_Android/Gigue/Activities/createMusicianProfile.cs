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
using Gigue.ViewModels;

namespace Gigue.Activities
{
    [Activity (WindowSoftInputMode = SoftInput.AdjustResize, Theme = ("@android:style/Theme.NoTitleBar"))]
    public class createMusicianProfile : RegistrationActivity
    {
        Button mSubmitMusicianProfile;
        EditText mRegisterFirst;
        EditText mRegisterLast;
        EditText mRegisteredEmail;
        vmMusicianProfile mRegisteredUser;
        int mRegisteredId;
        Spinner mStateSpinner;
        Spinner mCitySpinner;
        Spinner mZipCodeSpinner;
        Spinner mInstrumentSpinner;
        Spinner mGenreSpinner;
        Spinner mLanguageSpinner;


        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CreateMusicianProfile);

            mSubmitMusicianProfile = FindViewById<Button>(Resource.Id.btnSubmitMusician);
            mSubmitMusicianProfile.Click += mSubmitMusicianProfile_Click;

            mRegisterFirst = FindViewById<EditText>(Resource.Id.editFirstName);
            mRegisterLast = FindViewById<EditText>(Resource.Id.editLastName);
            mRegisteredEmail = FindViewById<EditText>(Resource.Id.editEmailAddress);

            mRegisteredUser = JsonConvert.DeserializeObject<vmMusicianProfile>(Intent.GetStringExtra("User"));

            mRegisterFirst.Text = mRegisteredUser.FirstName.ToString();
            mRegisterLast.Text = mRegisteredUser.LastName.ToString();
            mRegisteredEmail.Text = mRegisteredUser.Email.ToString();
            mRegisteredId = mRegisteredUser.AppUserId;

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
            mInstrumentSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
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

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;     
        }

        private async void mSubmitMusicianProfile_Click(object sender, EventArgs e)
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


            Intent intent = new Intent(this, typeof(Search));
            this.StartActivity(intent);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }
    }
}
