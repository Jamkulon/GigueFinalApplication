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

namespace Gigue.Activities
{
    [Activity (Theme = ("@android:style/Theme.NoTitleBar"))]
    public class createMusicianProfile : RegistrationActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            EditText mRegisterFirst;
            EditText mRegisterLast;
            EditText mRegisteredEmail;
            User mRegisteredUser;

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CreateMusicianProfile);

            mRegisterFirst = FindViewById<EditText>(Resource.Id.editFirstName);
            mRegisterLast = FindViewById<EditText>(Resource.Id.editLastName);
            mRegisteredEmail = FindViewById<EditText>(Resource.Id.editEmailAddress);

            mRegisteredUser = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra("User"));

            mRegisterFirst.Text = mRegisteredUser.FirstName.ToString();
            mRegisterLast.Text = mRegisteredUser.LastName.ToString();
            mRegisteredEmail.Text = mRegisteredUser.Email.ToString();

            // Spinners for 

            Spinner stateSpinner = FindViewById<Spinner>(Resource.Id.spinnerState);
            Spinner citySpinner = FindViewById<Spinner>(Resource.Id.spinnerCity);
            Spinner zipCodeSpinner = FindViewById<Spinner>(Resource.Id.spinnerZip);
            Spinner instrumentSpinner = FindViewById<Spinner>(Resource.Id.spinnerInstrumentPlayed);
            Spinner genreSpinner = FindViewById<Spinner>(Resource.Id.spinnerMusicGenres);
            Spinner languageSpinner = FindViewById<Spinner>(Resource.Id.spinnerLanguagesSpoken);


            //state spinner
            stateSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var StateAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.states_array, Android.Resource.Layout.SimpleSpinnerItem);

            StateAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            stateSpinner.Adapter = StateAdapter;

            //city spinner
            citySpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var CityAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.cities_array, Android.Resource.Layout.SimpleSpinnerItem);

            CityAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            citySpinner.Adapter = CityAdapter;

            //Zip Code Spinner Adapter
            zipCodeSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var zipCodeAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.zip_array, Android.Resource.Layout.SimpleSpinnerItem);

            zipCodeAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            zipCodeSpinner.Adapter = zipCodeAdapter;

            //Instrument Select Code Spinner Adapter
            instrumentSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var instrumentAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.instrument_array, Android.Resource.Layout.SimpleSpinnerItem);

            instrumentAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            instrumentSpinner.Adapter = instrumentAdapter;

            //Music Genre Select Spinner
            instrumentSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var genreAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.genre_array, Android.Resource.Layout.SimpleSpinnerItem);

           genreAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            genreSpinner.Adapter = genreAdapter;

            //Language Select Spinner
            languageSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var languageAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.language_array, Android.Resource.Layout.SimpleSpinnerItem);

            languageAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            languageSpinner.Adapter = languageAdapter;
            // Create your application here
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;


            //code used to show selection, no longer needed
            
            //string toast = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
            //Toast.MakeText(this, toast, ToastLength.Long).Show();
        }
    }
}
