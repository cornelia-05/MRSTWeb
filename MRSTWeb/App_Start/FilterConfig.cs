﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSTWeb.App_Start
{
     public class FilterConfig
     {
          public static void RegisterGlobalFilters(GlobalFilterCollection filters)
          {
               filters.Add(new HandleErrorAttribute());
               // Add other filters here
          }
     }
}