using Hotels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWebSite.ViewModels
{
    public class FullInformationAboutPassenger
    {
        public Passenger Passenger { get; set; }
        public List<Guest> Guests { get; set; }
        public IQueryable<Suit> Suits { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<Phone> Phone { get; set; }
    }
}