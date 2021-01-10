using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClientUI.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using ClientUI.Resources;
using ClientUI.Services;

namespace ClientUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            UserService userService = new UserService();
            ProductService productService = new ProductService();
            User user = new User
            {
                id = 10,
                email = "Labas@gmai.com",
                password = "labas",
                role = "0"
            };

            Product product = new Product
            {
                id = 5,
                name = "Cesnakas",
                description = "Wuhaniskas !",
                price = 0.68
            };

            /*            await userService.Create(user);
                        List<User> users = await userService.GetAllUsers();
                        user = await userService.Get(4);
                        user.email = "muzika@muzika.com";
                        await userService.Update(user);
                        await userService.Delete(7);*/

            //List<Product> products = await productService.GetAllProducts();
            /*  await productService.Create(product);
              product = await productService.Get(1);
              product.id = 3;
              product.name = "Zirneliai";
              product.description = "Kilmes salis: Cekija";
              product.price = 1.15;
              await productService.Update(product);
              await productService.Delete(4);*/
            TempData["isAdmin"] = Resource.isAdmin.ToString().ToLower();
            TempData["isGuest"] = Resource.isGuest.ToString().ToLower();
            TempData["token"] = Resource.token;
            TempData["email"] = Resource.email;
            TempData["id"] = Resource.id;
            return RedirectToAction("List", "Products");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
