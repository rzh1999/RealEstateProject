using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class LoanOfficerClosingRepViewModel
    {
        public IEnumerable<LoanOfficer> LoanOfficers { get; set; }

        public IEnumerable<ClosingRep> ClosingReps { get; set; }
    }
}
