using System;

namespace BillingSoftware.DataAnnotation
{
    public class Scheme:Attribute
    {
        public string Value { get; set; }

        public Scheme(string value)
        {
            this.Value = value;
        }
    }
}
