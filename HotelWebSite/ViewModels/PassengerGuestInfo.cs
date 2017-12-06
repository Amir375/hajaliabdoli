using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelWebSite.ViewModels
{
    public class PassengerGuestInfo
    {
        [Display(Name = "نام")]
        public string P_Name { get; set; }

        //[MaxLength(50), Required]
        [Display(Name = "نام خانوادگی")]
        public string P_Family { get; set; }

        public string P_Sex { get; set; }







        public int G_Id { get; set; }

        //[MaxLength(50) , Required]
        [Display(Name = "نام")]
        public string G_Name { get; set; }

        //[MaxLength(50), Required]
        [Display(Name = "نام خانوادگی")]
        public string G_Family { get; set; }

        [Display(Name = "سن")]

        public string G_Age { get; set; }

        //[MaxLength(10), Required, Index(IsUnique = true)]
        [Display(Name = "شماره شناسنامه")]

        public string G_NationalCode { get; set; }

        [Display(Name = "جنسیت")]
        public string G_Sex { get; set; }
        public int G_PassengerId { get; set; }

    }
}