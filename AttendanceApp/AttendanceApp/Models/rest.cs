using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AttendanceApp.Models
{
    public class rest
    {
        public int Id { get; set; }

        [Display(Name = "تاریخ شروع") ]
        [Required(ErrorMessage = "فیلد تاریخ شروع اجباری است")]
        public DateTime startDate { get; set; }

        [Display(Name = "تاریخ پایان")]
        [Required(ErrorMessage = "فیلد تاریخ پایان اجباری است")]
        public DateTime endDate { get; set; }

        [Display(Name = "ساعت شروع")]
        [Required(ErrorMessage = "فیلد ساعت شروع اجباری است")]
        public DateTime startTime { get; set; }
        [Display(Name = "ساعت پایان")]
        [Required(ErrorMessage = "فیلد ساعت پایان اجباری است")]
        public DateTime endTime { get; set; }
        public bool isCommited { get; set; }
        public ICollection<ApplicationUser> persons { get; set; }
        public string personId { get; set; }
    }
}