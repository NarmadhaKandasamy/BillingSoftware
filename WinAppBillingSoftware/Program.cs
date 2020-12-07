using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinAppBillingSoftware.Admin;
using BillingSoftware.ClassModels;
using WinAppBillingSoftware.Models;
using Newtonsoft.Json;
using System.IO;
using System.Resources;
using System.Reflection;

namespace WinAppBillingSoftware
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            #region "Global setting configuration"                      
            // Load Admin Setting details
            StreamReader strReader = new StreamReader(Application.StartupPath + "\\Data\\Adminsettings.json");            
            CommonClass.AdminSettings = JsonConvert.DeserializeObject<AdminSettings>(strReader.ReadToEnd());
            CommonClass.resourceManager = new ResourceManager("WinAppBillingSoftware.Resources." + CommonClass.AdminSettings.Language, Assembly.GetExecutingAssembly());
            
            #endregion



            // to load main page
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
