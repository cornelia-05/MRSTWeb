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
using System.IO;
using MRSTWeb.BusinessLogic;
using MRSTWeb.Domain.Entities.Contact;


namespace MRSTWeb.Controllers
{
     public class HomeController : Controller
     {
        private  IProduct _product;
        public HomeController()
        {
            _product = new ProductBL(); // Or use LogicProvider if needed
        }


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
            var products = _product.GetAll();
            return View(products);
          }
        public ActionResult AdminDashboard()
        {
            using (var db = new DBContext())
            {
                var logins = db.Users
                    .Where(u => u.LoginCount > 0)
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
        public ActionResult EditProduct(Service product, HttpPostedFileBase imageFile)
        {
            using (var db = new DBContext())
            {
                var existing = db.Services.Find(product.Id);
                if (existing == null)
                    return HttpNotFound();

                existing.Name = product.Name;
                existing.Description = product.Description;
                existing.Price = product.Price;

                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(imageFile.FileName);
                    string imagePath = Path.Combine(Server.MapPath("~/Content/images/"), fileName);
                    imageFile.SaveAs(imagePath);

                    existing.ImagePath = "/Content/images/" + fileName;
                }

                db.SaveChanges();
            }

            return RedirectToAction("AdminDashboard");
        }


        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Service product, HttpPostedFileBase imageFile)
        {
            if (imageFile != null && imageFile.ContentLength > 0)
            {
                string fileName = Path.GetFileName(imageFile.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                string folderPath = Server.MapPath("~/Content/images/");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                imageFile.SaveAs(path);

                product.ImagePath = "/Content/Images/" + fileName;
            }

            _product.Add(product); // Use BL method
            return RedirectToAction("AdminDashboard");
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
        public ActionResult AdminMessages()
        {
            if (TempData["ContactMessages"] != null)
            {
                ViewBag.ContactMessages = TempData["ContactMessages"];
            }
            else
            {
                // fallback if nothing in TempData
                ViewBag.ContactMessages = HomeController.ContactMessages ?? new List<ContactMessageViewModel>();
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactMessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DBContext())
                {
                    var message = new ContactMessage
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Subject = model.Subject,
                        Message = model.Message
                    };

                    db.ContactMessages.Add(message);
                    db.SaveChanges();

                    // Add to static in-memory list for UI
                    ContactMessages.Add(new ContactMessageViewModel
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Subject = model.Subject,
                        Message = model.Message,
                        SubmittedAt = DateTime.Now
                    });

                }

                ViewBag.Message = "Thank you! We’ll get back to you soon.";
                return RedirectToAction("Contact");
            }

            return View(model);
        }
        
      
        public static List<ContactMessageViewModel> ContactMessages = new List<ContactMessageViewModel>();

        [HttpPost]
        public ActionResult SubmitContact(string Name, string Email, string Subject, string Message)
        {
            ContactMessages.Add(new ContactMessageViewModel
            {
                Name = Name,
                Email = Email,
                Subject = Subject,
                Message = Message,
                SubmittedAt = DateTime.Now
            });

            TempData["SuccessMessage"] = "Thank you for your message!";
            return RedirectToAction("Contact");
        }



    }
}