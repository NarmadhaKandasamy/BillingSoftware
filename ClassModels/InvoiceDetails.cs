using System;
using System.Collections.Generic;
using System.Text;

namespace BillingSoftware.ClassModels
{
    public class InvoiceDetails
    {

        public string InvoiceNo { get; set; }
        public Product Products { get; set; }
        public Int32 Qty { get; set; }
        public Int32 Total { get; set; }
        public Discount Discount { get; set; }
    }
}
