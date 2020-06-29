using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using BillingSoftware.DapperService;
using System.Reflection;

namespace BillingSoftware.ClassServices
{
    public class BaseManager : IDisposable
    {
        public static DapperDAO dapperService;

        public BaseManager()
        {
            //dapperService = new DapperDAO(ConfigurationManager.AppSettings["Dbconnectionstring"],60);
            dapperService = new DapperDAO(@"Server=.\SQLExpress;AttachDbFilename=C:\Working\BillingSoftware\Data\BillingBase.mdf;Database=dbname;Trusted_Connection=Yes;", 60);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
        