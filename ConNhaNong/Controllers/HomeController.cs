using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConNhaNong.Models;
using ConNhaNong.Services;

namespace ConNhaNong.Controllers
{
    public class HomeController : Controller
    {
        private CT25Team18Entities1 db = new CT25Team18Entities1();
        public HomeController()
        {

        }
        public ActionResult Index(string searchString)
        {
            var list = db.products;
            if (!String.IsNullOrEmpty(searchString))
            {
                list = (System.Data.Entity.DbSet<product>)list.Where(s => s.name_product.Contains(searchString));
            }
            return View(list) ;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users user)
        {

            if (ModelState.IsValid)
            { 
                if(user.Email.Equals("admin@vanlanguni.vn") && user.Passwords.Equals("connhanong"))
                {
                    Session.Add("Admin", user);
                    return RedirectToAction("Index");
                }
                var check = Services.LoginServices.Login(user.Email, user.Passwords);
                if (check)
                {
                    Session.Add("User", user);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Sai tai khoản/ mật khẩu";
                    return View(user);
                }
            }
            else
            {
                ViewBag.Error = "Sai tai khoản/ mật khẩu";
                return View(user);
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Users user)
        {
            if (ModelState.IsValid)
            {
                var check = Services.LoginServices.CheckRegister(user.Email, user.Passwords);
                if (check)
                {
                    LoginServices.Regiter(user.Email, user.Passwords);
                    Session.Add("User", user);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Email đã tồn tại";
                    return View(user);
                }
            }
            else
            {
                ViewBag.Error = "Email đã tồn tại";
                return View(user);
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}