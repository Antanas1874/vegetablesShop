using API.Data;
using API.Data.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Options
{
    public interface IIdentityService
    {
        Task<AuthentificationResult> RegisterAsync(string email, string password);
        Task<UserCreateResponse> CreateUser(string email, string password);
        Task<UserCreateResponse> LoginUser(string email, string password);
    }
}
