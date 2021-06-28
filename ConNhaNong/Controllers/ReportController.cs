using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConNhaNong.Models;

namespace ConNhaNong.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddReport(string ProductId)
        {
            Users Users = (Users)Session["User"];
            if (Users != null)
            {
                var Db = new Model1();
                var users = Db.Users.Where(s => s.Email.Equals(Users.Email)).FirstOrDefault();
                if (users != null)
                {
                    var product = Db.products.FirstOrDefault(s => s.ID == ProductId);
                    if (product != null)
                    {
                        var report = new Report();
                        report.Email_send = users.Email;
                        report.id_product = product.ID;
                        Tuple<products, Report> tuple = new Tuple<products, Report>(product,report);
                        return View(tuple);
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
            else
            {
                return RedirectToAction("Register", "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public ActionResult AddReport(FormCollection model)
        {
            var reportmodel = new Report();
            reportmodel.id_product = model.GetValue(model.GetKey(1)).AttemptedValue;
            reportmodel.Email_send = model.GetValue(model.GetKey(3)).AttemptedValue;
            reportmodel.Notes = model.GetValue(model.GetKey(4)).AttemptedValue;
            reportmodel.Status_report = Status.Status_Contact.E_Waitting.ToString();
            var Db = new Model1();
            var product = Db.products.FirstOrDefault(s => s.ID == reportmodel.id_product);
            reportmodel.products = product;
            Db.Report.Add(reportmodel);
            Db.SaveChanges();
            return RedirectToAction("ReportSuccess");
        }
        public ActionResult ReportSuccess()
        {
            return View();
        }

        public ActionResult GetAllReport()
        {
            Users Users = (Users)Session["Admin"];
            if (Users != null)
            {
                Model1 model1 = new Model1();
                var list = model1.Report.Where(s => s.Status_report != Status.Status_Contact.E_Delete.ToString()).ToList();
                foreach (var item in list)
                {
                    if (item.Status_report == Status.Status_Contact.E_Waitting.ToString())
                    {
                        item.Status_report = "Đang chờ xác nhận";
                    }
                    if (item.Status_report == Status.Status_Contact.E_Confirm.ToString())
                    {
                        item.Status_report = "Đã xác nhận";
                    }
                    if (item.Status_report == Status.Status_Contact.E_Confirm.ToString())
                    {
                        item.Status_report = "Đã xóa";
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
            var objects_ = model1.Report.Find(Id);
            if (objects_ != null)
            {
                objects_.Status_report = Status.Status_Contact.E_Confirm.ToString();
            }
            model1.Entry(objects_);
            model1.SaveChanges();
            return RedirectToAction("GetAllReport");
        }
        public ActionResult Delete(int Id)
        {
            Model1 model1 = new Model1();
            var objects_ = model1.Report.Find(Id);
            if (objects_ != null)
            {
                objects_.Status_report = Status.Status_Contact.E_Delete.ToString();
            }
            model1.Entry(objects_);
            model1.SaveChanges();
            return RedirectToAction("GetAllReport");
        }
    }
}