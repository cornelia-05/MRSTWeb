using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Mvc;


public class BundleConfig
{
     public static void RegisterBundles(BundleCollection bundles)
     {

          bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.min.css",  
                    "~/Content/bootstrap-icons.css", 
                    "~/Content/slick.css",          
                    "~/Content/site.css",
                    "~/Content/tooplate-little-fashion.css"  
          ));

          bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Scripts/jquery.min.js"
          ));

          bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                     "~/Scripts/bootstrap.bundle.min.js"
           ));


          bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                      "~/Scripts/Headroom.js",
                      "~/Scripts/jQuery.headroom.js",
                      "~/Scripts/slick.min.js",
                      "~/Scripts/custom.js"
          ));

          BundleTable.EnableOptimizations = true;

     }
}
