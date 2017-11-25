using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public class Passenger:Person
    {
        public string DaysStays { get; set; }
        public string PassportNumber { get; set; }
        public List<Guest> Guests { get; set; }
    }
}
