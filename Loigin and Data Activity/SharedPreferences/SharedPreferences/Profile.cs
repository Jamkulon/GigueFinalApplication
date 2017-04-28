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

namespace SharedPreferences
{
    [Activity(Label = "Profile")]
    public class Profile : Activity
    {
        public static List<User> Users = new List<User>();

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Profile);


            Users.Add(new User("Bob", "123"));
            Users.Add(new User("Geoffrey", "123"));
            Users.Add(new User("James", "123"));
            Users.Add(new User("Joel", "123"));



            var lv = FindViewById<ListView>(Resource.Id.listView);

            lv.Adapter = new ArrayAdapter<User>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, Users);

        }
    }
}