using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Gigue.ViewModels;
using Android.Views.InputMethods;
using Gigue.Classes;
using System.Threading;

namespace Gigue.Activities
{
    [Activity (WindowSoftInputMode = SoftInput.AdjustResize, Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
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

        LinearLayout mLinearLayout;

        public SharedPrefs sharedPrefs = new SharedPrefs();
        private int progressBarStatus;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CreateMusicianProfile);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.SetTitleTextColor(Android.Graphics.Color.White);
            SetSupportActionBar(toolbar);

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

            mLinearLayout = FindViewById<LinearLayout>(Resource.Id.mainView);
            mLinearLayout.Click += mLinearLayout_Click;

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

            //convert vmAppUser itemToAdd to vmMusicianProfile mRegisteredUser
            mRegisteredUser.AppUserId = itemToAdd.AppUserId;
            mRegisteredUser.UserName = itemToAdd.UserName;
            mRegisteredUser.PassWord = itemToAdd.PassWord;
            mRegisteredUser.LastName = itemToAdd.LastName;
            mRegisteredUser.FirstName = itemToAdd.FirstName;
            mRegisteredUser.City = itemToAdd.City;
            mRegisteredUser.State = itemToAdd.State;
            mRegisteredUser.PostalCode = itemToAdd.PostalCode;
            mRegisteredUser.Email = itemToAdd.Email;
            mRegisteredUser.ReceiveAdvertisements = itemToAdd.ReceiveAdvertisements;
            mRegisteredUser.IsMusician = itemToAdd.IsMusician;

            sharedPrefs.saveset(mRegisteredUser);
            
            //send post request
            vmAppUser currentUser = await userdata.UpdateAppUser(itemToAdd);

            ProgressDialog progressBar = new ProgressDialog(this);
            progressBar.SetCancelable(true);
            progressBar.SetProgressStyle(ProgressDialogStyle.Horizontal);
            progressBar.Progress = 0;
            progressBar.Max = 100;
            progressBar.Show();
            progressBarStatus = 0;

            //Run Thread and increase preogress value
            new Thread(new ThreadStart(delegate {

                while (progressBarStatus < 100)
                {
                    progressBarStatus += 10;
                    progressBar.Progress += progressBarStatus;
                    Thread.Sleep(100);
                }
              
            })).Start();

            Intent intent = new Intent(this, typeof(Search));
            this.StartActivity(intent);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }
        void mLinearLayout_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }
    }
}
