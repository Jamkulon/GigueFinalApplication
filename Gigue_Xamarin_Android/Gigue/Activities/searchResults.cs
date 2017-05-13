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
            
            //GetUsers();

            //GetMusicianSearch(mSearchParam);

            AddUser();
        }

        //Get vmMusicianSearch results into adapter
        private async void GetMusicianSearch(vmMusicianSearch searchParam)
        {
            var MSListView = FindViewById<ListView>(Resource.Id.SearchResultListView);
            var MSInfo = await userdata.GetMusicianSearch(searchParam);
            var users = new List<vmMusicianSearch>();
            //foreach (var u in MSInfo)
            //{
            //    var userName = u.UserName.ToString();
            //    users.Add(userName);
            //}
            MSListView.Adapter = new ArrayAdapter<vmMusicianSearch>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, users);
        }

        //get usersnames from list diplsy on activity
        private async void GetUsers()
        {
            var listText = FindViewById<ListView>(Resource.Id.SearchResultListView);
            var userinfo = await userdata.GetAppUsers();
            var users = new List<string>();
            foreach (var u in (dynamic)userinfo)
            {
                var userName = u.UserName.ToString();
                users.Add(userName);
            }
            listText.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, users);
        }

        public async void AddUser()
        {

            var user = new vmAppUser()
            {
                FirstName = "Test",
                LastName = "User4",
                UserName = "tu4@mail.com"

            };
            await userdata.AddAppUser(user);
        }
    }
}