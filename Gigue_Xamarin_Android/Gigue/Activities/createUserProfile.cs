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
        User mRegisteredUser;
        int mRegisteredId;

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

            mRegisteredUser = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra("User"));

            mRegisterFirst.Text = mRegisteredUser.FirstName.ToString();
            mRegisterLast.Text = mRegisteredUser.LastName.ToString();
            mRegisteredEmail.Text = mRegisteredUser.Email.ToString();
            mRegisteredId = mRegisteredUser.AppUserId;



            //spinner class
            Spinner stateSpinner = FindViewById<Spinner>(Resource.Id.spinnerState);
            Spinner citySpinner = FindViewById<Spinner>(Resource.Id.spinnerCity);
            Spinner zipCodeSpinner = FindViewById<Spinner>(Resource.Id.spinnerZip);


            //state spinner
            stateSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
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
            // Create your application here
        }

        async void mSubmitUserProfile_Click(object sender, EventArgs e)
        {

            //Get data from spinners
            Spinner stateSpin = FindViewById<Spinner>(Resource.Id.spinnerState);
            Spinner citySpin = FindViewById<Spinner>(Resource.Id.spinnerCity);
            Spinner zipSpin = FindViewById<Spinner>(Resource.Id.spinnerZip);

            // Build appuser object
            vmAppUser itemToAdd = new vmAppUser
            {
                AppUserId = mRegisteredId,
                UserName = "",
                LastName = mRegisterLast.Text.Trim(),
                FirstName = mRegisterFirst.Text.Trim(),
                City = citySpin.SelectedItem.ToString(),
                State = stateSpin.SelectedItem.ToString(),
                PostalCode = zipSpin.SelectedItem.ToString(),
                Email = mRegisteredEmail.Text.Trim(),
                ReceiveAdvertisements = false,
                IsMusician = false
            };

            //send post request
            vmAppUser currentUser = await userdata.UpdateAppUser(mRegisteredId , itemToAdd);

            //TODO Add intent to move to the search page

        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
                        
            //string toast = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
            //Toast.MakeText(this, toast, ToastLength.Long).Show();
        }
    }
}