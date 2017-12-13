using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelWebSite.ViewModels
{
    public class SuitCreate
    {
        [Display(Name = "خالی یا پر بودن")]
        [Required(ErrorMessage = "پر کردن این فیلد الزامی است")]
        public bool EmptyOrFull { get; set; }

        [Display(Name = "عنوان ")]
        public string Title { get; set; }

        [Display(Name = "نوع ")]
        public string Type { get; set; }

        [Display(Name = "تعداد تخت")]
        public string NumberOfBeds { get; set; }

        [Display(Name = "طبقه")]
        public string Floor { get; set; }

        [Display(Name = "تعداد اتاق")]
        public string NumberOfRoom { get; set; }

        [Display(Name = "تعداد تخت های سینگل")]
        public string NumberOfSingleBeds { get; set; }

        [Display(Name = "تعداد تخت های دبل")]
        public string NumberOfDoubleBeds { get; set; }

        [Display(Name = "ظرفیت")]
        public int Capacity { get; set; }

        [Display(Name = "قیمت")]
        public long Price { get; set; }

        [Display(Name ="عکس")]
        public HttpPostedFileBase PhotoFile { get; set; }

    }
}