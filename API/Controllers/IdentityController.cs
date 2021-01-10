using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Options;
using API.Data.Requests;
using API.Data.Responses;

namespace API.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService identityService;
        public IdentityController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [HttpPost("api/v1/Identity/CreateUser")]
        public async Task<IActionResult> CreateUser(UserRegistrationRequest request)
        {
            var authResponse = await identityService.CreateUser(request.email, request.password);

            if (!authResponse.success)
            {
                return BadRequest(new AuthFailResponse
                {
                    errors = authResponse.errors
                });
            }


            return Ok(new AuthSuccessResponse
            {
                token = authResponse.token
            });
        }

        [HttpPost("api/v1/Identity/LoginUser")]
        public async Task<IActionResult> LoginUser(UserLoginRequest request)
        {
            var authResponse = await identityService.LoginUser(request.email, request.password);

            if (!authResponse.success)
            {
                return BadRequest(new AuthFailResponse
                {
                    errors = authResponse.errors
                });
            }


            return Ok(new AuthSuccessResponse
            {
                token = authResponse.token
            });
        }
    }
}