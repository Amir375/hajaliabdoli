using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Age { get; set; }
        public string NationalCode { get; set; }
        public string Sex { get; set; }
        public Passenger Passenger { get; set; }
    }
}
