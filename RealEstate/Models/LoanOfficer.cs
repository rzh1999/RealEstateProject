using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class LoanOfficer
    {
        [Key]

        public int LoanOfficerId { get; set; }

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
    }
}
