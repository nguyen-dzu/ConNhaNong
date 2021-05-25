using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ConNhaNong.Models;

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
            if(products != null)
            {
                return View(products);
            }
            return View("Error.cshtml");
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(product Products, HttpPostedFileBase file)
        {
            string fileName = System.IO.Path.GetFileName(file.FileName);

            //Set the Image File Path.
            string filePath = @"~\Images\" + fileName;

            //Save the Image File in Folder.
           // file.SaveAs(Server.MapPath(filePath));
            FileStream f = new FileStream(Server.MapPath(filePath), FileMode.Create);
            file.InputStream.CopyTo(f);
            f.Close();
            Services.ProductServices.AddProduct(Products.name_product, Products.amount, Products.price,fileName);
            return RedirectToAction("Index","Home");

        }
        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
