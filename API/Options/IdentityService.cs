using API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using API.Data.Responses;
using API.Controllers;
using API.Models;

namespace API.Options
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly UsersController usersController;
        private readonly JwtOptions jwtOptions;
        public IdentityService(UserManager<IdentityUser> userManager, JwtOptions jwtOptions)
        {
            this.userManager = userManager;
            this.jwtOptions = jwtOptions;
            this.usersController = new UsersController();
        }

        public async Task<UserCreateResponse> CreateUser(string email, string password)
        {
            if (usersController.IsExistingEmail(email).isExisting)
            {
                return new UserCreateResponse
                {
                    errors = new[] { "User with this email already exists" }
                };
            }

            var newUser = new Models.User
            {
                id = 0,
                email = email,
                password = password,
                role = "1"
            };

            usersController.Create(newUser);

            return GenerateAtuhentificationResult(newUser);
        }

        public async Task<UserCreateResponse> LoginUser(string email, string password)
        {
            var emailResponse = usersController.IsExistingEmail(email);

            if (!emailResponse.isExisting)
            {
                return new UserCreateResponse
                {
                    errors = new[] { "User with this email does not exist" }
                };
            }

            bool isValidPassword = UserValidPassword(emailResponse.user, password);

            if (!isValidPassword)
            {
                return new UserCreateResponse
                {
                    errors = new[] { "Wrong username or password" }
                };
            }

            return GenerateAtuhentificationResult(emailResponse.user);
        }

        private UserCreateResponse GenerateAtuhentificationResult(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtOptions.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.email)
                    // Pakeista : cia pas ji buvo ID
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserCreateResponse
            {
                success = true,
                token = tokenHandler.WriteToken(token)
            };
        }

        private bool UserValidPassword(User user, string password)
        {
            return user.password.Equals(password);
        }

        public async Task<AuthentificationResult> RegisterAsync(string email, string password)
        {
            var existingUser = userManager.FindByEmailAsync(email);
            
            if (existingUser != null)
            {
                return new AuthentificationResult
                {
                    errors = new[] { "User with this email already exists" }
                };
            }

            var newUser = new IdentityUser
            {
                Email = email,
                UserName = email
            };

            var createdUser = await userManager.CreateAsync(newUser, password);
        
            if (!createdUser.Succeeded)
            {
                return new AuthentificationResult
                {
                    errors = createdUser.Errors.Select(x => x.Description)
                };
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtOptions.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, newUser.Email),
                    new Claim("id", newUser.Id)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthentificationResult
            {
                success = true,
                token = tokenHandler.WriteToken(token)
            };
        }
    }
}
