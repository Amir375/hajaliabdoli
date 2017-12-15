using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public enum PhoneType
    {
        [Display(Name = "شماره منزل")]
        HomeNumber,
        [Display(Name = "شماره اضطراری")]
        Emergency,
        [Display(Name = "شماره موبایل")]
        MobileNumber
    }
}
