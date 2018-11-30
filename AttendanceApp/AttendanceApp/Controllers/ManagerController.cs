using AttendanceApp.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttendanceApp.Controllers
{
    public class ManagerController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Commit(int? id)
        {
            inout a = db.Inouts.Find(id);
            a.isCommited = true;
            db.SaveChanges();
            return View();
        }
        [HttpPost]

        public ActionResult Isrest(int? id)
        {
            inout a = db.Inouts.Find(id);
                a.isRest = true;
            db.SaveChanges();

            return View();
        }
        public ActionResult RestIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Acceptrest(int? id)
        {
            rest a = db.Rests.Find(id);
            a.isCommited = true;
            db.SaveChanges();

            return View();
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