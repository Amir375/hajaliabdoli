using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    [Table("Person", Schema = "People")]
    public abstract class Person
    {
        public int Id { get; set; }

        [MaxLength(50 , ErrorMessage = "نام نباید بیش از 50 کاراکتر باشد")
            , Required (ErrorMessage = "پر کردن این فیلد الزامی است")]
        [Display(Name = "نام")]
        public string Name { get; set; }

        [MaxLength(50 , ErrorMessage ="نام خانوادگی نباید بیش از 50 کاراکتر یاشد")
            , Required(ErrorMessage = "پر کردن این فیلد الزامی است")]
        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }

        [MaxLength(3 , ErrorMessage ="سن نباید بیش از 3 کاراکتر باشد")]
        [Display(Name = "سن")]
        public string Age { get; set; }

        [StringLength(10 , ErrorMessage ="شماره شناسنامه نباید بیش از 10 کاراکتر باشد")
            , Required(ErrorMessage = "پر کردن این فیلد الزامی است")
            , Index(IsUnique = true)]
        [RegularExpression(@"\d{10}" , ErrorMessage = "فرمت شماره شناسنامه وارد شده اشتباه است")]
        [Display(Name = "شماره شناسنامه")]
        public string NationalCode { get; set; }

        [Display(Name = "جنسیت")]
        public string Sex { get; set; }

        [MaxLength(100 , ErrorMessage = "آدرس وارد شده نباید بیش از 100 کاراکتر باشد")]
        [Display(Name = "آدرس")]
        public string Location { get; set; }

        public virtual List<Phone> Phones { get; set; }
    }
}
