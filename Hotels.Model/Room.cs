using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public class Room
    {
        public int Id { get; set; }
        public string NumberOfBeds { get; set; }
        public string NumberOfRoom { get; set; }
        public string Floor { get; set; }
        public int Price { get; set; }

    }
}
