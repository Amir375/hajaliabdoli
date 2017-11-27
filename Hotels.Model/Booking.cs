using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public string EmptyorFull { get; set; }
        public string Level { get; set; }
        public string TotalPrice { get; set; }
        public List<Suit> Suits { get; set; }
        public List<Room> Rooms { get; set; }
        public Option Option { get; set; }
    }
}
