using System;
using System.Collections.Generic;
using System.Text;

namespace BillingSoftware.ClassModels
{
    public class User
    {
        public User()
        {
            UserName = string.Empty;
            IsActive = false;
            IsSuperAdmin = false;
            CompanyId = 0;
            Id = 0;

            company = new Company();
            branchDetail = new BranchDetail();
        }

        public string UserName { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsSuperAdmin { get; set; }
        public Int32 CompanyId { get; set; }
        public Int32 Id { get; set; }

        public Company company { get; set; }

        public BranchDetail branchDetail { get; set; }
    }
}
