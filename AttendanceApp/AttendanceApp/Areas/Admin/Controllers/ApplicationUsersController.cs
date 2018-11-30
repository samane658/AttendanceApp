using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AttendanceApp.Models;
using AttendanceApp.ViewModel;
using System.IO;


namespace AttendanceApp.Areas.Admin.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            var applicationUsers = db.Users.Include(a => a.position);
            return View(applicationUsers.ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        public ActionResult Create()
        {
            ViewBag.positionId = new SelectList(db.Positions, "Id", "positionName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicationUsersViewModel viewModel)
        {
            ApplicationUsersViewModel vm = new ApplicationUsersViewModel();
            vm = viewModel;

            if (viewModel.UploadedpicFile != null)
            {
                var extension = Path.GetExtension(path: viewModel.UploadedpicFile.FileName).ToLower();

                if (extension != ".jpg" && extension != ".png" && extension != ".gif" && extension != ".jpeg")
                {
                    ModelState.AddModelError("UploadedpicFile", "فایل ارسالی شما باید یک عکس باشد");
                }
            }

            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser();
                //intializing appuser variable
                applicationUser.PasswordHash = GetHashCode(viewModel.password);
                applicationUser.name = viewModel.name;
                applicationUser.birthDate = viewModel.birthDate;
                applicationUser.lastName = viewModel.lastName;
                applicationUser.Email = viewModel.Email;
                applicationUser.positionName = viewModel.positionName;
                applicationUser.address = viewModel.address;
                applicationUser.cellPhone = viewModel.cellPhone;
                applicationUser.gender = viewModel.gender;
                applicationUser.ManagerId = viewModel.ManagerId;
                //adding pic
                var extension = Path.GetExtension(viewModel.UploadedpicFile.FileName).ToLower();


                var fileName = $"{Guid.NewGuid()}{extension}";

                var path = Path.Combine(Server.MapPath("~/Images/"), fileName);

                viewModel.UploadedpicFile.SaveAs(path);
                applicationUser.picPath = fileName;

                db.Users.Add(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        private string GetHashCode(string password)
        {
         return GetHashCode(password);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.positionId = new SelectList(db.Positions, "Id", "positionName", applicationUser.positionId);
            return View(applicationUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,lastName,positionName,address,cellPhone,birthDate,gender,picPath,ManagerId,positionId,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.positionId = new SelectList(db.Positions, "Id", "positionName", applicationUser.positionId);
            return View(applicationUser);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
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
