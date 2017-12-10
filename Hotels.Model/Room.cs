using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public class Room
    {
        public int Id { get; set; }

        [Display(Name = "تاریخ ورود")]
        [Required(ErrorMessage = "وارد کردن تاریخ ورود الزامی است")]
        public DateTime EntryDate { get; set; }

        [Display(Name = "تاریخ خروج")]
        [Required(ErrorMessage = "وارد کردن تاریخ خروج الزامی است")]
        public DateTime DateOfDeparture { get; set; }

        [Display(Name = "خالی یا پر بودن")]
        [Required(ErrorMessage = "پر کردن این فیلد الزامی است")]
        public bool EmptyOrFull { get; set; }

        [Display(Name = "نوع سوییت")]
        public string RoomType { get; set; }

        [Display(Name = "تعداد تخت")]
        public string NumberOfBeds { get; set; }

        [Display(Name = "طبقه")]
        public string Floor { get; set; }

        [Display(Name = "تعداد تخت های سینگل")]
        public string NumberOfSingleBeds { get; set; }

        [Display(Name = "تعداد تخت های دبل")]
        public string NumberOfDoubleBeds { get; set; }

        [Display(Name = "ظرفیت")]
        public string Capacity { get; set; }

        public Option Option { get; set; }
        public List<Booking> Bookings { get; set; }
        public int BookingId { get; set; }
    }

}
