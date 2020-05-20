using System;
using System.Collections.Generic;
using System.Text;
using BillingSoftware.ClassModels;
using BillingSoftware.DapperService;


namespace BillingSoftware.ClassServices
{
    public class TaxManager:BaseManager
    {

        public TaxManager()
        {

        }

        public Int32 Insert(Tax tax)
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Tax>())
            {
                return dapperService.Insert<Tax>(sqlquerygenerator.GetInsert(), tax);
            }
        }

        public Int32 Update(Tax product)
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Tax>())
            {
                return dapperService.Insert<Tax>(sqlquerygenerator.GetUpdate(), product);
            }
        }

        public Int32 Get(Int32 Id)
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Tax>())
            {
                return dapperService.Insert<Tax>(sqlquerygenerator.GetSelect(new { Id }), Id);
            }
        }

        public List<Tax> GetAll()
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Tax>())
            {
                return (List<Tax>)dapperService.GetAll<Tax>(sqlquerygenerator.GetSelectAll());
            }
        }
    }
}
