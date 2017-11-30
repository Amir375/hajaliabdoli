using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public class Passenger:Person
    {
        [Display(Name = "تعداد روزهای اقامت")]
        public string DaysStays { get; set; }

        //[MaxLength(20) , Required , Index(IsUnique =true)]
        [Display(Name = "شماره پاسپورت")]
        public string PassportNumber { get; set; }

        public virtual List<Guest> Guests { get; set; }
    }
}
