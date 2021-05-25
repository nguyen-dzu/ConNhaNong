using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ConNhaNong.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace ConNhaNong.Controllers
{
    public class ProductController : Controller
    {
        public Models.Model1 context = new Models.Model1();
        public IHostingEnvironment _hostingEnvironment;

        [HttpPost]
        public ActionResult AddCart(string ID_P)
        {
            var SL = Request.Form["sale_amount"];
            if (String.IsNullOrEmpty(SL))
            {
                SL = 1.ToString();
            }
            User Users = (User)Session["User"];
            if (Users!=null)
            {
                var users = context.Users.Where(s => s.Email.Equals(Users.Email)).FirstOrDefault();
                if (users != null)
                {
                    var cart = context.Carts.Where(s => s.ID.Equals(users.ID)).FirstOrDefault();
                    if (cart == null)
                    {
                        Cart cart_ = new Cart();
                        cart_.ID = users.ID;
                        cart_.list = ID_P.ToString();
                        cart_.amount = SL.ToString();
                        cart_.ID_cart = users.ID;
                        context.Carts.Add(cart_);
                        context.SaveChanges();
                    }
                    else
                    {
                        cart.list += "," + ID_P.ToString();
                        cart.amount += "," + SL.ToString();
                        context.SaveChanges();
                    }
                    var cart__ = context.Carts;
                    return View(cart__);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult Cart()
        {
            return View();
        }
    }
}
