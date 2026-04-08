using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLBH_64132763.Models
{
    public class LoginModel64132763
    {
        [Key]
        [Display(Name = "Username")]
        [Required(ErrorMessage = "You must enter an username")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "You must enter a password")]
        [Display(Name = "Password")]
        public string Password { set; get; }
    }
}