using AttendanceApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AttendanceApp.ViewModel
{
    public class UserProfileViewModel
    {
       public string Id { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string fullName { get; set; }

        [Display(Name = "تاریخ")]
        public DateTime? date { get; set; }

        [Display(Name = "شروع")]
        public DateTime? startTime { get; set; }

        [Display(Name = "پایان")]
        public DateTime? endTime { get; set; }

        [Display(Name = "مرخصی ؟")]
        public bool? isRest { get; set; }

        [Display(Name = "تایید شده ؟")]
        public bool? iscommited { get; set; }
       
        public double? remainRestinYear { get; set; }



        /* public ApplicationUser user { get; set; }
         public IQueryable <inout> InOut { get; set; }
         public IQueryable <rest> rest { get; set; }
         */
    }
}