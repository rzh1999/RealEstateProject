using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public double Longitude { get; set; }

        [Display(Name = "Latitude:")]
        public double Latitude { get; set; }

        public Int64 PropertyId { get; set; }

        [ForeignKey("PropertyInfo")]
        public int? PropertyInfoId { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
    }
}
