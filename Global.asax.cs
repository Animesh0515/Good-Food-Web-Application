using GoodFoodCompany.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace GoodFoodCompany
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            OracleConnectionModel.Host = ConfigurationManager.AppSettings["Host"];
            OracleConnectionModel.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
            OracleConnectionModel.ServiceName = ConfigurationManager.AppSettings["ServiceName"];
            OracleConnectionModel.UserID = ConfigurationManager.AppSettings["UserID"];
            OracleConnectionModel.Password = ConfigurationManager.AppSettings["Password"];

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}