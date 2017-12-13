using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public class Booking
    {
        public int Id { get; set; }

        [Display(Name = "تعداد روزهای اقامت")]
        public string DaysStays { get; set; }

        [Display(Name = "تاریخ ورود")]
        [Required(ErrorMessage = "وارد کردن تاریخ ورود الزامی است")]
        public DateTime EntryDate { get; set; }

        [Display(Name = "تاریخ خروج")]
        [Required(ErrorMessage = "وارد کردن تاریخ خروج الزامی است")]
        public DateTime DateOfDeparture { get; set; }

        [Display(Name = "تعداد افراد بزرگسال")]
        public int NumberOfPerson { get; set; }

        [Display(Name = "تعداد افراد خردسال")]
        public int NumberOfChild { get; set; }

        [Display(Name = "سوییت یا اتاق")]
        public string SuitOrRoom { get; set; }

        public long Price { get; set; }

        public bool Expire { get; set; }

        public int PassengerId { get; set; }
        public Passenger Passengers { get; set; }
        public int SuitId { get; set; }
        public Suit Suit { get; set; }

    }
}
