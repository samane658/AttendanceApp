using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AttendanceApp.ViewModel
{
    public class IndexUserRestViewModel
    {
        public string Id { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string fullName { get; set; }

       public string picPath { get; set; }
      /*  public Double? sumOfRestinYear { get; set; }
        public double? remainRestinYear { get; set; }*/
    }
}