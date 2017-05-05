﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Gigue.DataObjects;
using System.Text;
using System.Net.Http.Headers;
using System;

namespace Gigue.Adapters
{
    public class UserData
    {
        const string applicationURL = "http://gigue.azurewebsites.net/api/";

        // Add configuration information to http client
        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.BaseAddress = new Uri(applicationURL);
            client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        // Get data parse into list
        public async Task<List<AppUser>> GetAppUsers()
        {
            // Create http client
            HttpClient client = await GetClient();
            // Use GET to retrieve users
            var result = await client.GetStringAsync(string.Concat(applicationURL, "appuser/"));
            // Deserialize JSON Object
            var userdata = JsonConvert.DeserializeObject<List<AppUser>>(result);
            // Parse data into newUsers and return it
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


        // Post new appuser
        public async Task<string> AddAppUser(AppUser itemToAdd)
        {

            HttpClient client = await GetClient();
            var data = JsonConvert.SerializeObject(itemToAdd);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(string.Concat(applicationURL, "appuser/"), content);
            //var result = JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
            var result = response.Content.ReadAsStringAsync().Result;
            return result;

        }

        // Update by Id
        public async Task<int> UpdateTodoItemAsync(int itemIndex, AppUser itemToUpdate)
        {
            HttpClient client = await GetClient();
            var data = JsonConvert.SerializeObject(itemToUpdate);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(string.Concat(applicationURL, itemIndex), content);
            return JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
        }

        // Delete by Id
        public async Task DeleteTodoItemAsync(int itemIndex)
        {
            HttpClient client = await GetClient();
            await client.DeleteAsync(string.Concat(applicationURL, itemIndex));
        }

    }
}