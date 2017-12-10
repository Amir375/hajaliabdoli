using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hotels.Model
{
    public class SuitBookings
    {
        public int Id { get; set; }
        public int SuitId { get; set; }
        public Suit Suit { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}
