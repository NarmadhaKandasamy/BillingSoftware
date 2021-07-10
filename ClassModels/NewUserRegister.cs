using System;
using System.Collections.Generic;
using System.Text;
using BillingSoftware.DataAnnotation;

namespace BillingSoftware.ClassModels
{
    [StoredAs("register_master")]
    public class NewUserRegister
    {
        [PrimaryKey(Identity = true)]
        public int Id { get; set; }

        public string Code { get; set; }

        [StoredAs("FirstName")]
        public string FirstName { get; set; }

        [StoredAs("LastName")]
        public string LastName { get; set; }

        [StoredAs("CompanyName")]
        public string CompanyName { get; set; }

        [StoredAs("Email")]
        public string Email { get; set; }

        [StoredAs("Add1")]
        public string Add1 { get; set; }

        [StoredAs("Add2")]
        public string Add2 { get; set; }

        [StoredAs("Add3")]
        public string Add3 { get; set; }

        [StoredAs("City")]
        public string City { get; set; }

        [StoredAs("Postal")]
        public string Postal { get; set; }

        [StoredAs("StateId")]
        public string State { get; set; }

        [StoredAs("CountryId")]
        public string Country { get; set; }

        [StoredAs("Phone")]
        public string Phone { get; set; }

        [StoredAs("IsValidate")]
        public Boolean TermsCondition { get; set; }
    }
}
