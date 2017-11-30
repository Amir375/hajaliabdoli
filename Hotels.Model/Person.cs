using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public abstract class Person
    {
        public int Id { get; set; }

        //[MaxLength(50) , Required]
        [Display(Name = "نام")]
        public string Name { get; set; }

        //[MaxLength(50), Required]
        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }

        //[MaxLength(3)]
        [Display(Name = "سن")]
        public string Age { get; set; }

        //[MaxLength(10) , Required , Index(IsUnique =true)]
        [Display(Name = "شماره شناسنامه")]
        public string NationalCode { get; set; }

        [Display(Name = "جنسیت")]
        public string Sex { get; set; }

        //[MaxLength(100)]
        [Display(Name = "آدرس")]
        public string Location { get; set; }

        public virtual List<Phone> Phones { get; set; }
    }
}
