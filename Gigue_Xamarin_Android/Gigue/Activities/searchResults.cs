using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Gigue.Adapters;
using Gigue.ViewModels;
using Newtonsoft.Json;
using System;

namespace Gigue.Activities
{
    [Activity(Theme = ("@android:style/Theme.NoTitleBar"))]
    public class searchResults : Activity
    {
        public UserData userdata = new UserData();
        public List<vmMusicianResult> userinfo;
        private ListView mListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SearchResults);

            mListView = FindViewById<ListView>(Resource.Id.SearchResultListView);
            
            vmMusicianSearch mSearchParam = JsonConvert.DeserializeObject<vmMusicianSearch>(Intent.GetStringExtra("searchParam"));

            //Perform Search
            GetMusicianSearch(mSearchParam);

        }

        //Get vmMusicianSearch results into adapter         ==================Method not working yet.  =================================
        private async void GetMusicianSearch(vmMusicianSearch searchParam)
        {
            
            userinfo = await userdata.GetMusicianSearch(searchParam);

            SearchListAdapter adapter = new SearchListAdapter(this, userinfo);
            mListView.Adapter = adapter;
            mListView.ItemClick += MListView_ItemClick;


            //mListView.Adapter = new ArrayAdapter<vmMusicianResult>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, users);
        }

        private void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.WriteLine(userinfo[e.Position].LastName);
        }

        //get usersnames from list diplsy on activity     ==================Old List Method =====================
        //private async void GetUsers()
        //{
        //    var listText = FindViewById<ListView>(Resource.Id.SearchResultListView);
        //    var userinfo = await userdata.GetAppUsers();
        //    var users = new List<string>();
        //    foreach (var u in (dynamic)userinfo)
        //    {
        //        var userName = u.UserName.ToString();
        //        users.Add(userName);
        //    }
        //    listText.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, users);
        //}
    }
}