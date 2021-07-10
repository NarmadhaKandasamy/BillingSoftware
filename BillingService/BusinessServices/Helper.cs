using BillingService.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingService.BusinessServices
{
    public class Helper
    {
        public static UserInfo ProcessLoginInfo(LoginUser loginUser)
        {
            UserInfo userInfo = new UserInfo();

            userInfo.User.UserName = loginUser.UserName;


            return userInfo;
        }
    }
}
