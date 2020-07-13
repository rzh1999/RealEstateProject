using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class Client
    {
        [Key]

        public int ClientId { get; set; }

        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name:")]

        public string LastName { get; set; }

       
        [Display(Name = "DOB:")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        [Display(Name = "Email Address:")]
        public string EmailAddress { get; set; }

        [Display(Name = "Telephone Number:")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Social Security Number:")]
        public int SocialSecurityNumber { get; set; }

        [Display(Name = "Buyer or Seller:")]
        public string TypeOfClient { get; set; }

        [Display(Name = "Closing Date:")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? ClosingDate { get; set; }

        [Display(Name = "Deposit Amount:")]
        public double DepositAmount { get; set; }

        [Display(Name = "Approved Amount:")]
        public double ApprovedAmount { get; set; }

        [Display(Name = "Approval Date:")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? ApprovalDate { get; set; }

        [Display(Name = "Inspection Date:")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? InspectionDate { get; set; }

        [Display(Name = "Login Id:")]
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [Display(Name = "Realtor:")]
        [ForeignKey("Realtor")]
        public int? RealtorId { get; set; }
        public Realtor Realtor { get; set; }

        [Display(Name = "Loan Officer:")]
        [ForeignKey("LoanOfficer")]
        public int? LoanOfficerId { get; set; }
        public LoanOfficer LoanOfficer { get; set; }

        [Display(Name = "Closing Rep:")]
        [ForeignKey("ClosingRep")]
        public int? ClosingRepId { get; set; }
        public ClosingRep ClosingRep { get; set; }

        
        [ForeignKey("Checklist")]
        public int? ChecklistId { get; set; }
        public Checklist Checklist { get; set; }

        [ForeignKey("Address")]

        public int? AddressId { get; set; }
        public Address Address { get; set; }

    }
}
