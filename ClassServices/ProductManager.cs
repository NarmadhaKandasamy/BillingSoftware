using System;
using System.Collections.Generic;
using System.Text;
using BillingSoftware.ClassModels;
using BillingSoftware.DapperService;


namespace BillingSoftware.ClassServices
{
    public class ProductManager:BaseManager
    {
        public ProductManager()
        {

        }

        public Int32 Insert(Product product)
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Product>())
            {
                return dapperService.Insert<Product>(sqlquerygenerator.GetInsert(), product);
            }
        }

        public Int32 Update(Product product)
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Product>())
            {
                return dapperService.Update<Product>(sqlquerygenerator.GetUpdate(), product);
            }
        }

        public Product Get(Int32 Id)
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Product>())
            {
                return dapperService.Get<Product>(sqlquerygenerator.GetSelect(new { Id }), Id);
            }
        }

        public List<Product> GetAll()
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Product>())
            {
                return (List<Product>)dapperService.GetAll<Product>(sqlquerygenerator.GetSelectAll());
            }
        }
    }
}
