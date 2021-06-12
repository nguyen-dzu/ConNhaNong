using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConNhaNong.Models;

namespace ConNhaNong.Controllers
{
    [Authorize]
    public class DiscountsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Discounts
        public ActionResult Index()
        {
            return View(db.Discounts.ToList());
        }

        // GET: Discounts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discount discount = db.Discounts.Find(id);
            if (discount == null)
            {
                return HttpNotFound();
            }
            return View(discount);
        }

        // GET: Discounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Discounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date_active,Date_end,Name_discount,Description_discount")] Discount discount)
        {
            if (ModelState.IsValid)
            {
                db.Discounts.Add(discount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(discount);
        }

        // GET: Discounts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discount discount = db.Discounts.Find(id);
            if (discount == null)
            {
                return HttpNotFound();
            }
            return View(discount);
        }

        // POST: Discounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date_active,Date_end,Name_discount,Description_discount")] Discount discount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(discount);
        }

        // GET: Discounts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discount discount = db.Discounts.Find(id);
            if (discount == null)
            {
                return HttpNotFound();
            }
            return View(discount);
        }

        // POST: Discounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Discount discount = db.Discounts.Find(id);
            db.Discounts.Remove(discount);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
