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
    public class Bill_newController : Controller
    {
        private CT25Team18Entities1 db = new CT25Team18Entities1();

        // GET: Bill_new
        public ActionResult Index()
        {
            var bill_new = db.Bill_new.Include(b => b.User);
            return View(bill_new.ToList());
        }

        // GET: Bill_new/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_new bill_new = db.Bill_new.Find(id);
            if (bill_new == null)
            {
                return HttpNotFound();
            }
            return View(bill_new);
        }

        // GET: Bill_new/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Users, "ID", "Email");
            return View();
        }

        // POST: Bill_new/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_bill,ID,list,amount,total,addresz,SDt,name_bill")] Bill_new bill_new)
        {
            if (ModelState.IsValid)
            {
                db.Bill_new.Add(bill_new);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Users, "ID", "Email", bill_new.ID);
            return View(bill_new);
        }

        // GET: Bill_new/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_new bill_new = db.Bill_new.Find(id);
            if (bill_new == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Users, "ID", "Email", bill_new.ID);
            return View(bill_new);
        }

        // POST: Bill_new/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_bill,ID,list,amount,total,addresz,SDt,name_bill")] Bill_new bill_new)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bill_new).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Users, "ID", "Email", bill_new.ID);
            return View(bill_new);
        }

        // GET: Bill_new/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_new bill_new = db.Bill_new.Find(id);
            if (bill_new == null)
            {
                return HttpNotFound();
            }
            return View(bill_new);
        }

        // POST: Bill_new/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Bill_new bill_new = db.Bill_new.Find(id);
            db.Bill_new.Remove(bill_new);
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
