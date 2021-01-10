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
    public class OrderService
    {
        public static string BASE_URL = Resource.ApiEndpoint + "order/";

        public async Task<List<Order>> GetAllProducts()
        {
            List<Order> orders = new List<Order>();

            Uri uri = new Uri(BASE_URL + "orders");
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Resource.token);
                var response = await client.GetAsync(uri);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    orders = JsonConvert.DeserializeObject<List<Order>>(jsonResponse);
                }
                return orders;
            }
        }

        public async Task Create(Order order)
        {
            var jsonRequest = JsonConvert.SerializeObject(order);
            HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            string prodString = "";
            foreach (var item in Resource.cartItems)
            {
                prodString += "products=" + item.ToString() + "&";
            }
            Uri uri = new Uri(BASE_URL + "create?" + prodString + "address=" + order.address.Replace(" ", "%20") + "&deliveryType=" + order.deliveryType + "&fk_user=" + Resource.id);
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

        public async Task<Order> Get(int id)
        {
            Order order = new Order();

            Uri uri = new Uri(BASE_URL + "get/" + id.ToString());
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Resource.token);
                var response = await client.GetAsync(uri);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    order = JsonConvert.DeserializeObject<Order>(jsonResponse);
                }
            }

            return order;
        }

        public async Task Update(Order order)
        {
            var jsonRequest = JsonConvert.SerializeObject(order);
            HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            string prodString = "";
            foreach (var item in order.products)
            {
                prodString += "products=" + item.ToString() + "&";
            }
            string address = @order.address.Replace(" ", "%20");
            Uri uri = new Uri(BASE_URL + "update?id=" + order.id + "&" + prodString + "address=" + @address + "&deliveryType=" + order.deliveryType + "&fk_user=" + order.fk_User);
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
            Uri uri = new Uri(BASE_URL + "delete/" + id);
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

        public async Task<List<Order>> GetAllUserProducts(int id)
        {
            List<Order> orders = new List<Order>();

            Uri uri = new Uri(BASE_URL + "userOrders/"+id.ToString());
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Resource.token);
                var response = await client.GetAsync(uri);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    orders = JsonConvert.DeserializeObject<List<Order>>(jsonResponse);
                }
                return orders;
            }
        }


    }
}
