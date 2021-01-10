using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.Options
{
    public static class Resources
    {
        public static string connString = "Server=tcp:shopdatabasev1.database.windows.net,1433;Initial Catalog=shopdata;Persist Security Info=False;User ID=shopadmin;Password=AdminAdmin1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        //public static string connString = "Server=(localdb)\\mssqllocaldb;Database=aspnet-API-1D84B520-24B5-43E0-AD35-4E86FFBD5A1F;Trusted_Connection=True;MultipleActiveResultSets=true";

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
                if (p.Length>0)
                ints.Add(Convert.ToInt32(p));
            }
            return ints;

            //return products[1].ToString().Split(',').Where(x => !x.Equals("")).ToList().ConvertAll(int.Parse);
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