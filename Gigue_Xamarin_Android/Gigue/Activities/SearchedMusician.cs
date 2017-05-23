using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Newtonsoft.Json;
using Gigue.ViewModels;

namespace Gigue.Activities
{
    [Activity(WindowSoftInputMode = SoftInput.AdjustResize, Theme = ("@style/Theme.AppCompat.Light.NoActionBar"))]
    public class SearchedMusician : AppCompatActivity
    {
        vmMusicianProfile mRegisteredUser;
        Button mSearch;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.searchedMusician);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.SetTitleTextColor(Android.Graphics.Color.White);
            SetSupportActionBar(toolbar);


            mSearch = FindViewById<Button>(Resource.Id.btnBackToSearch);
            mSearch.Click += mSearch_Click;
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
            if (id == Resource.Id.tool_Login)
            {
                StartActivity(typeof(Login));
                return true;
            }
            else if (id == Resource.Id.tool_search)
            {
                mRegisteredUser = retrieveset();
                Intent intent = new Intent(this, typeof(Search));
                intent.PutExtra("User", JsonConvert.SerializeObject(mRegisteredUser));
                StartActivity(intent);
                return true;
            }
            else if (id == Resource.Id.tool_infoPage)
            {
                StartActivity(typeof(InformationPage));
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }
        public vmMusicianProfile retrieveset()
        {
            string strMusicianProfile;
            vmMusicianProfile vmProf;
            //Retreive existing records
            var prefs = Application.Context.GetSharedPreferences("GIGUE", FileCreationMode.Private);
            strMusicianProfile = prefs.GetString("profile", null);
            //If email is null, return new vmMusicianProfile
            if (strMusicianProfile == null)
            {
                mRegisteredUser = new vmMusicianProfile();
                return mRegisteredUser;
            }
            else
            {
                vmProf = JsonConvert.DeserializeObject<vmMusicianProfile>(strMusicianProfile);
                if (vmProf == null)
                {
                    mRegisteredUser = new vmMusicianProfile();
                    return mRegisteredUser;
                }
                else
                {
                    mRegisteredUser = vmProf;
                    return mRegisteredUser;
                }
            }
        }
        void mSearch_Click(object sender, EventArgs e)
        {

            base.OnBackPressed();
            //Intent intent = new Intent(this, typeof(searchResults));

            //this.StartActivity(intent);
            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }
    }
}