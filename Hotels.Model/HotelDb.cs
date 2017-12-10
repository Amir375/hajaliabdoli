namespace Hotels.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HotelDb : DbContext
    {
        public HotelDb()
            : base("HotelDb")
        {
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Suit> Suitss { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Option> Options { get; set; }

        //public DbSet<SuitBookings> SuitBookings { get; set; }

    }

}


//public DbSet<Person> People { get; set; }
//public DbSet<Passenger> Passengers { get; set; }
//public DbSet<Employee> Employees { get; set; }
//public DbSet<Phone> Phones { get; set; }
//public DbSet<Guest> Guests { get; set; }
//public DbSet<Room> Rooms { get; set; }
//public DbSet<Suit> Suits { get; set; }
//public DbSet<Booking> Bookings { get; set; }
//public DbSet<Option> Options { get; set; }
//public DbSet<SuitBookings> SuitBookings { get; set; }
