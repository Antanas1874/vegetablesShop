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
    public class UserController : Controller
    {
        UserService userService;
        public UserController()
        {
            userService = new UserService();
        }


        public async Task<IActionResult> List()
        {

            TempData["isAdmin"] = Resource.isAdmin.ToString().ToLower().ToLower().ToLower();
            TempData["isGuest"] = Resource.isGuest.ToString().ToLower();
            TempData["token"] = Resource.token;
            TempData["email"] = Resource.email;
            TempData["id"] = Resource.id;

            if (!Resource.isAdmin)
            {
                return View("../Home/NotAdmin");
            }
            if (Resource.isGuest)
            {
                return View("../Home/NotLogged");
            }
            List<User> users = await userService.GetAllUsers();
            return View(users.Where(x => x.id != Resource.id));
        }

        public async Task<IActionResult> Edit(int id)
        {
            TempData["isAdmin"] = Resource.isAdmin.ToString().ToLower().ToLower().ToLower();
            TempData["isGuest"] = Resource.isGuest.ToString().ToLower();
            TempData["token"] = Resource.token;
            TempData["email"] = Resource.email;
            TempData["id"] = Resource.id;

            if (!Resource.isAdmin)
            {
                return View("../Home/NotAdmin");
            }
            if (Resource.isGuest)
            {
                return View("../Home/NotLogged");
            }
            return View(await userService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            TempData["isAdmin"] = Resource.isAdmin.ToString().ToLower().ToLower().ToLower();
            TempData["isGuest"] = Resource.isGuest.ToString().ToLower();
            TempData["token"] = Resource.token;
            TempData["email"] = Resource.email;
            TempData["id"] = Resource.id;

            if (!Resource.isAdmin)
            {
                return View("../Home/NotAdmin");
            }
            if (Resource.isGuest)
            {
                return View("../Home/NotLogged");
            }
            user.password = Resource.ComputeSha256Hash(user.password);
            await userService.Update(user);
            return RedirectToAction("List", "User");
        }

        public async Task<IActionResult> Delete(int id)
        {
            TempData["isAdmin"] = Resource.isAdmin.ToString().ToLower().ToLower().ToLower();
            TempData["isGuest"] = Resource.isGuest.ToString().ToLower();
            TempData["token"] = Resource.token;
            TempData["email"] = Resource.email;
            TempData["id"] = Resource.id;

            if (!Resource.isAdmin)
            {
                return View("../Home/NotAdmin");
            }
            if (Resource.isGuest)
            {
                return View("../Home/NotLogged");
            }
            await userService.Delete(id);
            return RedirectToAction("List", "User");
        }
    }
}