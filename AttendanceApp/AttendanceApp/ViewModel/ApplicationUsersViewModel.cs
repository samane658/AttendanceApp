using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AttendanceApp.ViewModel
{
    public class ApplicationUsersViewModel
    {
        [MaxLength(20, ErrorMessage = "حداکثر طول نام کاربر 2۰ کاراکتر است"), Required(ErrorMessage = "فیلد نام اجباری است"), Display(Name = "نام کارمند")]
        public string name { get; set; }

        [MaxLength(40, ErrorMessage = "حداکثر طول فامیلی 4۰ کاراکتر است"), Required(ErrorMessage = "فیلد فامیلی اجباری است"), Display(Name = "فامیلی کارمند")]
        public string lastName { get; set; }

        [MaxLength(30, ErrorMessage = "حداکثر طول سمت 3۰ کاراکتر است")]
        [Required(ErrorMessage = "فیلد سمت اجباری است"), Display(Name = "نام سمت")]
        public string positionName { get; set; }

        [MaxLength(500, ErrorMessage = "حداکثر طول آدرس ۰۰ 5 کاراکتر است")]
        [Required(ErrorMessage = "فیلد آدرس اجباری است"), Display(Name = "آدرس")]
        public string address { get; set; }

        [Required(ErrorMessage = "موبایل باید وارد شود"), RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره موبایل با فرمت صحیح وارد نشده است"), Display(Name = "موبایل")]
        [Index(IsUnique = true)]
        public string cellPhone { get; set; }

        [Column(TypeName = "datetime2")]
        [Required(ErrorMessage = "فیلد تاریخ تولد اجباری است"), Display(Name = "تاریخ تولد")]
        public DateTime birthDate { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage = "فیلد جنسیت اجباری است"), Display(Name = "جنسیت")]
        public string gender { get; set; }
        [Display(Name = "عکس")]
        public HttpPostedFileBase UploadedpicFile { get; set; }
        [Index(IsUnique = true)]
        [Display(Name ="ایمیل")]
        public string Email { get; set; }
        [Display(Name ="آیدی مدیر")]
        [Required(ErrorMessage = "فیلد آیدی مدیرإ اجباری است")]

        public int ManagerId { get; set; }
        [Required(ErrorMessage = "فیلدرمز عبور اجباری است"), Display(Name = "رمز عبور")]
        public string password { get; set; }
        
    }
}