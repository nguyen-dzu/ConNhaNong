using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConNhaNong.Services;

namespace ConNhaNong.Controllers
{
    public class HomeController : Controller
    {
        public Models.Model1 context = new Models.Model1();
        public HomeController()
        {

        }
        public ActionResult Index()
        {
            var list = context.products.ToList();
            return View(list);
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
        public ActionResult Login(Models.User user)
        {

            if (ModelState.IsValid)
            { 
                if(user.Email.Equals("admin@vanlanguni.com") && user.Passwords.Equals("connhanong"))
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
        public ActionResult Register(Models.User user)
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