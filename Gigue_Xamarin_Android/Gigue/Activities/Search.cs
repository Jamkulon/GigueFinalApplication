﻿using System;
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
    [Activity(Label = "SearchPage")]
    public class Search : Activity
    {

        Button mSearchResults;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.searchPage);

            mSearchResults = FindViewById<Button>(Resource.Id.btnResults);
            mSearchResults.Click += mSearchResults_Click;

            // Create your application here
        }
        void mSearchResults_Click(object sender, EventArgs r)
        {
            Intent intent = new Intent(this, typeof(searchResults));
            this.StartActivity(intent);
        }
    }
}