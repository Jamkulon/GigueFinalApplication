using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Gigue.ViewModels;
using System.Text;
using System.Net.Http.Headers;
using System;

namespace Gigue.Adapters
{
    public class UserData
    {
        const string applicationURL = "https://gigue.azurewebsites.net/api/";
        
        // Add configuration information to http client
        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(applicationURL);
            client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        // Get data parse into list
        public async Task<List<vmAppUser>> GetAppUsers()
        {
            // Create http client
            HttpClient client = await GetClient();
            // Use GET to retrieve users
            var result = await client.GetStringAsync(string.Concat(applicationURL, "appuser/"));
            // Deserialize JSON Object
            var userdata = JsonConvert.DeserializeObject<List<vmAppUser>>(result);
            // Parse data into newUsers and return it
            var newUsers = new List<vmAppUser>();
            foreach (var user in userdata)
            {
                var newuser = new vmAppUser()
                {
                    AppUserId = user.AppUserId,
                    UserName = user.UserName
                };
                newUsers.Add(user);
            }
            return newUsers;
        }

        // Get Musician Search
        public async Task<List<vmMusicianResult>> GetMusicianSearch(vmMusicianSearch mSearchParam)
        {
            // Create http client
            HttpClient client = await GetClient();
            //Serialize object to JSON
            var data = JsonConvert.SerializeObject(mSearchParam);
            //Convert it to a formated stringcontent byte array
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            //Send the data

            var response = await client.PostAsync(string.Concat(applicationURL, "musiciansearch/"), content);
            //return the response as a vmMusicianSearch object
            var userMusicians = JsonConvert.DeserializeObject<List<vmMusicianResult>>(
                await response.Content.ReadAsStringAsync());
            //List<vmMusicianResult> musicianResults = new List<vmMusicianResult>();

            //foreach (var m in userMusicians)
            //{
            //    var newmusician = new vmMusicianResult()
            //    {
            //        AppUserId = m.AppUserId,
            //        FirstName = m.FirstName,
            //        LastName = m.LastName,
            //        City = m.City,
            //        PrimeInstrument = m.PrimeInstrument
            //    };
            //    musicianResults.Add(newmusician);
            //}
            return userMusicians;




            //List<vmMusicianResult> myJSON = JsonConvert.DeserializeObject<vmMusicianResult>(
            //    await response.Content.ReadAsStringAsync());

            //return myJSON;

            // Parse data into newUsers and return it
            //var newUsers = new List<vmMusicianResult>();
            //foreach (var user in response)
            //{
            //    var newuser = new vmMusicianSearch()
            //    {
            //        AppUserId = user.AppUserId,
            //        UserName = user.UserName
            //    };
            //    newUsers.Add(user);
            //}
            //return newUsers;

        }

        // Post new appuser
        public async Task<vmAppUser> AddAppUser(vmAppUser itemToAdd)
        {
            // Create http client
            HttpClient client = await GetClient();
            //Serialize object to JSON
            var data = JsonConvert.SerializeObject(itemToAdd);
            //Convert it to a formated stringcontent byte array
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            //Send the data
            var response = await client.PostAsync(string.Concat(applicationURL, "appuser/"), content);
            //return the response as a vmAppUser object
            return JsonConvert.DeserializeObject<vmAppUser>(
                await response.Content.ReadAsStringAsync());

        }

        // Update by Id
        public async Task<vmAppUser> UpdateAppUser(int appUserId, vmAppUser itemToUpdate)
        {
            // Create http client
            HttpClient client = await GetClient();
            //Serialize object to JSON
            var data = JsonConvert.SerializeObject(itemToUpdate);
            //Convert it to a formated stringcontent byte array
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            //Send the data
            var response = await client.PutAsync(string.Concat(applicationURL, appUserId), content);
            //return the response as a vmAppUser object
            return JsonConvert.DeserializeObject<vmAppUser>(
                await response.Content.ReadAsStringAsync());
        } 
        // Delete by Id
        public async Task<bool> DeleteTodoItemAsync(int itemIndex)
        {
            HttpClient client = await GetClient();
            var response = await client.DeleteAsync(string.Concat(applicationURL, itemIndex));
            return response.IsSuccessStatusCode;
        }

    }
}