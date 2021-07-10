using BillingSoftware.ClassModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingSoftware.ClassServices;
using BillingSoftware.ClassServices.Email;

namespace BillingService.BusinessServices
{
    public class RegisterHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newUserRegister"></param>
        /// <returns></returns>
        public static Boolean NewUserRegisteration(NewUserRegister newUserRegister)
        {
            if (newUserRegister == null)
                return false;

            // Generate custome unique code
            newUserRegister.Code = Guid.NewGuid().ToString();


            if (RegisterManager.Insert(newUserRegister)==0)
            {                
                return false;
            }
            else
            {
                EmailTriggerNewCustomer(newUserRegister);
                return true;
                
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        private static void EmailTriggerNewCustomer(NewUserRegister newUserRegister)
        {
            EmailManager.SendUserActivationMail(newUserRegister);
        }
    }
}
