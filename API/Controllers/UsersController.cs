using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Responses;
using API.Models;
using API.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : Controller
    {
        [HttpGet("api/v1/user/users")]
        public IActionResult GetAll()
        {
            List<User> users = new List<User>();
            using (SqlConnection conn = new SqlConnection(Resources.connString))
            {
                conn.Open();

                SqlCommand selectCommand = new SqlCommand("SELECT * FROM [dbo].[User]", conn);
                SqlDataReader results = selectCommand.ExecuteReader();

                if (!results.HasRows)
                    return BadRequest("Results of database was empty");

                while (results.Read())
                {
                    User tempUser = new User();
                    tempUser.id = Convert.ToInt32(results[0]);
                    tempUser.email = results[1].ToString();
                    tempUser.password = results[2].ToString();
                    tempUser.role = results[3].ToString();
                    users.Add(tempUser);
                }
            }

            foreach(var u in users)
            {
                u.email = u.email.TrimEnd();
                u.password = u.password.TrimEnd();
                u.role = u.role.TrimEnd();
            }

            return Ok(users);
        }

        [HttpPost("api/v1/user/create")]
        public IActionResult Create(User user)
        {
            if (user.email == null || user.password == null)
            {
                return BadRequest("email or password was empty");
            }
            using (SqlConnection conn = new SqlConnection(Resources.connString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[User] (email, password, role)" +
                " VALUES('" + user.email + "','" + user.password + "','" + 1 + "')", conn);
                command.ExecuteNonQuery();
                conn.Close();
            }

            return Ok();
        }

        [HttpGet("api/v1/user/get/{id}")]
        public IActionResult Get(int id)
        {
            User tempUser = new User();

            if (id == 0)
                return BadRequest("Id was 0");

            using (SqlConnection conn = new SqlConnection(Resources.connString))
            {
                conn.Open();

                SqlCommand selectCommand = new SqlCommand("SELECT * FROM [dbo].[User] WHERE Id=" + id, conn);
                SqlDataReader results = selectCommand.ExecuteReader();

                if (!results.HasRows)
                    return BadRequest("Results of database was empty");

                while (results.Read())
                {
                    tempUser.id = Convert.ToInt32(results[0]);
                    tempUser.email = results[1].ToString();
                    tempUser.password = results[2].ToString();
                    tempUser.role = results[3].ToString();
                }
            }

            return Ok(tempUser);
        }

        [HttpGet("api/v1/user/getByEmail/{email}")]
        public IActionResult GetByEmail(string email)
        {
            User tempUser = new User();

            if (email.Length < 1)
                return BadRequest("Email was empty");

            using (SqlConnection conn = new SqlConnection(Resources.connString))
            {
                conn.Open();

                SqlCommand selectCommand = new SqlCommand("SELECT * FROM [dbo].[User] WHERE email='" + email + "'", conn);
                SqlDataReader results = selectCommand.ExecuteReader();

                if (!results.HasRows)
                    return BadRequest("Results of database was empty");

                while (results.Read())
                {
                    tempUser.id = Convert.ToInt32(results[0]);
                    tempUser.email = results[1].ToString();
                    tempUser.password = results[2].ToString();
                    tempUser.role = results[3].ToString();
                }
            }

            return Ok(tempUser);
        }

        [HttpPost("api/v1/user/update")]
        public IActionResult Update(User user)
        {
            if (user.email == null || user.password == null)
            {
                return BadRequest("email or password was empty");
            }
            using (SqlConnection conn = new SqlConnection(Resources.connString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("UPDATE [dbo].[User] SET email='" + user.email + "', password='" + user.password + "' WHERE Id=" + user.id, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }

            return Ok();
        }

        [HttpPost("api/v1/user/delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest("Id was 0");

            using (SqlConnection conn = new SqlConnection(Resources.connString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("DELETE [dbo].[User] WHERE Id=" + id, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }

            return Ok();
        }

        public EmailExistingResponse IsExistingEmail(string email)
        {
            bool emailExisting = false;
            User foundUser = new User();
            List<User> users = new List<User>();
            using (SqlConnection conn = new SqlConnection(Resources.connString))
            {
                conn.Open();

                SqlCommand selectCommand = new SqlCommand("SELECT * FROM [dbo].[User]", conn);
                SqlDataReader results = selectCommand.ExecuteReader();

                if (!results.HasRows)
                    return new EmailExistingResponse
                    {
                        isExisting = false
                    };

                while (results.Read())
                {
                    User tempUser = new User();
                    tempUser.id = Convert.ToInt32(results[0]);
                    tempUser.email = results[1].ToString();
                    tempUser.password = results[2].ToString();
                    tempUser.role = results[3].ToString();
                    users.Add(tempUser);
                }
            }

            foreach (var u in users)
            {
                u.email = u.email.TrimEnd();
                u.password = u.password.TrimEnd();
                u.role = u.role.TrimEnd();

                if (u.email.Equals(email))
                {
                    emailExisting = true;
                    foundUser = u;
                }
            }

            return new EmailExistingResponse
            {
                user = foundUser,
                isExisting = emailExisting
            };
        }
    }
}