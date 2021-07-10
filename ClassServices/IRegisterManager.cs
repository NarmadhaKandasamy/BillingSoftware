using BillingSoftware.ClassModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillingSoftware.ClassServices
{
    public interface IRegisterManager
    {
        Int32 Insert(NewUserRegister newUserRegister);
    }
}
