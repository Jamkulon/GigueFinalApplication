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
            //Console.WriteLine(userMusicians.Count);
            return userMusicians;

        }

        // Get Musician Search by Id
        public async Task<vmMusicianProfile> GetMusicianSearchById(int userid)
        {
            // Create http client
            HttpClient client = await GetClient();
            //Serialize object to JSON
            var data = JsonConvert.SerializeObject(userid);
            //Convert it to a formated stringcontent byte array
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            //Send the data
            var response = await client.PostAsync(string.Concat(applicationURL, "musicianprofile/"), content);
            //return the response as a vmMusicianSearch object
            var userMusician = JsonConvert.DeserializeObject<vmMusicianProfile>(
                await response.Content.ReadAsStringAsync());
            //Console.WriteLine(userMusicians[0].LastName);
            return userMusician;

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

        // Update vmAppUser by Id
        public async Task<vmAppUser> UpdateAppUser(vmAppUser itemToUpdate)
        {
            // Create http client
            HttpClient client = await GetClient();
            //Serialize object to JSON
            var data = JsonConvert.SerializeObject(itemToUpdate);
            //Convert it to a formated stringcontent byte array
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            //Send the data
            var response = await client.PutAsync(string.Concat(applicationURL, "appuser/"), content);
            //return the response as a vmAppUser object
            return JsonConvert.DeserializeObject<vmAppUser>(
                await response.Content.ReadAsStringAsync());
        }

        // Update vmMusicianProfile by Id
        public async Task<vmMusicianProfile> UpdateMusician(int appUserId, vmMusicianProfile itemToUpdate)
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
            return JsonConvert.DeserializeObject<vmMusicianProfile>(
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