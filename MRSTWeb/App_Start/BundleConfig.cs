using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

public class BundleConfig
{
     // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
     public static void RegisterBundles(BundleCollection bundles)
     {
          // CSS Bundles (includes global styles and footer styles)
          bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.min.css",  // Bootstrap CSS
                    "~/Content/bootstrap-icons.css", // Bootstrap Icons
                    "~/Content/slick.css",           // Slick carousel styles
                    "~/Content/site.css",
                    "~/Content/tooplate-little-fashion.css"  // Your custom styles
          ));

          // JavaScript Bundles (includes global scripts and footer scripts)
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

          // Enable Optimizations (set to false for debugging)
          BundleTable.EnableOptimizations = true;
     }
}
