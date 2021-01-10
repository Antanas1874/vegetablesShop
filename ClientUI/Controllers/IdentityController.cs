using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClientUI.Resources;
using ClientUI.Services;
using ClientUI.Models;

namespace ClientUI.Controllers
{
    public class IdentityController : Controller
    {
        public readonly IdentitySevice identityService;
        public readonly UserService userService;

        public IdentityController()
        {
            this.identityService = new IdentitySevice();
            this.userService = new UserService();
        }


        public ActionResult Login()
        {
            TempData["isAdmin"] = Resource.isAdmin.ToString().ToLower();
            TempData["isGuest"] = Resource.isGuest.ToString().ToLower();
            TempData["token"] = Resource.token;
            TempData["email"] = Resource.email;
            TempData["id"] = Resource.id.ToString();

            Resource.token = "";
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string email, string password)
        {
            password = Resource.ComputeSha256Hash(password);
            Resource.token = await identityService.Login(email, password);
            if (Resource.token.Length > 0)
            {
                User user = await userService.GetByEmail(email);

                TempData["isAdmin"] = "false";
                if (user.role.Contains("2"))
                {
                    TempData["isAdmin"] = "true";
                    Resource.isAdmin = true;
                }

                Resource.isGuest = false;
                Resource.email = email;
                Resource.id = user.id;
                Resource.loggedIn = true;

                TempData["isGuest"] = "false";
                TempData["token"] = Resource.token;
                TempData["email"] = email;
                TempData["id"] = user.id.ToString();

                return RedirectToAction("Index", "Home");
            }
            TempData["isGuest"] = "true";
            TempData["isAdmin"] = "false";
            ModelState.AddModelError("email", "User does not exist");
            return View();
        }

        public ActionResult Register()
        {
            TempData["isAdmin"] = Resource.isAdmin.ToString().ToLower().ToLower().ToLower();
            TempData["isGuest"] = Resource.isGuest.ToString().ToLower();
            TempData["token"] = Resource.token;
            TempData["email"] = Resource.email;
            TempData["id"] = Resource.id;

            Resource.token = "";
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(string email, string password)
        {
            password = Resource.ComputeSha256Hash(password);
            Resource.token = await identityService.Register(email, password);
            if (Resource.token.Length > 0)
            {
                return RedirectToAction("Login");
            }
            TempData["isGuest"] = "true";
            ModelState.AddModelError("email", "User with this email address already exits");
            return View();
        }

        public ActionResult Logout()
        {
            Resource.token = "";
            Resource.isAdmin = false;
            Resource.isGuest = true;
            Resource.email = "";
            Resource.id = 0;
            return RedirectToAction("Index", "Home");
        }

     
    }
}