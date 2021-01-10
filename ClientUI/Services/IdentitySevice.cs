using ClientUI.Models.Responses;
using ClientUI.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI.Services
{
    public class IdentitySevice
    {
        public static string BASE_URL = Resource.ApiEndpoint + "Identity/";


        public async Task<string> Login(string email, string password)
        {
            var jsonRequest = JsonConvert.SerializeObject(email);
            HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            string strResponse = "";
            Uri uri = new Uri(BASE_URL + "LoginUser" + "?email=" + email + "&password=" + password);
            using (HttpClient client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "asd5asd98as");
                var response = await client.PostAsync(uri, content);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    strResponse = JsonConvert.DeserializeObject<AuthSuccessResponse>(jsonResponse).token;
                }
            }
            return strResponse;
        }

        public async Task<string> Register(string email, string password)
        {
            var jsonRequest = JsonConvert.SerializeObject(email);
            HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            string strResponse = "";
            Uri uri = new Uri(BASE_URL + "CreateUser" + "?email=" + email + "&password=" + password);
            using (HttpClient client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "asd5asd98as");
                var response = await client.PostAsync(uri, content);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    strResponse = JsonConvert.DeserializeObject<Models.Responses.AuthSuccessResponse>(jsonResponse).token;
                }
            }
            return strResponse;
        }
    }
}
