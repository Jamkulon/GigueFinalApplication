using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Gigue.Adapters;
using Gigue.ViewModels;
using Newtonsoft.Json;

namespace Gigue.Activities
{
    [Activity(Theme = ("@android:style/Theme.NoTitleBar"))]
    public class searchResults : Activity
    {
        public UserData userdata = new UserData();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SearchResults);
            
            vmMusicianSearch mSearchParam = JsonConvert.DeserializeObject<vmMusicianSearch>(Intent.GetStringExtra("searchParam"));

            //Perform Search
            GetMusicianSearch(mSearchParam);

        }

        //Get vmMusicianSearch results into adapter         ==================Method not working yet.  =================================
        private async void GetMusicianSearch(vmMusicianSearch searchParam)
        {
            var listText = FindViewById<ListView>(Resource.Id.SearchResultListView);
            List<vmMusicianResult> userinfo = await userdata.GetMusicianSearch(searchParam);
            var users = new List<vmMusicianResult>();
            foreach (var u in (dynamic)userinfo)
            {
                var FirstName = u.FirstName.ToString();
                users.Add(FirstName);
            }
            listText.Adapter = new ArrayAdapter<vmMusicianResult>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, users);
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