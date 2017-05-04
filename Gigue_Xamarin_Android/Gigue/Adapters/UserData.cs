using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Gigue.DataObjects;

namespace Gigue.Adapters
{
    public class UserData
    {
        const string applicationURL = "http://gigue.azurewebsites.net/api/";

        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");


            return client;
        }

        //get data parse into list
        public async Task<List<AppUser>> GetUsers()
        {
            // TODO: use GET to retrieve users
            HttpClient client = await GetClient();
            //HttpClient client = new HttpClient();
            var result = await client.GetStringAsync(applicationURL + "appuser");
            //
            var userdata = JsonConvert.DeserializeObject<List<AppUser>>(result);
            var newUsers = new List<AppUser>();
            foreach (var user in userdata)
            {
                var newuser = new AppUser()
                {
                    AppUserId = user.AppUserId,
                    UserName = user.UserName

                };
                newUsers.Add(user);
            }

            return newUsers;
        }
    }
}