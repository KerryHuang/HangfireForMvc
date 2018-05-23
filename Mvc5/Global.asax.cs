using Hangfire;
using Hangfire.SQLite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Mvc5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private BackgroundJobServer _backgroundJobServer;

        private static readonly string _sqliteDbPath = HostingEnvironment.MapPath("~/App_Data/Hangfire.sqlite");

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // MSSQL
            // GlobalConfiguration.Configuration.UseSqlServerStorage(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            // SQLLite
            GlobalConfiguration.Configuration
                //記得連線字串結尾要補上「;」
                //不然會被視為 config 檔連線設定名稱
                .UseSQLiteStorage($"Data Source={_sqliteDbPath};");

            //var options = new BackgroundJobServerOptions
            //{
            //    SchedulePollingInterval = TimeSpan.FromMinutes(1)
            //};

            _backgroundJobServer = new BackgroundJobServer();
        }

        protected void Application_End()
        {
            _backgroundJobServer.Dispose();
        }
    }
}
