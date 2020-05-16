using Model.Dao;
using Model.Entities;
using PizzaShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pagesize = 8)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pagesize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tblNguoiDung user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var encryptedMd5Pas = Encryptor.MD5Hash(user.MatKhau);
                user.MatKhau = encryptedMd5Pas;
                long id = dao.Insert(user);
                if (id > 0)
                {
                    ModelState.AddModelError("", "thêm user thành công");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "thêm user thất bại");
                }
            }
            return View("Index");

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var user = new UserDao().ViewDetail(id);

            return View(user);
        }

        [HttpPost]
        public ActionResult Update(tblNguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!string.IsNullOrEmpty(nguoiDung.MatKhau))
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(nguoiDung.MatKhau);
                    nguoiDung.MatKhau = encryptedMd5Pas;
                }

                var result = dao.Update(nguoiDung);
                if (result)
                {
                    ModelState.AddModelError("", "cập nhật user thành công");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "cập nhật user thật bại");
                }
            }
            return View("Index");
        }


        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }

    }
}