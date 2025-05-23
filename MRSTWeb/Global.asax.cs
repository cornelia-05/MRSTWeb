﻿using System;
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

namespace MRSTWeb
{
     public class Global : HttpApplication
     {
          void Application_Start(object sender, EventArgs e)
          {
               AreaRegistration.RegisterAllAreas();
               FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
               RouteConfig.RegisterRoutes(RouteTable.Routes);
               BundleConfig.RegisterBundles(BundleTable.Bundles);
          }

          protected void Application_Start()
          {
               AreaRegistration.RegisterAllAreas();
               UnityConfig.RegisterComponents(); // ← Add this line
               RouteConfig.RegisterRoutes(RouteTable.Routes);
               BundleConfig.RegisterBundles(BundleTable.Bundles);
            var context = new DBContext();
            ApplicationDbInitializer.Initialize(context);
        }


     }
}