using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class Checklist
    {
        [Key]

        public int ChecklistId { get; set; }

        [Display(Name = "Deposit Paid:")]
        public bool DepositPaid { get; set; }

        [Display(Name = "Loan Approved:")]
        public bool IsApproved { get; set; }

        [Display(Name = "Offer Submitted:")]
        public bool IsOfferMade { get; set; }

        [Display(Name = "Inspection Complete:")]
        public bool IsInspected { get; set; }

        [Display(Name = "Under Contract:")]
        public bool IsUnderContract { get; set; }

        [Display(Name = "Clear To Close:")]
        public bool IsClearToClose { get; set; }

        [Display(Name = "Closed:")]
        public bool IsClosed { get; set; }

    }
}
