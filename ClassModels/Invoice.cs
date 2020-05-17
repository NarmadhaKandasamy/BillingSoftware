using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BillingSoftware.ClassModels
{
    public class Invoice
    {

        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Customer Customer { get; set; }
        public List<InvoiceDetails> InvoiceDetails {get;set;}

        public Tax Tax { get; set; }
    }
}
