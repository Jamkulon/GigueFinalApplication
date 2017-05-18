using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Gigue.Adapters;
using Gigue.Activities;
using Gigue.ViewModels;
using Newtonsoft.Json;
using Android.Support.V7.App;
using Gigue.Classes;

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
        vmMusicianProfile mRegisteredUser;

        public UserData userdata = new UserData();
        public SharedPrefs sharedPrefs = new SharedPrefs();

        //RelativeLayout mRelativeLayout;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Registration);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.SetTitleTextColor(Android.Graphics.Color.White);
            SetSupportActionBar(toolbar);

            mRegisteredUser = JsonConvert.DeserializeObject<vmMusicianProfile>(Intent.GetStringExtra("User"));

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

        }



        async void mMusician_Click(object sender, EventArgs e)
        {
            // Build appuser object
            vmAppUser itemToAdd = new vmAppUser
            {
                AppUserId = 0,
                UserName = "",
                PassWord = mPassword.Text.Trim(),
                LastName = mLastName.Text.Trim(),
                FirstName = mFirstName.Text.Trim(),
                City = "",
                State = "",
                PostalCode = "",
                Email = mEmailName.Text.Trim(),
                ReceiveAdvertisements = false,
                IsMusician = false
            };

            //Test for bad user info
            //if (String.IsNullOrWhiteSpace(mFirstName.Text) || String.IsNullOrWhiteSpace(mLastName.Text) || String.IsNullOrWhiteSpace(mEmailName.Text) || String.IsNullOrWhiteSpace(mPassword.Text))
            //{
            //    mFirstName.SetError("All fields are required!", );
            //    Finish();
            //}

                        //send post request
            vmAppUser currentUser = await userdata.AddAppUser(itemToAdd);

            //convert vmAppUser currentUser to vmMusicianProfile mRegisteredUser
            //mRegisteredUser.UserName = currentUser.UserName;
            //mRegisteredUser.PassWord = currentUser.PassWord;
            //mRegisteredUser.LastName = currentUser.LastName;
            //mRegisteredUser.FirstName = currentUser.FirstName;
            //mRegisteredUser.City = currentUser.City;
            //mRegisteredUser.State = currentUser.State;
            //mRegisteredUser.PostalCode = currentUser.PostalCode;
            //mRegisteredUser.Email = currentUser.Email;
            //mRegisteredUser.ReceiveAdvertisements = currentUser.ReceiveAdvertisements;
            //mRegisteredUser.IsMusician = currentUser.IsMusician;

            //sharedPrefs.saveset(mRegisteredUser);

            //Switch to Musician Profile
            Intent intent = new Intent(this, typeof(createMusicianProfile));

            intent.PutExtra("User", JsonConvert.SerializeObject(mRegisteredUser));

            this.StartActivity(intent);
            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }

        //private void GoToRegPage()
        //{
        //    Intent goback = new Intent(this, typeof(RegistrationActivity));

        //    StartActivity(goback);
        //    OverridePendingTransition(Resource.Animation.slide_in_bottom, Resource.Animation.slide_out_top);
        //    //Finish();
        //}

        async void mUser_Click(object sender, EventArgs e)

        {
            // Build appuser object
            vmAppUser itemToAdd = new vmAppUser
            {
                AppUserId = 0,
                UserName = "",
                //PassWord = mPassword.Text.Trim(),
                LastName = mLastName.Text.Trim(),
                FirstName = mFirstName.Text.Trim(),
                City = "",
                State = "",
                PostalCode = "",
                Email = mEmailName.Text.Trim(),
                ReceiveAdvertisements = false,
                IsMusician = false
            };

            //Test for bad user info

            //if (String.IsNullOrWhiteSpace(mFirstName.Text) || String.IsNullOrWhiteSpace(mLastName.Text) || String.IsNullOrWhiteSpace(mEmailName.Text) || String.IsNullOrWhiteSpace(mPassword.Text))
            //{
            //    mFirstName.SetError("All fields are required!", );
            //    Finish();
            //}

           

            //send post request
            vmAppUser currentUser = await userdata.AddAppUser(itemToAdd);

            //convert vmAppUser currentUser to vmMusicianProfile mRegisteredUser
            //mRegisteredUser.AppUserId = currentUser.AppUserId;
            //mRegisteredUser.UserName = currentUser.UserName;
            //mRegisteredUser.PassWord = currentUser.PassWord;
            //mRegisteredUser.LastName = currentUser.LastName;
            //mRegisteredUser.FirstName = currentUser.FirstName;
            //mRegisteredUser.City = currentUser.City;
            //mRegisteredUser.State = currentUser.State;
            //mRegisteredUser.PostalCode = currentUser.PostalCode;
            //mRegisteredUser.Email = currentUser.Email;
            //mRegisteredUser.ReceiveAdvertisements = currentUser.ReceiveAdvertisements;
            //mRegisteredUser.IsMusician = currentUser.IsMusician;

            //sharedPrefs.saveset(mRegisteredUser);

            //Switch to  User Profile
            Intent intent = new Intent(this, typeof(ThankYou));

            mRegisteredUser.FirstName = currentUser.FirstName;
            mRegisteredUser.LastName = currentUser.LastName;
            mRegisteredUser.Email = currentUser.Email;
            mRegisteredUser.AppUserId = currentUser.AppUserId;

            intent.PutExtra("User", JsonConvert.SerializeObject(mRegisteredUser));
            
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

                return true;
            }
            else if (id == Resource.Id.tool_search)
            {

                return true;
            }
            else if (id == Resource.Id.tool_infoPage)
            {

                return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}