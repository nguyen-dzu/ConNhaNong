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
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

     
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}