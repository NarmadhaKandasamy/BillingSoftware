using System;
using System.Collections.Generic;
using System.Text;

namespace BillingSoftware.ClassModels
{
    public class Company : BaseAddress
    {
        public string Proprietor { get; set; }
        public string ContactNumber { get; set; }
        public string Tin { get; set; }
        public string Registration { get; set; }        
        public List<BranchDetail> Branches { get; set; }
    }
}
