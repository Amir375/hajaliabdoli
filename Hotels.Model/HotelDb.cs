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

    }

}