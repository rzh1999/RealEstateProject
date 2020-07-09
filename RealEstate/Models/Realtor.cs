using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class Realtor
    {
        [Key]

        public int RealtorId { get; set; }

        [Display(Name = "License Number:")]
        public int LicenseNumber { get; set; }

        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Display(Name = "Company Name:")]

        public string CompanyName { get; set; }

        [Display(Name = "Email Address:")]
        public string EmailAddress { get; set; }

        [Display(Name = "Telephone Number")]
        public string PhoneNumber { get; set; }
<<<<<<< HEAD
=======

        [Display(Name = "Login Id:")]
>>>>>>> ed7f7a51ac343d0fbd08aef5f7ceaf68fc7896aa
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }

}
