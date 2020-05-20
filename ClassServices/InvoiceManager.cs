using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BillingSoftware.ClassModels;
using BillingSoftware.DapperService;
using Dapper;

namespace BillingSoftware.ClassServices
{
    public class InvoiceManager:BaseManager
    {

        public InvoiceManager()
        {

        }

        #region Invoice Details
        public Int32 InsertInvDetail(InvoiceDetails invoiceDetails)
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<InvoiceDetails>())
            {
                return dapperService.Insert<InvoiceDetails>(sqlquerygenerator.GetInsert(), invoiceDetails);
            }
        }

        public Int32 UpdateInvDetail(InvoiceDetails invoiceDetails)
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<InvoiceDetails>())
            {
                return dapperService.Insert<InvoiceDetails>(sqlquerygenerator.GetUpdate(), invoiceDetails);
            }
        }

        public InvoiceDetails GetInvDetail(Int32 Id)
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<InvoiceDetails>())
            {
                return dapperService.Get<InvoiceDetails>(sqlquerygenerator.GetSelect(new { Id }), Id);
            }
        }

        public List<InvoiceDetails>GetAllInvDetail()
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<InvoiceDetails>())
            {
                return (List<InvoiceDetails>)dapperService.GetAll<Tax>(sqlquerygenerator.GetSelectAll());
            }
        }

        #endregion

        #region Invoice
        public Int32 InsertInvoice(Invoice invoice)
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Invoice>())
            {
                return dapperService.Insert<Invoice>(sqlquerygenerator.GetInsert(), invoice);
            }
        }

        public Int32 UpdateInvoice(Invoice invoice)
        {
            using (var sqlquerygenerator = new SqlQueryGenerator<Invoice>())
            {
                return dapperService.Insert<Invoice>(sqlquerygenerator.GetUpdate(), invoice);
            }
        }

        public Invoice GetInvoice(Int32 Id)
        {
            Invoice invoice = null;
            using (var sqlquerygenerator = new SqlQueryGenerator<Invoice>())
            {
                SqlMapper.GridReader gridReader = dapperService.QueryMultiple("", new { Id });

                invoice = gridReader.Read<Invoice>().SingleOrDefault();

                if(invoice!=null)
                {
                    invoice.InvoiceDetails = gridReader.Read<InvoiceDetails>().ToList();
                    invoice.Customer = gridReader.Read<Customer>().SingleOrDefault();
                    invoice.Tax = gridReader.Read<Tax>().SingleOrDefault();
                    List<Product> products = gridReader.Read<Product>().ToList();
                    List<Discount> discounts = gridReader.Read<Discount>().ToList();

                    foreach (InvoiceDetails invoiceDetails in invoice.InvoiceDetails)
                    {
                        invoiceDetails.Products = products.Where(a => a.Id == invoiceDetails.ProductId).SingleOrDefault();
                        invoiceDetails.Discount = discounts.Where(a => a.Id == invoiceDetails.DiscountId).SingleOrDefault();
                    }
                }

            }


            return invoice;
        }

        //public List<Invoice> GetAllInvoice()
        //{
        //    using (var sqlquerygenerator = new SqlQueryGenerator<Invoice>())
        //    {
        //        //return (List<Tax>)dapperService.GetAll<Tax>(sqlquerygenerator.GetSelectAll());
        //    }
        //}
        #endregion 
    }
}
