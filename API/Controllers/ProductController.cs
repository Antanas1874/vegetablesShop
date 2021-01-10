using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    
    public class ProductController : Controller
    {
        [HttpGet("api/v1/product/products")]
        public IActionResult GetAll()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection conn = new SqlConnection(Resources.connString))
            {
                conn.Open();

                SqlCommand selectCommand = new SqlCommand("SELECT * FROM [dbo].[Product]", conn);
                SqlDataReader results = selectCommand.ExecuteReader();

                if (!results.HasRows)
                    return BadRequest("Results of database was empty");

                while (results.Read())
                {
                    Product tempProduct = new Product();
                    tempProduct.id = Convert.ToInt32(results[0]);
                    tempProduct.name = results[1].ToString();
                    tempProduct.description = results[2].ToString();
                    tempProduct.price= Convert.ToDouble(results[3]);
                    products.Add(tempProduct);
                }
            }
            return Ok(products);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("api/v1/product/create")]
        public IActionResult Create(Product product)
        {
            if (product.name == null || product.description == null || product.price == 0)
            {
                return BadRequest("name or description or price was empty");
            }
            using (SqlConnection conn = new SqlConnection(Resources.connString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Product] (Name, Description, Price)" +
                " VALUES('" + product.name + "','" + product.description + "','" + product.price + "')", conn);
                command.ExecuteNonQuery();
                conn.Close();
            }

            return Ok();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("api/v1/product/get/{id}")]
        public IActionResult Get(int id)
        {
            Product tempUser = new Product();

            if (id == 0)
                return BadRequest("Id was 0");

            using (SqlConnection conn = new SqlConnection(Resources.connString))
            {
                conn.Open();

                SqlCommand selectCommand = new SqlCommand("SELECT * FROM [dbo].[Product] WHERE Id=" + id, conn);
                SqlDataReader results = selectCommand.ExecuteReader();

                if (!results.HasRows)
                    return BadRequest("Results of database was empty");

                while (results.Read())
                {
                    tempUser.id = Convert.ToInt32(results[0]);
                    tempUser.name = results[1].ToString();
                    tempUser.description = results[2].ToString();
                    tempUser.price = Convert.ToDouble(results[3]);
                }
            }

            return Ok(tempUser);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("api/v1/product/update")]
        public IActionResult Update(Product product)
        {
            if (product.name == null || product.description == null || product.price == 0)
            {
                return BadRequest("name or description or price was empty");
            }
            using (SqlConnection conn = new SqlConnection(Resources.connString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("UPDATE [dbo].[Product] SET Name='" + product.name + "', Description='" + product.description + "', Price="+product.price + " WHERE Id=" + product.id, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }

            return Ok();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("api/v1/product/delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest("Id was 0");

            using (SqlConnection conn = new SqlConnection(Resources.connString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("DELETE [dbo].[Product] WHERE Id=" + id, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }

            return Ok();
        }
    }
}