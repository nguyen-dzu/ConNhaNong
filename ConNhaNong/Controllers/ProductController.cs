using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ConNhaNong.Models;
using ConNhaNong.ViewModels;

namespace ConNhaNong.Controllers
{
    public class ProductController : Controller
    {
        public Models.Model1 context = new Models.Model1();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: Product/Details/5
        public ActionResult Details(string id)
        {
            var products = context.products.Where(s => s.ID.Equals(id)).FirstOrDefault();
            Users Users = (Users)Session["Admin"];
            if (Users != null)
            {
                return RedirectToAction("Admin_Details", new { id = id });
            }
            else
            {
                if (products != null)
                {
                    return View(products);
                }
                else
                {
                    return View("Error.cshtml");
                }
            }
        }
        public ActionResult Admin_Details(string id)
        {
            var products = context.products.Where(s => s.ID.Equals(id)).FirstOrDefault();
            Users Users = (Users)Session["Admin"];
            if (Users != null)
            {
                if (products != null)
                {
                    return View(products);
                }
                else
                {
                    return View("Error.cshtml");
                }
            }
            else
            {
                return View("Error.cshtml");
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(products Products, HttpPostedFileBase file)
        {
            string fileName = System.IO.Path.GetFileName(file.FileName);

            //Set the Image File Path.
            string filePath = @"~\Images\" + fileName;

            //Save the Image File in Folder.
            // file.SaveAs(Server.MapPath(filePath));
            FileStream f = new FileStream(Server.MapPath(filePath), FileMode.Create);
            file.InputStream.CopyTo(f);
            f.Close();
            Services.ProductServices.AddProduct(Products.name_product, Products.amount, Products.price, fileName, Products.Descriptions);
            return RedirectToAction("Index", "Home");

        }
        // GET: Product/Edit/5
        public ActionResult Edit(string id)
        {
            var products = context.products.Where(s => s.ID.Equals(id)).FirstOrDefault();
            if (products != null)
            {
                return View(products);
            }
            return View("Error.cshtml");
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(products products)
        {
            var p = context.products.Where(s => s.ID.Equals(products.ID)).FirstOrDefault();
            context.products.Remove(p);
            context.products.Add(products);
            context.SaveChanges();
            return RedirectToAction("Details", "product", new { id = products.ID });
        }

        // GET: Product/Delete/5
        public ActionResult Delete(string id)
        {
            var products = context.products.Where(s => s.ID.Equals(id)).FirstOrDefault();
            if (id == null)
            {
                return View("Error.cshtml");
            }
            else
            {
                context.products.Remove(products);
                context.SaveChanges();
            }
            return RedirectToAction("Manager_product", "Product");
        }
        public ActionResult Manager_product()
        {
            var list = context.products.ToList();
            return View(list);
        }
        //Thêm vào xác nhận thanh toán
        public ActionResult Deliver()
        {
            Users Users = (Users)Session["User"];
            if (Users == null)
            {
                return RedirectToAction("Login","Home");
            }
            else
            {
                var ListProduct = Services.ProductServices.GetProductViewModel(Users);
                Bill_new bill = new Bill_new();
                bill.name_bill = Users.Email;
                double? tong = 0;
                foreach(var item in ListProduct)
                {
                    tong += item.Total;
                }
                bill.total = tong;
                var tuple = new Tuple<Bill_new, List<ProductViewModel>>(bill, ListProduct);
                return View(tuple);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deliver(FormCollection bill)
        {
            Users Users = (Users)Session["User"];
            var isNumeric = long.TryParse(bill.GetValue(bill.GetKey(3)).AttemptedValue, out long n);
            if (isNumeric && bill.GetValue(bill.GetKey(3)).AttemptedValue.Length==10)
            {
                if (Users == null)
                {
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    var ListProduct = Services.ProductServices.GetProductViewModel(Users);
                    Bill_new bill_new = new Bill_new();
                    bill_new.name_bill = bill.GetValue(bill.GetKey(1)).AttemptedValue;
                    bill_new.SDt = bill.GetValue(bill.GetKey(3)).AttemptedValue;
                    bill_new.addresz = bill.GetValue(bill.GetKey(2)).AttemptedValue;
                    bill_new.ID = Users.ID;
                    var pd = context.Cart.Where(sx => sx.Users.Email.Equals(Users.Email)).FirstOrDefault();
                    bill_new.amount = pd.amount;
                    bill_new.list = pd.list;
                    var s = Services.IDServices.RandomIDBill();
                    var bills = context.Bill_new.Where(x => x.ID_bill.Equals(s)).FirstOrDefault();
                    while (bills != null)
                    {
                        s = Services.IDServices.RandomIDBill();
                        bills = context.Bill_new.Where(x => x.ID_bill.Equals(s)).FirstOrDefault();
                    }
                    bill_new.ID_bill = s;
                    double? tong = 0;
                    foreach (var item in ListProduct)
                    {
                        tong += item.Total;
                    }
                    bill_new.total = tong;
                    context.Bill_new.Add(bill_new);
                    var Cart = context.Cart.Where(x=> x.Users.Email == Users.Email).FirstOrDefault();
                    if(Cart != null)
                    {
                        context.Cart.Remove(Cart);
                    }
                    context.SaveChanges();
                    return RedirectToAction("DeliverSucess");
                }
            }
            else
            {
                ViewBag.PhoneNumber = "Số điện thoại không hợp lệ";
                var ListProduct = Services.ProductServices.GetProductViewModel(Users);
                Bill_new billl = new Bill_new();
                billl.name_bill = Users.Email;
                double? tong = 0;
                foreach (var item in ListProduct)
                {
                    tong += item.Total;
                }
                billl.total = tong;
                var tuple = new Tuple<Bill_new, List<ProductViewModel>>(billl, ListProduct);
                return View(tuple);
            }
        }
        [HttpPost]
        public ActionResult AddCart(string ID_P)
        {
            var SL = Request.Form["sale_amount"];
            if (String.IsNullOrEmpty(SL))
            {
                SL = 1.ToString();
            }
            Users Users = (Users)Session["User"];
            if (Users != null)
            {
                var users = context.Users.Where(s => s.Email.Equals(Users.Email)).FirstOrDefault();
                if (users != null)
                {
                    var cart = context.Cart.Where(s => s.ID.Equals(users.ID)).FirstOrDefault();
                    if (cart == null)
                    {
                        Cart cart_ = new Cart();
                        cart_.ID = users.ID;
                        cart_.list = ID_P.ToString();
                        cart_.amount = SL.ToString();
                        cart_.ID_cart = users.ID;
                        context.Cart.Add(cart_);
                        context.SaveChanges();
                    }
                    else
                    {
                        cart.list += "," + ID_P.ToString();
                        cart.amount += "," + SL.ToString();
                        context.SaveChanges();
                    }
                    return RedirectToAction("Cart");
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
            Users Users = (Users)Session["User"];
            if (Users != null)
            {
                var ListProduct = Services.ProductServices.GetProductViewModel(Users);
                return View(ListProduct);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult DeleteProctInCart(string Id)
        {
            Users Users = (Users)Session["User"];
            if (Users != null)
            {
                var ListCart = context.Cart.Where(s => s.Users.Email.Contains(Users.Email)).Select(s => s.list).FirstOrDefault();
                if (!String.IsNullOrEmpty(ListCart))
                {
                    var ListAmount = context.Cart.Where(s => s.Users.Email.Contains(Users.Email)).Select(s => s.amount).FirstOrDefault();
                    var Amout = ListAmount.Split(',');
                    var ListProduct = ListCart.Split(',');
                    for (int i = 0; i < ListProduct.Length; i++)
                    {
                        if (ListProduct[i].Contains(Id))
                        {
                            Amout[i] = null;
                            ListProduct[i] = null;
                        }
                    }
                    ListCart = null;
                    foreach (var item in ListProduct)
                    {
                        if (item != null)
                        {
                            ListCart += item + ",";
                        }
                    }
                    ListAmount = null;
                    foreach (var item in Amout)
                    {
                        if (item != null)
                        {
                            ListAmount += item + ",";
                        }
                    }
                    var Cart = context.Cart.Where(s => s.Users.Email.Contains(Users.Email)).FirstOrDefault();
                    Cart.list = ListCart.Substring(0, ListCart.Length - 1);
                    Cart.amount = ListAmount.Substring(0, ListAmount.Length - 1); ;
                    context.SaveChanges();
                    return RedirectToAction("Cart");
                }
                else
                {
                    return RedirectToAction("Cart");
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpPost]
        public ActionResult Modify(FormCollection form)
        {
            Users Users = (Users)Session["User"];
            if (Users != null)
            {
                var ListCart = context.Cart.Where(s => s.Users.Email.Contains(Users.Email)).Select(s => s.list).FirstOrDefault();
                if (!String.IsNullOrEmpty(ListCart))
                {
                    var a = form.GetValue("item.Amount");
                    var b = form.GetValue(form.GetKey(0));
                    var ListAmount = context.Cart.Where(s => s.Users.Email.Contains(Users.Email)).Select(s => s.amount).FirstOrDefault();
                    var Amout = ListAmount.Split(',');
                    var ListProduct = ListCart.Split(',');
                    int SL = int.Parse(a.AttemptedValue.ToString());
                    if (SL <= 0)
                    {
                        ViewBag.Error = "Số lượng phải lớn hơn 1";
                        var ListP = Services.ProductServices.GetProductViewModel(Users);
                        return View("Cart", ListP);
                    }
                    else
                    {
                        for (int i = 0; i < ListProduct.Length; i++)
                        {
                            if (ListProduct[i].Contains(b.AttemptedValue.ToString()))
                            {
                                Amout[i] = a.AttemptedValue.ToString();
                            }
                        }
                        ListCart = null;
                        foreach (var item in ListProduct)
                        {
                            if (item != null)
                            {
                                ListCart += item + ",";
                            }
                        }
                        ListCart = ListCart.Substring(0, ListCart.Length - 1);
                        ListAmount = null;
                        foreach (var item in Amout)
                        {
                            if (item != null)
                            {
                                ListAmount += item + ",";
                            }
                        }
                        ListAmount = ListAmount.Substring(0, ListAmount.Length - 1);
                        var Cart = context.Cart.Where(s => s.Users.Email.Contains(Users.Email)).FirstOrDefault();
                        Cart.list = ListCart;
                        Cart.amount = ListAmount;
                        context.SaveChanges();
                        return RedirectToAction("Cart");
                    }
                }
                else
                {
                    return RedirectToAction("Cart");
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult DeliverSucess()
        {
            return View();
        }
    }
}
