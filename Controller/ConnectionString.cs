using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WindowsFormsApp1.Controller
{
    class ConnectionString
    {
        public static string Connstr
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ConnStr"].ConnectionString;
            }
        }
    }
}
