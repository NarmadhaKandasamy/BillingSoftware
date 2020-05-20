using System;
using System.Collections.Generic;
using System.Text;
using BillingSoftware.ClassModels;
using BillingSoftware.DapperService;


namespace BillingSoftware.ClassServices
{
    public class CategoryManager:BaseManager
    {

        public CategoryManager()
        {

        }

        public Int32 Insert(Category category)
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Category>())
            {
                return dapperService.Insert<Category>(sqlquerygenerator.GetInsert(), category);
            }
        }

        public Int32 Update(Category category)
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Category>())
            {
                return dapperService.Update<Category>(sqlquerygenerator.GetUpdate(), category);
            }
        }

        public Category Get(Int32 Id)
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Category>())
            {
                return dapperService.Get<Category>(sqlquerygenerator.GetSelect(new { Id }), Id);
            }
        }

        public List<Category> GetAll()
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Category>())
            {
                return (List<Category>)dapperService.GetAll<Category>(sqlquerygenerator.GetSelectAll());
            }
        }
    }
}
