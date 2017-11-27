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

        public string DaysStays { get; set; }

        [MaxLength(20) , Required , Index(IsUnique =true)]
        public string PassportNumber { get; set; }

        public virtual List<Guest> Guests { get; set; }
    }
}
