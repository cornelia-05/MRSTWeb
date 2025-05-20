using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRSTWeb.BusinessLogic.Interfaces;
using BusinessLogic;
using MRSTWeb.Data.Context;
using MRSTWeb.Domain.Entities.User;
using MRSTWeb.Models;
using MRSTWeb.Domain.Enums;
using System.Web.Helpers;
using BusinessLogic.Models;
using MRSTWeb.Domain.Entities.User.Global;
using System.Windows.Forms;


namespace MRSTWeb.Controllers
{
     public class HomeController : Controller
     {
          public ActionResult Index()
          {
               if (Session["IsAdmin"] != null && (bool)Session["IsAdmin"])
               {
                    ViewBag.Layout = "~/Views/Shared/_AdminLayout.cshtml";
               }
               else
               {
                    ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
               }

               return View();
          }


          public ActionResult About()
          {
               return View();
          }
          public ActionResult Contact()
          {
               return View();
          }
          public ActionResult Faq()
          {
               return View();
          }
          public ActionResult Product_detail()
          {
               return View();
          }
          public ActionResult Products()
          {
               return View();
          }
     }
}