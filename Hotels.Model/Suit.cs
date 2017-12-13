using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    [Table(name:"Suit_Room")]
    public class Suit
    {
        public int Id { get; set; }

        //[Display(Name = "تاریخ ورود")]
        //public DateTime? EntryDate { get; set; }

        //[Display(Name = "تاریخ خروج")]
        //public DateTime? DateOfDeparture { get; set; }

        [Display(Name = "خالی یا پر بودن")]
        [Required(ErrorMessage = "پر کردن این فیلد الزامی است")]
        public bool EmptyOrFull { get; set; }

        [Display(Name = "عنوان اتاق یا سوییت")]
        public string Title { get; set; }   // Normal or Special or ....

        [Display(Name = "نوع")]
        public string Type { get; set; }    // Suit Or Room

        [Display(Name = "تعداد تخت")]
        public string NumberOfBeds { get; set; }

        [Display(Name = "طبقه")]
        public string Floor { get; set; }

        [Display(Name = "تعداد اتاق")]
        public string NumberOfRoom { get; set; }

        [Display(Name = "تعداد تخت های سینگل")]
        public string NumberOfSingleBeds { get; set; }

        [Display(Name = "تعداد تخت های دبل")]
        public string NumberOfDoubleBeds { get; set; }

        [Display(Name = "ظرفیت")]
        public int Capacity { get; set; }

        [Display(Name = "قیمت")]
        public long Price { get; set; }

        [Display(Name = "عکس :")]
        public string PhotoPath { get; set; }


        public Option Option { get; set; }

        public List<Booking> Bookings { get; set; }

        //public int BookingId { get; set; }


    }
}
