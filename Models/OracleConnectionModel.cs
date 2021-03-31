using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodFoodCompany.Models
{
    public static class OracleConnectionModel
    {
        public static string Host { get; set; }
        public static int Port { get; set; }
        public static string ServiceName { get; set; }
        public static string Password { get; set; }
        public static string UserID { get; set; }
        public static string ConnectionString()
        {
            return "DATA SOURCE=" + Host +":"+Port+"/"+ServiceName+";Password="+Password+ ";PERSIST SECURITY INFO=True;USER ID="+UserID+ "";
        }
    }
   
}