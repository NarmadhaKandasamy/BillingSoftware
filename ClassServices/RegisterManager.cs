using System;
using System.Collections.Generic;
using System.Text;
using BillingSoftware.ClassModels;
using BillingSoftware.DapperService;

namespace BillingSoftware.ClassServices
{
    public class RegisterManager : BaseManager 
    {
        public static int Insert(NewUserRegister newUserRegister)
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<NewUserRegister>())
            {
                return dapperService.Insert<NewUserRegister>(sqlquerygenerator.GetInsert(), newUserRegister);
            }
        }

        //public Int32 Update(Tax product)
        //{
        //    using (var sqlquerygenerator = new SqlQueryGenerator<Tax>())
        //    {
        //        return dapperService.Update<Tax>(sqlquerygenerator.GetUpdate(), product);
        //    }
        //}

        //public Tax Get(Int32 Id)
        //{
        //    using (var sqlquerygenerator = new SqlQueryGenerator<Tax>())
        //    {
        //        return dapperService.Get<Tax>(sqlquerygenerator.GetSelect(new { Id }), Id);
        //    }
        //}

        //public List<Tax> GetAll()
        //{
        //    using (var sqlquerygenerator = new SqlQueryGenerator<Tax>())
        //    {
        //        return (List<Tax>)dapperService.GetAll<Tax>(sqlquerygenerator.GetSelectAll());
        //    }       
    }
}
