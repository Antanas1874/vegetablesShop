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
    public class OrderController : Controller
    {
        private readonly OrderService orderService;
        private readonly UserService userService;
        public int fk;
        public int id;
        public OrderController()
        {
            orderService = new OrderService();
            userService = new UserService();
        }

        public IActionResult Create()
        {
            if (Resource.isGuest)
            {
                return View("../Home/NotLogged");
            }

            TempData["isAdmin"] = Resource.isAdmin.ToString().ToLower();
            TempData["isGuest"] = Resource.isGuest.ToString().ToLower();
            TempData["token"] = Resource.token;
            TempData["email"] = Resource.email;
            TempData["id"] = Resource.id;
            TempData["cartItems"] = Resource.cartItems;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            if (Resource.isGuest)
            {
                return View("../Home/NotLogged");
            }
            
            TempData["isAdmin"] = Resource.isAdmin.ToString().ToLower();
            TempData["isGuest"] = Resource.isGuest.ToString().ToLower();
            TempData["token"] = Resource.token;
            TempData["email"] = Resource.email;
            TempData["id"] = Resource.id;
            
            order.fk_User = Resource.id;
            await orderService.Create(order);
            Resource.cartItems = new List<int>();
            TempData["cartItems"] = Resource.cartItems;
            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> List()
        {
            if (Resource.isGuest)
            {
                return View("../Home/NotLogged");
            }

            TempData["isAdmin"] = Resource.isAdmin.ToString().ToLower();
            TempData["isGuest"] = Resource.isGuest.ToString().ToLower();
            TempData["token"] = Resource.token;
            TempData["email"] = Resource.email;
            TempData["id"] = Resource.id;
            TempData["cartItems"] = Resource.cartItems;
            return View(await orderService.GetAllUserProducts(Resource.id));
        }

        public async Task<ActionResult> ListAll()
        {
            if (!Resource.isAdmin)
            {
                return View("../Home/NotAdmin");
            }
            if (Resource.isGuest)
            {
                return View("../Home/NotLogged");
            }

            List<AllOrders> allOrders = new List<AllOrders>();
            User tempuser = new User();

            foreach (var item in await orderService.GetAllProducts())
            {
                tempuser = await userService.Get(item.fk_User);
                allOrders.Add(new AllOrders
                {
                    order = item,
                    email = tempuser.email
                });
            }

            Resource.lastPage = "ListAll";
            TempData["isAdmin"] = Resource.isAdmin.ToString().ToLower();
            TempData["isGuest"] = Resource.isGuest.ToString().ToLower();
            TempData["token"] = Resource.token;
            TempData["email"] = Resource.email;
            TempData["id"] = Resource.id;

            return View(allOrders);
        }

        public async Task<ActionResult> ListAdmin(int id)
        {
            if (!Resource.isAdmin)
            {
                return View("../Home/NotAdmin");
            }
            if (Resource.isGuest)
            {
                return View("../Home/NotLogged");
            }
            Resource.lastPage = "ListAdmin";
            TempData["isAdmin"] = Resource.isAdmin.ToString().ToLower();
            TempData["isGuest"] = Resource.isGuest.ToString().ToLower();
            TempData["token"] = Resource.token;
            TempData["email"] = Resource.email;
            TempData["id"] = Resource.id;
            TempData["cartItems"] = Resource.cartItems;
            var dict = new Dictionary<string, string>();
            dict.Add("id", id.ToString());
            TempData["adminOrderid"] = dict;
            return View("List", await orderService.GetAllUserProducts(id));
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

            await orderService.Delete(id);

            if (Resource.lastPage.Equals("ListAdmin"))
            {
                return RedirectToAction("ListAdmin", "Order", new { id = Resource.editingUserOrdersId });
            }
            else if (Resource.lastPage.Equals("ListAll"))
            {
                return RedirectToAction("ListAll", "Order");
            }
            return RedirectToAction("ListAdmin", "Order", new { id = Resource.editingUserOrdersId });
        }

        public async Task<ActionResult> Edit(int id)
        {
            TempData["isAdmin"] = Resource.isAdmin.ToString().ToLower().ToLower().ToLower();
            TempData["isGuest"] = Resource.isGuest.ToString().ToLower();
            TempData["token"] = Resource.token;
            TempData["email"] = Resource.email;
            TempData["id"] = Resource.id;

            OrderViewModel order = new OrderViewModel();
            order.order = await orderService.Get(id);
            Resource.editingOrderId = id;
            Resource.editingUserOrdersId = order.order.fk_User;
            order.products = Resource.parseProductsToString(order.order.products);
            if (!Resource.isAdmin)
            {
                return View("../Home/NotAdmin");
            }
            if (Resource.isGuest)
            {
                return View("../Home/NotLogged");
            }

            return View(order);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(OrderViewModel orderView)
        {
            TempData["isAdmin"] = Resource.isAdmin.ToString().ToLower().ToLower().ToLower();
            TempData["isGuest"] = Resource.isGuest.ToString().ToLower();
            TempData["token"] = Resource.token;
            TempData["email"] = Resource.email;
            TempData["id"] = Resource.id;
            orderView.order.id = Resource.editingOrderId;
            orderView.order.fk_User = Resource.editingUserOrdersId;
            orderView.order.products = Resource.parseProductsToList(orderView.products);

            if (!Resource.isAdmin)
            {
                return View("../Home/NotAdmin");
            }
            if (Resource.isGuest)
            {
                return View("../Home/NotLogged");
            }
            await orderService.Update(orderView.order);
            if (Resource.lastPage.Equals("ListAdmin"))
            {
                return RedirectToAction("ListAdmin", "Order", new { id = orderView.order.fk_User });
            } else if (Resource.lastPage.Equals("ListAll"))
            {
                return RedirectToAction("ListAll", "Order");
            }
            return RedirectToAction("ListAdmin", "Order", new { id = orderView.order.fk_User });
        }
    }
}