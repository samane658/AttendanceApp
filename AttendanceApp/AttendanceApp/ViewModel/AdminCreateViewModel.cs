using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AttendanceApp.ViewModel
{
    public class AdminCreateViewModel
    {

        [Required]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "کلمه عبور باید بین 6 تا 100 کاراکتر باشد", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تایید کلمه عبور")]
        [Compare("Password", ErrorMessage = "پسوورد و تایید آن متفاوت هستند")]
        public string ConfirmPassword { get; set; }

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

        [Required, RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره موبایل با فرمت صحیح وارد نشده است"), Display(Name = "موبایل")]
        //[Index(IsUnique = true)]
        public string cellPhone { get; set; }

        [Column(TypeName = "datetime2")]
        [Required(ErrorMessage = "فیلد تاریخ تولد اجباری است"), Display(Name = "تاریخ تولد")]
        public System.DateTime birthDate { get; set; }

        [MaxLength(1)]
        [Required(ErrorMessage = "فیلد جنسیت اجباری است"), Display(Name = "جنسیت")]
        public string gender { get; set; }

        [MaxLength(200)]
        [Display(Name = "جنسیت")]
        public HttpPostedFileBase picPath { get; set; }


    }
}