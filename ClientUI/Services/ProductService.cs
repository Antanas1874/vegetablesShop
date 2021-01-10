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
    public class ProductService
    {
        public static string BASE_URL = Resource.ApiEndpoint + "product/";

        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            Uri uri = new Uri(BASE_URL + "products");
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Resource.token);
                var response = await client.GetAsync(uri);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    products = JsonConvert.DeserializeObject<List<Product>>(jsonResponse);
                }
                return products;
            }
        }

        public async Task Create(Product product)
        {
            var jsonRequest = JsonConvert.SerializeObject(product);
            HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            Uri uri = new Uri(BASE_URL + "create?name=" + product.name + "&description=" + product.description + "&price=" + product.price);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Resource.token);
                var response = await client.PostAsync(uri, content);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {

                }
            }
        }

        public async Task<Product> Get(int id)
        {
            Product product = new Product();

            Uri uri = new Uri(BASE_URL + "get/" + id.ToString());
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Resource.token);
                var response = await client.GetAsync(uri);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    product = JsonConvert.DeserializeObject<Product>(jsonResponse);
                }
            }

            return product;
        }

        public async Task Update(Product product)
        {
            var jsonRequest = JsonConvert.SerializeObject(product);
            HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            Uri uri = new Uri(BASE_URL + "update?id=" + product.id + "&name=" + product.name + "&description=" + product.description + "&price=" + product.price);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Resource.token);
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
            Uri uri = new Uri(BASE_URL + "delete/" + id);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Resource.token);
                var response = await client.PostAsync(uri, content);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {

                }
            }
        }
    }
}
