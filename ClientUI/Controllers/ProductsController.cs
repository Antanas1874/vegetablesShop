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
    public class ProductsController : Controller
    {
        private readonly ProductService productService;

        public ProductsController()
        {
            productService = new ProductService();
        }
        public async Task<ActionResult> List()
        {
            TempData["isAdmin"] = Resource.isAdmin.ToString().ToLower();
            TempData["isGuest"] = Resource.isGuest.ToString().ToLower();
            TempData["token"] = Resource.token;
            TempData["email"] = Resource.email;
            TempData["id"] = Resource.id;
            return View(await productService.GetAllProducts());
        }

        public ActionResult CartAdd(int id)
        {
            if (Resource.isGuest)
            {
                return RedirectToAction("Login", "Identity");
            } else
            {
                Resource.cartItems.Add(id);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> Cart()
        {
            TempData["isAdmin"] = Resource.isAdmin.ToString().ToLower();
            TempData["isGuest"] = Resource.isGuest.ToString().ToLower();
            TempData["token"] = Resource.token;
            TempData["email"] = Resource.email;
            TempData["id"] = Resource.id;

            if (!Resource.loggedIn)
            {
                return View("../Home/NotLogged");
            }

            List<Product> products = new List<Product>();
            foreach (var item in Resource.cartItems)
            {
                products.Add(await productService.Get(item));
            }

            TempData["cartItemCount"] = products.Count;
            if (products.Count > 0)
                return View(products);
            return View();
        }

        public ActionResult DeleteFromCart(int id)
        {
            TempData["isAdmin"] = Resource.isAdmin.ToString().ToLower().ToLower().ToLower();
            TempData["isGuest"] = Resource.isGuest.ToString().ToLower();
            TempData["token"] = Resource.token;
            TempData["email"] = Resource.email;
            TempData["id"] = Resource.id;

            if (Resource.isGuest)
            {
                return View("../Home/NotLogged");
            }
            Resource.cartItems.Remove(id);
            return RedirectToAction("Cart", "Products");
        }

        public ActionResult Create()
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
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product product)
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

            await productService.Create(product);
            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> Edit(int id)
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
            return View(await productService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Product product)
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

            await productService.Update(product);

            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> Delete(int id)
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

            await productService.Delete(id);

            return RedirectToAction("Index", "Home");
        }
    }
}