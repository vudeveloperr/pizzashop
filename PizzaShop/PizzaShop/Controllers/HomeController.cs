using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.Entities;
using PizzaShop.Common;
using PizzaShop.Models;

namespace PizzaShop.Controllers
{
    public class HomeController : Controller
    {
        private Model1 context = new Model1();
        // GET: HomeControllers
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public ActionResult Index()
        {
            var model = context.tblMonAns.Where(x => x.LoaiMon == "Pizza").ToList();

            ViewBag.LoaiMon = context.tblMonAns.Select(x => x.LoaiMon).Distinct().ToList();

            return View(model);
        }
        [HttpGet]
        public ActionResult XemMonTrongDSMon(int maLoaiMon)
        {
            var modal = context.tblMonAns.Where(x => x.LoaiMon == "Pizza").ToList();

            if (maLoaiMon == 2)
            {
                modal = context.tblMonAns.Where(x => x.LoaiMon == "Pasta").ToList();
            }
            else if (maLoaiMon == 3)
            {
                modal = context.tblMonAns.Where(x => x.LoaiMon == "Salad").ToList();
            }
            else if (maLoaiMon == 4)
            {
                modal = context.tblMonAns.Where(x => x.LoaiMon == "Nuoc").ToList();
            }

            return PartialView(modal);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public ActionResult DanhMuc(string id)
        {
            var model = context.tblMonAns.Where(x => x.LoaiMon == id).ToList();

            return View("Index", model);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public ActionResult About()
        {
            return View();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public ActionResult Menu()
        {
            var model = context.tblMonAns.Where(x => x.MaMon != null).ToList();
            ViewBag.Mon = context.tblMonAns.Where(x => x.MaMon == 1).ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult XemChiTietMon(int id)
        {
            var modal = context.tblMonAns.Where(x => x.MaMon == id).First();
            //from a in context.tblMonAns
            //where a.MaMon == id
            //select new tblMonAn()
            //{
            //    MaMon = a.MaMon,
            //    Gia = a.Gia,
            //    GiaVua = a.GiaVua,
            //    GiaKhuyenMai = a.GiaKhuyenMai,
            //    GiaLon = a.GiaLon,
            //    AnhMon = a.AnhMon,
            //    TenMon = a.TenMon
            //};
            return PartialView(modal);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Send(string name, string email, string address, string contentFeedback)
        {
            var feedback = new tblPhanHoi();

            feedback.TenNguoiDung = name;
            feedback.email = email;
            feedback.DiaChi = address;
            feedback.NgayTao = DateTime.Now;
            feedback.NoiDung = contentFeedback;

            var maND = new ContactDao().InsertFeedBack(feedback);

            if (maND > 0)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [ChildActionOnly]
        public PartialViewResult CartIconPV()
        {
            var cart = Session[CommonConstants.CART_SESSION];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }
    }
}