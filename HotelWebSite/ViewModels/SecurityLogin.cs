using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelWebSite.ViewModels
{
    public class SecurityLogin
    {
        [Required(ErrorMessage = "ورود نام کاربری الزامی است")]
        [Display(Name ="نام کاربری")]
        public string Username { get; set; }

        [Required(ErrorMessage = "ورود رمز عبور الزامی است")]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        public bool RemmemberMe { get; set; }
    }
}