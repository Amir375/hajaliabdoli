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

        [MaxLength(50) , Required]
        public string Name { get; set; }

        [MaxLength(50), Required]
        public string Family { get; set; }

        [MaxLength(3)]
        public string Age { get; set; }

        [MaxLength(10) , Required , Index(IsUnique =true)]
        public string NationalCode { get; set; }

        public string Sex { get; set; }

        [MaxLength(100)]
        public string Location { get; set; }

        public virtual List<Phone> Phones { get; set; }
    }
}
