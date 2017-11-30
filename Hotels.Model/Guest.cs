using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hotels.Model
{
    public class Guest
    {
        public int Id { get; set; }

        //[MaxLength(50) , Required]
        [Display(Name = "نام")]
        public string Name { get; set; }

        //[MaxLength(50), Required]
        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }

        [Display(Name = "سن")]

        public string Age { get; set; }

        //[MaxLength(10), Required, Index(IsUnique = true)]
        [Display(Name = "شماره شناسنامه")]

        public string NationalCode { get; set; }

        [Display(Name = "جنسیت")]
        public string Sex { get; set; }
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }
    }
}
