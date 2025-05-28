using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Optimization;
using MRSTWeb.App_Start;
using MRSTWeb.Data.Context;

namespace MRSTWeb.Web
{
     public class Global : System.Web.HttpApplication
     {
          protected void Application_Start()
          {
               AreaRegistration.RegisterAllAreas();

               UnityConfig.RegisterComponents();  

               RouteConfig.RegisterRoutes(RouteTable.Routes);
               BundleConfig.RegisterBundles(BundleTable.Bundles);
               FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

               
               var context = new DBContext();
               ApplicationDbInitializer.Initialize(context);
          }

     }
}