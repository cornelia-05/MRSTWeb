using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Interfaces;
using BusinessLogic;
using DataLayer.Context;
using Domain.Entities.User;
using MRSTWeb.Models;
using Domain.Enums;
using System.Web.Helpers;
using BusinessLogic.Models;
using Domain.Entities.User.Global;
using System.Windows.Forms;


namespace MRSTWeb.Controllers
{
     public class HomeController : Controller
     {
          public ActionResult Index()
          {
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
<<<<<<< HEAD
=======
         
>>>>>>> c356d3cab15b8d080c37f6e36bbc2f5ac0aad200

     }
}