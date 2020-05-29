using Model.Dao;
using PizzaShop.Common;
using PizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PizzaShop.Controllers
{
    public class CartShopController : Controller
    {
        // GET: CartShop
        public ActionResult Index()
        {
            var cart = Session[CommonConstants.CART_SESSION];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public ActionResult addToCart(int maMon, int soLuong)
        {
            var MonAn = new MonAnDao().ViewDetail(maMon);
            var cart = Session[CommonConstants.CART_SESSION];
            if (cart != null)
            {
                //TH co sp roi
                var list = (List<CartItem>)cart;//ep kieu 

                if (list.Exists(x => x.MonAn.MaMon == maMon))
                {
                    foreach (var item in list)
                    {
                        if (item.MonAn.MaMon == maMon)
                        {
                            item.SoLuong += soLuong;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.MonAn = MonAn;
                    item.SoLuong = soLuong;

                    list.Add(item);
                }

                Session[CommonConstants.CART_SESSION] = list;
            }
            else
            {
                //taoj moi 1 doi tuong cart item
                var item = new CartItem();
                item.MonAn = MonAn;
                item.SoLuong = soLuong;
                var list = new List<CartItem>();

                list.Add(item);
                //gan vao session
                Session[CommonConstants.CART_SESSION] = list;
            }

            return RedirectToAction("Index");
        }

        //tra ve cartModel ben goi ajax
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CommonConstants.CART_SESSION];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.MonAn.MaMon == item.MonAn.MaMon);
                if (jsonItem != null)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }
            }

            Session[CommonConstants.CART_SESSION] = sessionCart;

            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CommonConstants.CART_SESSION];

            sessionCart.RemoveAll(x => x.MonAn.MaMon == id);

            Session[CommonConstants.CART_SESSION] = sessionCart;

            return Json(new
            {
                status = true
            });
        }

    }
}