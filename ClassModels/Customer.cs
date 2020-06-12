using System;
using System.Collections.Generic;
using System.Text;
using BillingSoftware.DataAnnotation;

namespace BillingSoftware.ClassModels
{
    [StoredAs("customer_master")]
    public class Customer
    {
        [PrimaryKey(Identity =true)]
        public Int32 Id { get; set; }

        [StoredAs("Code")]
        public string CustCode { get; set; }

        [StoredAs("Name")]
        public string CustName { get; set; }

        [StoredAs("ContactName")]
        public string ContactName { get; set; }

        [StoredAs("Add1")]
        public string Address1 { get; set; }

        [StoredAs("Add2")]
        public string Address2 { get; set; }

        [StoredAs("City")]
        public string City { get; set; }

        [StoredAs("PostalCode")]
        public string PostalCode { get; set; }

        [StoredAs("Phone")]
        public string Phone { get; set; }

        [StoredAs("Mobile")]
        public string Mobile { get; set; }

    }
}
