using System;
using System.Collections.Generic;
using System.Text;

namespace BillingSoftware.ClassModels
{
    public class Product:BaseClass
    {
        public double Rate { get; set; }
        public Discount Discount { get; set; }
        public Category Category { get; set; }
    }
}
