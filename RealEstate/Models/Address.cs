using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class Address
    {
        [Key]

        public int AddressId { get; set; }

        [Display(Name = "Address:")]
        public string StreetAddress { get; set; }

        [Display(Name = "City:")]
        public string City { get; set; }

        [Display(Name = "State:")]
        public string State { get; set; }

        [Display(Name = "Zip Code:")]
        public int Zip { get; set; }

        [Display(Name = "Longitude:")]
        public int Longitude { get; set; }

        [Display(Name = "Latitude:")]
        public int Latitude { get; set; }
    }
}
