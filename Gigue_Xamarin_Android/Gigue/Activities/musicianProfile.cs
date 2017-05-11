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

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.musicianProfile);


            //var lv = FindViewById<ListView>(Resource.Id.listView);

            //lv.Adapter = new ArrayAdapter<User>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, MainActivity.Users);

        }
    }
}