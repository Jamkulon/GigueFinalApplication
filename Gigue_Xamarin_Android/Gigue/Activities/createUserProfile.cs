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
using Android.Support.V7.App;
using Gigue.Classes;

namespace Gigue
{
    [Activity(WindowSoftInputMode = SoftInput.AdjustResize, Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class createUserProfile : AppCompatActivity
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
        public SharedPrefs sharedPrefs = new SharedPrefs();

        protected override void OnCreate(Bundle Bundle)
        {
            base.OnCreate(Bundle);
            SetContentView(Resource.Layout.CreateUserProfile);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.SetTitleTextColor(Android.Graphics.Color.White);
            SetSupportActionBar(toolbar);

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

        async void mSubmitUserProfile_Click(object sender, EventArgs e)
        {
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
            
            // Build appuser object
            vmAppUser itemToAdd = new vmAppUser
            {
                AppUserId = mRegisteredId,
                UserName = "",
                PassWord = mRegisteredUser.PassWord,
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

            //convert vmAppUser currentUser to vmMusicianProfile
            mRegisteredUser.AppUserId = currentUser.AppUserId;
            mRegisteredUser.UserName = currentUser.UserName;
            mRegisteredUser.PassWord = currentUser.PassWord;
            mRegisteredUser.LastName = currentUser.LastName;
            mRegisteredUser.FirstName = currentUser.FirstName;
            mRegisteredUser.City = currentUser.City;
            mRegisteredUser.State = currentUser.State;
            mRegisteredUser.PostalCode = currentUser.PostalCode;
            mRegisteredUser.Email = currentUser.Email;
            mRegisteredUser.ReceiveAdvertisements = currentUser.ReceiveAdvertisements;
            mRegisteredUser.IsMusician = currentUser.IsMusician;

            sharedPrefs.saveset(mRegisteredUser);

        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
           
        }
        
    }
}