using System;
using System.Collections.Generic;
using System.Text;
using BillingSoftware.DapperService;

namespace BillingSoftware.ClassServices
{
    public class BaseManager
    {
        public static DapperDAO dapperService;

        public BaseManager()
        {
            dapperService = new DapperDAO("",60);
        }
    }
}
