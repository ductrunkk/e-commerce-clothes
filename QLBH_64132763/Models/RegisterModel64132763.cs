using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLBH_64132763.Models
{
    public class RegisterModel64132763
    {
        [Key]
        public int ID { set; get; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        public string UserName { set; get; }

        [Display(Name = "Password")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { set; get; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password confirmation does not match.")]
        public string ConfirmPassword { set; get; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { set; get; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { set; get; }

        [Display(Name = "Address")]
        public string Address { set; get; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        public string Email { set; get; }

        [Display(Name = "Phone")]
        public string Phone { set; get; }

        [Display(Name = "Province/City")]
        public string ProvinceID { set; get; }

        [Display(Name = "District")]
        public string DistrictID { set; get; }
    }
}
