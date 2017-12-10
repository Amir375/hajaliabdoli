using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hotels.Model.Library;

namespace Hotels.Model
{
    [Table("Employee", Schema = "People")]
    public class Employee : Person
    {
        [MaxLength(20, ErrorMessage = "نام کاربری وارد شده نباید بیش از 20 کاراکتر باشد")
            , Required(ErrorMessage = "پر کردن این فیلد الزامی است")
            , Index(IsUnique = true)]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        [NotMapped]
        [ScaffoldColumn(true)]
        [Display(Name = "رمز عبور")]
        public string Password
        {
            get
            {
                return this.PasswordHash;
            }

            set
            {
                this.PasswordHash = PassHash.CalculateMD5Hash(value.ToString());
            }
        }
        [ScaffoldColumn(false)]
        public string PasswordHash { get; set; }
        public string PhotoPath { get; set; }
    }
}
