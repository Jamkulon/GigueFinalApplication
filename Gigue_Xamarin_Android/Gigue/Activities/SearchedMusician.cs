using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;


namespace Gigue.Activities
{
    [Activity(WindowSoftInputMode = SoftInput.AdjustResize, Theme = ("@style/Theme.AppCompat.Light.NoActionBar"))]
    public class SearchedMusician : AppCompatActivity
    {

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

        void mSearch_Click(object sender, EventArgs e)
        {

            base.OnBackPressed();
            //Intent intent = new Intent(this, typeof(searchResults));

            //this.StartActivity(intent);
            this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }
    }
}