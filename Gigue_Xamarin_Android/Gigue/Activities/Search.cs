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
    public class Search : Activity
    {

        Button mSearchResults;
        Button mViewProfile;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.searchPage);

            mSearchResults = FindViewById<Button>(Resource.Id.btnResults);
            mSearchResults.Click += mSearchResults_Click;

            mViewProfile = FindViewById<Button>(Resource.Id.btnViewProfile);
            mViewProfile.Click += mViewProfile_Click;

            Spinner citySpinner = FindViewById<Spinner>(Resource.Id.spinnerCity);

            citySpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var CityAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.cities_array, Android.Resource.Layout.SimpleSpinnerItem);

            CityAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            citySpinner.Adapter = CityAdapter;


            Spinner instrumentSpinner = FindViewById<Spinner>(Resource.Id.spinnerInstrumentPlayed);
            instrumentSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var instrumentAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.instrument_array, Android.Resource.Layout.SimpleSpinnerItem);

            instrumentAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            instrumentSpinner.Adapter = instrumentAdapter;

            // Create your application here
        }
        void mSearchResults_Click(object sender, EventArgs r)
        {
            Intent intent = new Intent(this, typeof(searchResults));
            this.StartActivity(intent);
        }
        void mViewProfile_Click(object sender, EventArgs r)
        {
            Intent intent = new Intent(this, typeof(MusicianProfile));
            this.StartActivity(intent);
        }
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;



        }
    }
}