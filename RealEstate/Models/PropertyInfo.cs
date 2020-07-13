using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
        public class PropertyInfo
        {
            public int PropertyInfoId { get; set; }
            [Display(Name = "Square Feet:")]
            public int SquareFeet { get; set; }
            [Display(Name = "Beds:")]
            public int Beds { get; set; }
            [Display(Name = "Baths:")]
            public int Baths { get; set; }
            [Display(Name = "Listing Price:")]
            public double Price { get; set; }
        }
    
}