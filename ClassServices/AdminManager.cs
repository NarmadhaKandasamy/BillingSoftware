using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
namespace BillingSoftware.ClassServices
{
    public class AdminManager : BaseManager
    {
        public Boolean DBbackup()
        {
            try
            {   
                string dbname = string.Format("billing_db_{0}.bak", DateTime.Now.ToString("ddMMyyyy"));
                string query = "BACKUP DATABASE BillingBase TO DISK='C:\\Working\\BillingSoftware\\BackUp\\"+ dbname + "'";
                dapperService.ExecuteQueery(query);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
