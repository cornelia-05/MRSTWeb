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
using MRSTWeb.Domain.Entities.Product;
using MRSTWeb.Domain.Entities.User.Global;
using System.Windows.Forms;
using System.Data.Entity;
using MRSTWeb.Models.ViewModels;

namespace MRSTWeb.Controllers
{
     public class HomeController : Controller
     {
        private object products;

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
        public ActionResult AdminDashboard()
        {
            using (var db = new DBContext())
            {
                var logins = db.Users
              .Where(u => u.LoginCount > 0) // Optional: filter out unused
              .GroupBy(u => u.Email ?? u.Credential)
                .Select(g => new LoginStatViewModel
                {
                    Email = g.Key,
                    Count = g.Sum(u => u.LoginCount)
                }).ToList();

                var products = db.Services.ToList();
                ViewBag.LoginStats = logins;

                return View(products);
            }
        }


        public ActionResult EditProduct(int id)
        {
            using (var db = new DBContext())
            {
                var product = db.Services.Find(id);
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult EditProduct(Service updatedProduct)
        {
            using (var db = new DBContext())
            {
                db.Entry(updatedProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AdminDashboard");
            }
        }
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Service product)
        {
            using (var db = new DBContext())
            {
                db.Services.Add(product);
                db.SaveChanges();
                return RedirectToAction("AdminDashboard");
            }
        }
        public ActionResult DeleteProduct(int id)
        {
            using (var db = new DBContext())
            {
                var product = db.Services.Find(id);
                if (product != null)
                {
                    db.Services.Remove(product);
                    db.SaveChanges();
                }
                return RedirectToAction("AdminDashboard");
            }
        }



    }
}