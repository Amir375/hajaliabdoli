using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MidelName { get; set; }
        public string Family { get; set; }
        public string Age { get; set; }
        public string NationalCode { get; set; }
        public string Sex { get; set; }
        public string Location { get; set; }
        public List<Phone> Phones { get; set; }
    }
}
