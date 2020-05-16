using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Entities;

namespace PizzaShop.Controllers
{
    public class HomeController : Controller
    {
        private Model1 context = new Model1();
        // GET: HomeControllers
        
        public ActionResult Index()
        {
            var model = context.tblMonAns.Where(x => x.MaMon !=null).ToList();

            return View(model);
        }

        
        public ActionResult DanhMuc(string id)
        {
            var model = context.tblMonAns.Where(x => x.LoaiMon==id).ToList();

            return View("Index" , model);
        }


        public ActionResult About()
        {
            return View();
        }

        public ActionResult Menu()
        {
            var model = context.tblMonAns.Where(x => x.MaMon != null).ToList();
            return View(model);
        }


        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}