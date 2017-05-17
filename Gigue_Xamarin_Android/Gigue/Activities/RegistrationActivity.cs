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
using Android;
using Android.Views.InputMethods;
using Gigue.Adapters;
using Gigue.Activities;
using Gigue.ViewModels;
using Newtonsoft.Json;
using Android.Support.V7.App;

namespace Gigue
{
    [Activity(WindowSoftInputMode = SoftInput.AdjustResize, Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class RegistrationActivity : AppCompatActivity
    {

        LinearLayout rLinearLayout;

        EditText mFirstName;
        EditText mLastName;
        EditText mEmailName;
        EditText mPassword;
        Button mMusician;
        Button mUser;

        public UserData userdata = new UserData();

        //RelativeLayout mRelativeLayout;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Registration);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.SetTitleTextColor(Android.Graphics.Color.White);
            SetSupportActionBar(toolbar);

            mFirstName = FindViewById<EditText>(Resource.Id.txtFirstName);
            mLastName = FindViewById<EditText>(Resource.Id.txtLastName);
            mEmailName = FindViewById<EditText>(Resource.Id.txtEmail);
            mPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            mMusician = FindViewById<Button>(Resource.Id.btnMusician);
            mUser = FindViewById<Button>(Resource.Id.btnUser);
            mMusician.Click += mMusician_Click;
            mUser.Click += mUser_Click;

            rLinearLayout = FindViewById<LinearLayout>(Resource.Id.mainView);
            rLinearLayout.Click += rLinearLayout_Click;

            // Create your application here
        }



        async void mMusician_Click(object sender, EventArgs e)
        {
            // Build appuser object
            vmAppUser itemToAdd = new vmAppUser
            {
                AppUserId = 0,
                UserName = "",
                LastName = mLastName.Text.Trim(),
                FirstName = mFirstName.Text.Trim(),
                City = "",
                State = "",
                PostalCode = "",
                Email = mEmailName.Text.Trim(),
                ReceiveAdvertisements = false,
                IsMusician = false
            };

            //send post request
            vmAppUser currentUser = await userdata.AddAppUser(itemToAdd);

            //Switch to Musician Profile
            Intent intent = new Intent(this, typeof(createMusicianProfile));

            User user = new User()
            {
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                Email = currentUser.Email,
                AppUserId = currentUser.AppUserId
            };
            intent.PutExtra("User", JsonConvert.SerializeObject(user));

            this.StartActivity(intent);
            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }

        async void mUser_Click(object sender, EventArgs e)
        {
            // Build appuser object
            vmAppUser itemToAdd = new vmAppUser
            {
                AppUserId = 0,
                UserName = "",
                LastName = mLastName.Text.Trim(),
                FirstName = mFirstName.Text.Trim(),
                City = "",
                State = "",
                PostalCode = "",
                Email = mEmailName.Text.Trim(),
                ReceiveAdvertisements = false,
                IsMusician = false
            };

            //send post request
            vmAppUser currentUser = await userdata.AddAppUser(itemToAdd);

            //Switch to  User Profile
            Intent intent = new Intent(this, typeof(ThankYou));

            User user = new User()
            {
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                Email = currentUser.Email,
                AppUserId = currentUser.AppUserId
            };

            intent.PutExtra("User", JsonConvert.SerializeObject(user));

            this.StartActivity(intent);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }
        void rLinearLayout_Click(object sender, EventArgs e)
        {
           
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
    }
}