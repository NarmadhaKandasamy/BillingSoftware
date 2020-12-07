using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using WinAppBillingSoftware.Models;
using BillingSoftware.ClassModels;

namespace WinAppBillingSoftware.Models
{
    public class CommonClass
    {
        //public static ResourceManager resourceManager = new ResourceManager("WinAppBillingSoftware.Resources." + System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName, Assembly.GetExecutingAssembly());
        public static AdminSettings AdminSettings;
        public static ResourceManager resourceManager;
    }
}
