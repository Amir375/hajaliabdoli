using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public class Phone
    {
        public int Id { get; set; }
        [Display(Name ="مقدار")]
        public string Value { get; set; }
        [Display(Name = "نوع شماره")]
        public PhoneType PhoneType { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }

    }
}
