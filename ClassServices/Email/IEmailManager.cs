using BillingSoftware.ClassModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillingSoftware.ClassServices.Email
{
    public interface IEmailManager
    {
        void SendUserActivationMail(NewUserRegister newUserRegister);
        void Email(string htmlString, string ToEmail);
    }
}
