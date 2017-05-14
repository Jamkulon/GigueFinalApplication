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

namespace Gigue.Activities
{
    [Activity(WindowSoftInputMode = SoftInput.AdjustResize, Theme = ("@android:style/Theme.NoTitleBar"))]
    public class MusicianProfile : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            Button mEditProfile;
            Button mSearch;
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Profile);

            mSearch = FindViewById<Button>(Resource.Id.btnSearch);
            mSearch.Click += mSearch_Click;

            mEditProfile = FindViewById<Button>(Resource.Id.btnEditProfile);
            mEditProfile.Click += mEditProfile_Click;

            //var lv = FindViewById<ListView>(Resource.Id.listView);

            //lv.Adapter = new ArrayAdapter<User>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, MainActivity.Users);

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