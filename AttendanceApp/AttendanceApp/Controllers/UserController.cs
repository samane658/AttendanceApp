using AttendanceApp.Models;
using AttendanceApp.ViewModel;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;

namespace AttendanceApp.Controllers
{

    public class UserController : Controller
    {
       private AppDbContext db = new AppDbContext();

        // GET: User
        public ActionResult Index()
        {
            var currentuserid= User.Identity.GetUserId();
             var currentuser = db.Users.Find(currentuserid);



            //ToDo محاسبه طلب مرخصی

            return View(currentuser);


            //var userprofile = new UserProfileViewModel();


            /*  userprofile.user = db.Users.Find(currentuserid);
              userprofile.rest = db.Rests.Where(x => x.personId == currentuserid);
              userprofile.InOut = db.Inouts.Where(x => x.personId == currentuserid);*/


            /* var currentuserid = User.Identity.GetUserId();

             /*  var userprofile = db.Users
                     .Where(u => u.Id == currentuserid)
                   .Select(u => new { u.name, u.lastName, u.picPath })
                    .ToList()
                    .Select(viewmodel => new IndexUserRestViewModel()
                    {
                        Id = currentuserid,
                        fullName = $"{viewmodel.name} {viewmodel.lastName}",
                        picPath=viewmodel.picPath
                    }
                  ).ToList();*/
            /*  var user = db.Users.Find(currentuserid);
              var viewmodel = new IndexUserRestViewModel();
              viewmodel.Id = currentuserid;
              viewmodel.Id = user.picPath;
              viewmodel.fullName = $"{user.name} {user.lastName}";

              return View(viewmodel);*/



        }

        public ActionResult IOEntry()
        {
            var currentuserid = User.Identity.GetUserId();

            var userprofile = db.Inouts
                .OrderByDescending(io => io.date)
                  .Where(u => u.personId == currentuserid)
                .Select(io => new { io.user.name, io.user.lastName, io.date, io.startTime, io.endTime, io.isRest, io.isCommited })
                 .ToList()
                 .Select(viewmodel => new UserProfileViewModel()
                 {
                     Id = currentuserid,
                     fullName = $"{viewmodel.name} {viewmodel.lastName}",
                     date = viewmodel.date,
                     startTime = viewmodel.startTime,
                     endTime = viewmodel.endTime,
                     isRest = viewmodel.isRest,
                     iscommited = viewmodel.isCommited
                 }
               ).ToList();
                
             return View(userprofile);
        }
       
        public ActionResult IEntry( )
        {
            var currentuserid = User.Identity.GetUserId();
            if(ModelState.IsValid)
            {
                inout newio = new inout();
                newio.personId = currentuserid;
                newio.date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                newio.startTime = new DateTime(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                newio.endTime = newio.startTime;
                db.Inouts.Add(newio);
                //db.SaveChanges();
            }

            return View();
        }


        
        public ActionResult OEntry()
        {
            var currentuserid = User.Identity.GetUserId();
            var today= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var exist = db.Inouts.First(io => io.personId == currentuserid && io.date == today && io.startTime == io.endTime);
                if(exist != null)
                {
               
                inout newo = new inout ();
                newo.Id = exist.Id;
                newo.date = exist.date;
                newo.startTime = exist.startTime;
                newo.endTime= new DateTime(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                newo.isRest = false;
                newo.isCommited = false;
                db.Entry(newo).State = EntityState.Modified;
                //db.SaveChanges();
            }

            return RedirectToAction("IOEntry","User");
        }

        public ActionResult RestEntry()
        {
            var currentuserid = User.Identity.GetUserId();
            return View();
        }


        [HttpPost]
        public ActionResult RestEntry(rest rest)
        {
            var currentuserid = User.Identity.GetUserId();
            if(ModelState.IsValid)
            {
                rest commitedrest = new rest();
                commitedrest.isCommited = false;
                commitedrest.personId = currentuserid;
                commitedrest.startDate = rest.startDate;
                commitedrest.endDate = rest.endDate;
                commitedrest.startTime = rest.startTime;
                commitedrest.endTime = rest.endTime;
                db.Rests.Add(commitedrest);
                //ToDo Active saving data for rest and all this controller db.save
              //  db.SaveChanges();
                TempData["Message"] = "درخواست مرخصی شما ارسال شد ، در صورت تایید مدیر در کارکرد شما محاسبه خواهد شد ";
                TempData["MessageClass"] = "success";

            }

            return View();
        }

        public ActionResult DailyReport()
        {
            var currentuserid = User.Identity.GetUserId();
            var dailyresult = db.Inouts.Where(n =>n.personId== currentuserid);
           
            return View(dailyresult.ToList());
        }
        [HttpPost]
        public ActionResult DailyReport(DateTime choosendate)
        {
            var currentuserid = User.Identity.GetUserId();
            var dailyresult = db.Inouts.Where(n => n.personId == currentuserid && n.date== choosendate);
          
            return View(dailyresult.ToList());
        }
        public ActionResult MonthlyReport()
        {
            var currentuserid = User.Identity.GetUserId();
            var monthlyresult = db.Inouts.Where(n => n.personId == currentuserid);
            return View(monthlyresult.ToList());
        }

        [HttpPost]
        public ActionResult MonthlyReport(DateTime startdate, DateTime? enddate)
        {
            var currentuserid = User.Identity.GetUserId();
            if (enddate == null) { enddate = DateTime.Now; }
            var monthlyresult = db.Inouts.Where(n => n.personId == currentuserid &&
            (n.date >= startdate && n.date <= enddate));
            return View(monthlyresult.ToList());
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