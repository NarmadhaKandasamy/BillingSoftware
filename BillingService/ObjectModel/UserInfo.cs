using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingService.ObjectModel
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsSuperAdmin { get; set; }
        public Int32 CompanyId { get; set; }
        public Int32 Id { get; set; }
    }
}
