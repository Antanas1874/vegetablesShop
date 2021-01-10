using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI.Resources
{
    public static class Resource
    {
        //public static string ApiEndpoint = "https://localhost:5001/api/v1/";
        public static string ApiEndpoint = "http://shopapiv1.azurewebsites.net/api/v1/";

        public static string token;

        public static bool isAdmin = false;

        public static bool isGuest = true;

        public static string email;

        public static int id;

        public static bool loggedIn;

        public static int editingUserOrdersId;

        public static int editingOrderId;

        public static string lastPage;

       public static List<int> cartItems = new List<int>();

        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static List<int> parseProductsToList(string products)
        {
            List<int> ints = new List<int>();
            foreach (var p in products.ToString().Split(',').ToList())
            {
                if (p.Length > 0)
                    ints.Add(Convert.ToInt32(p));
            }
            return ints;
        }

        public static string parseProductsToString(List<int> products)
        {
            string stringProducts = "";
            foreach (var p in products)
            {
                stringProducts += p.ToString() + ",";
            }
            return stringProducts;
        }
    }
}
