using System;
using System.Collections.Generic;
using System.Text;
using BillingSoftware.ClassModels;
using BillingSoftware.DapperService;

namespace BillingSoftware.ClassServices
{
    public class CustomerManager:BaseManager
    {
        public CustomerManager()
        {

        }

        public Int32 Insert(Customer customer)
        {
            return 0;
            //using (SqlQueryGenerator sqlQueryGenerator = new SqlQueryGenerator<Customer>())
            //{
            //    return dapperService.Insert<Customer>(sqlQueryGenerator.GetInsert(), customer);
            //}                
        }
    }
}
