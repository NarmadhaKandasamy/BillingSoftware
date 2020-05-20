using System;
using System.Collections.Generic;
using System.Text;

namespace BillingSoftware.ClassModels
{
    public class InvoiceDetails
    {

        public string InvoiceNo { get; set; }        
        public Int32 ProductId { get; set; }
        public Product Products { get; set; }
        public Int32 Qty { get; set; }
        public decimal rate { get; set; }
        public decimal Total { get; set; }
        public Int32 DiscountId { get; set; }
        public Discount Discount { get; set; }
    }
}
