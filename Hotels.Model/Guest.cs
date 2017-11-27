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
        
        [MaxLength(50) , Required]
        public string Name { get; set; }

        [MaxLength(50), Required]
        public string Family { get; set; }

        public string Age { get; set; }

        [MaxLength(10), Required, Index(IsUnique = true)]
        public string NationalCode { get; set; }

        public string Sex { get; set; }

        public Passenger Passenger { get; set; }
    }
}
