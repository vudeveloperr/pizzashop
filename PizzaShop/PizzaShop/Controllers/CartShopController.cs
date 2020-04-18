using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaShop.Controllers
{
    public class CartShopController : Controller
    {
        // GET: CartShop
        public ActionResult Index()
        {
            return View();
        }
    }
}