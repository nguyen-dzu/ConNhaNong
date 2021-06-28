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
                Model1 model1 = new Model1();
                contact.Status_contact = Status.Status_Contact.E_Waitting.ToString();
                model1.Contact.Add(contact);
                model1.SaveChanges();
                return RedirectToAction("ContactSuccess");
            }
        }
        public ActionResult GetAllContact()
        {
            Users Users = (Users)Session["Admin"];
            if (Users != null)
            {
                Model1 model1 = new Model1();
                var list = model1.Contact.Where(s=>s.Status_contact!= Status.Status_Contact.E_Delete.ToString()).ToList();
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
            Model1 model1 = new Model1();
            var objects_ = model1.Contact.Find(Id);
            if(objects_ != null)
            {
                objects_.Status_contact = Status.Status_Contact.E_Confirm.ToString();
            }
            model1.Entry(objects_);
            model1.SaveChanges();
            return RedirectToAction("GetAllContact");
        }
        public ActionResult Delete(int Id)
        {
            Model1 model1 = new Model1();
            var objects_ = model1.Contact.Find(Id);
            if (objects_ != null)
            {
                objects_.Status_contact = Status.Status_Contact.E_Delete.ToString();
            }
            model1.Entry(objects_);
            model1.SaveChanges();
            return RedirectToAction("GetAllContact");
        }
        public ActionResult ContactSuccess()
        {
            return View();
        }
    }
}