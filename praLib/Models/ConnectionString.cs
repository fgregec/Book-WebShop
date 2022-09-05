using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praLib.Models
{
    public static class ConnectionString
    {
        public static string CS = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
    }

}
