using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConNhaNong.Models;

namespace ConNhaNong.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact        
        private CT25Team18Entities1 db = new CT25Team18Entities1();

        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }
            else
            {
                contact.Status_contact = Status.Status_Contact.E_Waitting.ToString();
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("ContactSuccess");
            }
        }
        public ActionResult GetAllContact()
        {
            Users Users = (Users)Session["Admin"];
            if (Users != null)
            {
                var list = db.Contacts.Where(s=>s.Status_contact!= Status.Status_Contact.E_Delete.ToString()).ToList();
                foreach (var item in list)
                {
                    if (item.Status_contact == Status.Status_Contact.E_Waitting.ToString())
                    {
                        item.Status_contact = "Đang chờ xác nhận";
                    }
                    if (item.Status_contact == Status.Status_Contact.E_Confirm.ToString())
                    {
                        item.Status_contact = "Đã xác nhận";
                    }
                    if (item.Status_contact == Status.Status_Contact.E_Confirm.ToString())
                    {
                        item.Status_contact = "Đã xóa";
                    }
                }
                return View(list);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Confirm(int Id)
        {
            var objects_ = db.Contacts.Find(Id);
            if(objects_ != null)
            {
                objects_.Status_contact = Status.Status_Contact.E_Confirm.ToString();
            }
            db.Entry(objects_);
            db.SaveChanges();
            return RedirectToAction("GetAllContact");
        }
        public ActionResult Delete(int Id)
        {
            var objects_ = db.Contacts.Find(Id);
            if (objects_ != null)
            {
                objects_.Status_contact = Status.Status_Contact.E_Delete.ToString();
            }
            db.Entry(objects_);
            db.SaveChanges();
            return RedirectToAction("GetAllContact");
        }
        public ActionResult ContactSuccess()
        {
            return View();
        }
    }
}