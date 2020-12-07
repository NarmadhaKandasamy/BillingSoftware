using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace WinAppBillingSoftware.Models
{
    public class CommonClass
    {
        //public static ResourceManager resourceManager = new ResourceManager("WinAppBillingSoftware.Resources." + System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName, Assembly.GetExecutingAssembly());
        public static ResourceManager resourceManager = new ResourceManager("WinAppBillingSoftware.Resources.en", Assembly.GetExecutingAssembly());
    }
}
