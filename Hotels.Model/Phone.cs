using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public class Phone
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public List<PhoneType> PhoneType { get; set; }
        public Person Person { get; set; }

    }
}
