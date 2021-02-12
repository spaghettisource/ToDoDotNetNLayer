using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Core;
using ToDoDotNet.Data;
using AutoMapper;
using ToDoDotNet.App_Start;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using System.Reflection;
using SimpleInjector.Integration.Web.Mvc;
using System.Data.Entity;
using Data;
using System;
using Microsoft.AspNet.Identity;

namespace ToDoDotNet
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            if (exception != null)
            {
                NLog.LogManager.GetCurrentClassLogger().Error(exception, exception.Message);
            }
        }
        protected void Application_Start()
        {            

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);           
            
        }


    }
}
