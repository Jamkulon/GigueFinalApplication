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
using Gigue.Adapters;

namespace Gigue.Activities
{
    [Activity(WindowSoftInputMode = SoftInput.AdjustResize, Theme = ("@android:style/Theme.NoTitleBar"))]
    public class createUserProfile : Activity
    {
        EditText mRegisterFirst;
        EditText mRegisterLast;
        EditText mRegisteredEmail;
        Button mSubmitUserProfile;
        vmMusicianProfile mRegisteredUser;
        int mRegisteredId;
        Spinner mStateSpinner;
        Spinner mCitySpinner;
        Spinner mZipCodeSpinner;

        public UserData userdata = new UserData();


        protected override void OnCreate(Bundle Bundle)
        {
            base.OnCreate(Bundle);
            SetContentView(Resource.Layout.CreateUserProfile);

            mRegisterFirst = FindViewById<EditText>(Resource.Id.editUserFirstName);
            mRegisterLast = FindViewById<EditText>(Resource.Id.editUserLastName);
            mRegisteredEmail = FindViewById<EditText>(Resource.Id.editUserEmailAddress);

            mSubmitUserProfile = FindViewById<Button>(Resource.Id.submitUserProfile);
            mSubmitUserProfile.Click += mSubmitUserProfile_Click;

            mRegisteredUser = JsonConvert.DeserializeObject<vmMusicianProfile>(Intent.GetStringExtra("User"));

            mRegisterFirst.Text = mRegisteredUser.FirstName.ToString();
            mRegisterLast.Text = mRegisteredUser.LastName.ToString();
            mRegisteredEmail.Text = mRegisteredUser.Email.ToString();
            mRegisteredId = mRegisteredUser.AppUserId;



            //spinner class
            mStateSpinner = FindViewById<Spinner>(Resource.Id.spinnerState);
            mCitySpinner = FindViewById<Spinner>(Resource.Id.spinnerCity);
            mZipCodeSpinner = FindViewById<Spinner>(Resource.Id.spinnerZip);


            //state spinner
            mStateSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
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
            // Create your application here
        }

        async void mSubmitUserProfile_Click(object sender, EventArgs e)
        {
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
            
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
                IsMusician = false
            };

            //send post request
            vmAppUser currentUser = await userdata.UpdateAppUser(itemToAdd);

        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
           
        }
    }
}