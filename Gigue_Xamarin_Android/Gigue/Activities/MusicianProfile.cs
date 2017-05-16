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
using Android.Support.V7.App;


namespace Gigue.Activities
{
    [Activity(WindowSoftInputMode = SoftInput.AdjustResize, Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class MusicianProfile : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            Button mEditProfile;
            Button mSearch;
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Profile);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.SetTitleTextColor(Android.Graphics.Color.White);
            SetSupportActionBar(toolbar);

            mSearch = FindViewById<Button>(Resource.Id.btnSearch);
            mSearch.Click += mSearch_Click;

            mEditProfile = FindViewById<Button>(Resource.Id.btnEditProfile);
            mEditProfile.Click += mEditProfile_Click;

            //var lv = FindViewById<ListView>(Resource.Id.listView);

            //lv.Adapter = new ArrayAdapter<User>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, MainActivity.Users);

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

        void mSearch_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Search));

            this.StartActivity(intent);
        }
        void mEditProfile_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(editMusicianProfile));

            this.StartActivity(intent);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }
    }
}