using System;
using System.Collections.Generic;
using System.Text;
using BillingSoftware.ClassModels;
using BillingSoftware.DapperService;


namespace BillingSoftware.ClassServices
{
    public class SupplierManger:BaseManager
    {
        public SupplierManger()
        {

        }
        public Int32 Insert(Supplier supplier)
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Supplier>())
            {
                return dapperService.Insert<Supplier>(sqlquerygenerator.GetInsert(), supplier);
            }
        }

        public Int32 Update(Supplier supplier)
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Supplier>())
            {
                return dapperService.Insert<Customer>(sqlquerygenerator.GetUpdate(), supplier);
            }
        }

        public Int32 Get(Int32 Id)
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Supplier>())
            {
                return dapperService.Insert<Supplier>(sqlquerygenerator.GetSelect(new { Id }), Id);
            }
        }

        public List<Supplier> GetAll()
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Supplier>())
            {
                return (List<Supplier>)dapperService.GetAll<Supplier>(sqlquerygenerator.GetSelectAll());
            }
        }
    }
}
