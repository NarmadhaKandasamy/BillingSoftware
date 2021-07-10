using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingSoftware.ClassModels;

namespace BillingService.ObjectModel
{
    public class UserInfo
    {
        public UserInfo()
        {
            User = new User();
        }

        public User User { get; set;}
        public string Token;

    }
}
