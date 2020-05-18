using System;

namespace BillingSoftware.DataAnnotation
{
    public class StoredAs : Attribute
    {
        /// <summary>
        ///  value storer
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        ///  Stored As attributes
        /// </summary>
        /// <param name="value"></param>
        public StoredAs(string value)
        {
            this.Value = value;
        }
    }
}
