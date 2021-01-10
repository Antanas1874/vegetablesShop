using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using Microsoft.Data.SqlClient;
using API.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrdersController : Controller
    {
        [HttpGet("api/v1/order/orders")]
        public IActionResult GetAll()
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection conn = new SqlConnection(Resources.connString))
            {
                conn.Open();

                SqlCommand selectCommand = new SqlCommand("SELECT * FROM [dbo].[Order]", conn);
                SqlDataReader results = selectCommand.ExecuteReader();

                if (!results.HasRows)
                    return BadRequest("Results of database was empty");

                while (results.Read())
                {
                    Order tempOrder = new Order();
                    tempOrder.id = Convert.ToInt32(results[0]);
                    tempOrder.products = Resources.parseProductsToList(results[1].ToString());
                    tempOrder.address = results[2].ToString();
                    tempOrder.deliveryType = results[3].ToString();
                    tempOrder.fk_User = Convert.ToInt32(results[4].ToString());
                    orders.Add(tempOrder);
                }
            }
            return Ok(orders);
        }

        [HttpPost("api/v1/order/create")]
        public IActionResult Create(Order order)
        {
            if (order.address == null || order.products.Count == 0)
            {
                return BadRequest("address or products was empty");
            }
            using (SqlConnection conn = new SqlConnection(Resources.connString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Order] (products, address, deliveryType, fk_User)" +
                " VALUES('" + Resources.parseProductsToString(order.products) + "','" + order.address + "','" +
                order.deliveryType + "', '" + order.fk_User + "')", conn);
                command.ExecuteNonQuery();
                conn.Close();
            }

            return Ok();
        }

        [HttpGet("api/v1/order/get/{id}")]
        public IActionResult Get(int id)
        {
            Order tempOrder = new Order();

            if (id == 0)
                return BadRequest("Id was 0");

            using (SqlConnection conn = new SqlConnection(Resources.connString))
            {
                conn.Open();

                SqlCommand selectCommand = new SqlCommand("SELECT * FROM [dbo].[Order] WHERE id=" + id, conn);
                SqlDataReader results = selectCommand.ExecuteReader();

                if (!results.HasRows)
                    return BadRequest("Results of database was empty");

                while (results.Read())
                {
                    tempOrder.id = Convert.ToInt32(results[0]);
                    tempOrder.products = Resources.parseProductsToList(results[1].ToString());
                    tempOrder.address = results[2].ToString();
                    tempOrder.deliveryType = results[3].ToString();
                    tempOrder.fk_User = Convert.ToInt32(results[4].ToString());
                }
            }

            return Ok(tempOrder);
        }

        [HttpPost("api/v1/order/update")]
        public IActionResult Update(Order order)
        {
            if (order.products == null)
            {
                return BadRequest("products was empty");
            }
            if (order.address == null || order.products.Count == 0)
            {
                return BadRequest("address or products was empty");
            }
            using (SqlConnection conn = new SqlConnection(Resources.connString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("UPDATE [dbo].[Order] SET products='" + Resources.parseProductsToString(order.products) +
                    "', address='" + order.address + "', deliveryType='" + order.deliveryType+ "' WHERE Id=" + order.id, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }

            return Ok();
        }

        [HttpPost("api/v1/order/delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest("Id was 0");

            using (SqlConnection conn = new SqlConnection(Resources.connString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("DELETE [dbo].[Order] WHERE Id=" + id, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }

            return Ok();
        }

        [HttpGet("api/v1/order/userOrders/{id}")]
        public IActionResult GetAllByUser(int id)
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection conn = new SqlConnection(Resources.connString))
            {
                conn.Open();

                SqlCommand selectCommand = new SqlCommand("SELECT * FROM [dbo].[Order] WHERE fk_User="+id.ToString(), conn);
                SqlDataReader results = selectCommand.ExecuteReader();

                if (!results.HasRows)
                    return BadRequest("Results of database was empty");

                while (results.Read())
                {
                    Order tempOrder = new Order();
                    tempOrder.id = Convert.ToInt32(results[0]);
                    tempOrder.products = Resources.parseProductsToList(results[1].ToString());
                    tempOrder.address = results[2].ToString();
                    tempOrder.deliveryType = results[3].ToString();
                    tempOrder.fk_User = Convert.ToInt32(results[4].ToString());
                    orders.Add(tempOrder);
                }
            }
            return Ok(orders);
        }
    }
}