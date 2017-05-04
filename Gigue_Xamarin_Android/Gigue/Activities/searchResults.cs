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
using Gigue.Adapters;

namespace Gigue.Activities
{
    [Activity(Label = "searchResults")]
    public class searchResults : Activity
    {
        public UserData userdata = new UserData();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SearchResults);

            GetUsers();
        }

        //get usersnames from list diplsy on activity
        private async void GetUsers()
        {
            var listText = FindViewById<ListView>(Resource.Id.SearchResultListView);
            var userinfo = await userdata.GetUsers();
            var users = new List<string>();
            foreach (var u in userinfo)
            {
                var userName = u.UserName.ToString();
                users.Add(userName);
            }
            listText.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, users);
        }
    }
}