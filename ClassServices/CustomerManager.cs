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
            using (var sqlquerygenerator = new SqlQueryGenerator<Customer>())
            {
                return dapperService.Insert<Customer>(sqlquerygenerator.GetInsert(), customer);
            }
        }

        public Int32 Update(Customer customer)
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Customer>())
            {
                return dapperService.Update<Customer>(sqlquerygenerator.GetUpdate(), customer);
            }
        }

        public Customer Get(Int32 Id)
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Customer>())
            {
                return dapperService.Get<Customer>(sqlquerygenerator.GetSelect(new { Id }), Id);
            }
        }

        public List<Customer> GetAll()
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Customer>())
            {
                return (List<Customer>)dapperService.GetAll<Customer>(sqlquerygenerator.GetSelectAll());
            }
        }
    }
}
