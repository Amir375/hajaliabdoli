﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    [Table("Passenger", Schema = "People")]
    public class Passenger : Person
    {

        [Required(ErrorMessage = "پر کردن این فیلد الزامی است")]
        [Index(IsUnique =true)]
        [StringLength(9, MinimumLength = 9 , ErrorMessage = "شماره پاسپورت باید 9 کاراکتر باشد")]
        [RegularExpression (@"^\w\d{8}$",ErrorMessage ="فرمت پاسپورت وارد شده اشتباه است")]
        [Display(Name = "شماره پاسپورت")]
        public string PassportNumber { get; set; }
        public virtual List<Booking> Bookings { get; set; }
        public virtual List<Guest> Guests { get; set; }

        public string PhotoPath { get; set; }

    }
}
