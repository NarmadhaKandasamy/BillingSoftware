using System;
using System.Collections.Generic;
using System.Text;

namespace BillingSoftware.ClassModels
{
    public class AdminSettings
    {
        public string Language { get; set; }
        public Boolean IsMultipleCompany { get; set; }
        public Int32 CompanyCount { get; set; }
        public Boolean IsAdminAccount { get; set; }
        public Int32 UserAccountCount { get; set; }
        public Int32 Trailperiod { get; set; }
        public DateTime ExpiredDate { get; set; }
        public List<Company> Companies { get; set; }
    }
}
