using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hotels.Model
{
    public class Employee : Person
    {
        [MaxLength(20 ,ErrorMessage = "نام کاربری وارد شده نباید بیش از 20 کاراکتر باشد")
            , Required(ErrorMessage = "پر کردن این فیلد الزامی است")
            , Index(IsUnique = true)]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }
        //[NotMapped , Required, Index(IsUnique = true)]
        //public string Password { get; set; }
        [Display(Name ="رمز عبور")]
        [Required (ErrorMessage = "پر کردن این فیلد الزامی است")]
        public string PasswordHash { get; set; }
    }
}
