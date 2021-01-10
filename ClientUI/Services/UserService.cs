using ClientUI.Models;
using ClientUI.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI.Services
{
    public class UserService
    {
        public static string BASE_URL = Resource.ApiEndpoint + "user/";

        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = new List<User>();
            Uri uri = new Uri(BASE_URL + "users");
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Resource.token);
                var response = await client.GetAsync(uri);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    users = JsonConvert.DeserializeObject<List<User>>(jsonResponse);
                }
                return users;
            }
        }

        public async Task Create(User user)
        {
            var jsonRequest = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            Uri uri = new Uri(BASE_URL + "create?email=" + user.email + "&password=" + user.password);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.PostAsync(uri, content);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {

                }
            }
        }

        public async Task<User> Get(int id)
        {
            User user = new User();

            Uri uri = new Uri(BASE_URL + "get/" + id.ToString());
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Resource.token);
                var response = await client.GetAsync(uri);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    user = JsonConvert.DeserializeObject<User>(jsonResponse);
                }
            }

            return user;
        }

        public async Task<User> GetByEmail(string email)
        {
            User user = new User();

            Uri uri = new Uri(BASE_URL + "getByEmail/" + email.ToString());
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Resource.token);
                var response = await client.GetAsync(uri);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    user = JsonConvert.DeserializeObject<User>(jsonResponse);
                }
            }

            return user;
        }

        public async Task Update(User user)
        {
            var jsonRequest = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            Uri uri = new Uri(BASE_URL + "update?id=" + user.id + "&email=" + user.email + "&password=" + user.password);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Resource.token);
                var response = await client.PostAsync(uri, content);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {

                }
            }
        }

        public async Task Delete(int id)
        {
            HttpContent content = null;
            Uri uri = new Uri(BASE_URL + "delete/"+id);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Resource.token);
                var response = await client.PostAsync(uri, content);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {

                }
            }
        }

    }
}
