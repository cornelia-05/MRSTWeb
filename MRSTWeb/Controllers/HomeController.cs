using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Windows.Forms;
using BusinessLogic;
using MRSTWeb.BusinessLogic;
using MRSTWeb.BusinessLogic.Core;
using MRSTWeb.BusinessLogic.Interfaces;
using MRSTWeb.Data.Context;
using MRSTWeb.Domain.Entities.Contact;
using MRSTWeb.Domain.Entities.Product;
using MRSTWeb.Domain.Entities.User;
using MRSTWeb.Domain.Entities.User.Global;
using MRSTWeb.Domain.Enums;
using MRSTWeb.Domain.Models;
using MRSTWeb.Models;
using MRSTWeb.Models.ViewModels;


namespace MRSTWeb.Controllers
{
     public class BaseController : Controller
     {
          protected override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               ViewBag.Layout = (Session["IsAdmin"] != null && (bool)Session["IsAdmin"])
                   ? "~/Views/Shared/_AdminLayout.cshtml"
                   : "~/Views/Shared/_Layout.cshtml";
               base.OnActionExecuting(filterContext);
          }
     }
     public class HomeController : BaseController
     {
          private readonly IProduct _product;
          private readonly IAdminApi _dashboard;
          private readonly IContactBL _contactBL;
          private readonly IUserApi _userApi;
          public HomeController()
          {
               var _bl = new MRSTWeb.BusinessLogic.Interfaces.BusinessLogic();
            _dashboard = _bl.GetAdminApi();
               _product = _bl.GetProductApi();
               _contactBL = _bl.GetContactApi();
               _userApi = _bl.GetUserApi();
          }
          public ActionResult AdminDashboard()
          {
               if (Session["IsAdmin"] == null || !(bool)Session["IsAdmin"])
               {
                    return RedirectToAction("AccessDenied", "Home");
               }
               var model = new DashboardViewModel
               {
                    LoginStats = _userApi.GetLoginStats().ToList(),
                    Services = _dashboard.GetAllProducts().ToList()
               };

               return View(model);
          }
          public ActionResult Index() => View();
          public ActionResult About() => View();
          public ActionResult Faq() => View();
          public ActionResult AddProduct() => View();
          [HttpPost]
          public ActionResult AddProduct(Service product, HttpPostedFileBase imageFile)
          {
               if (imageFile != null && imageFile.ContentLength > 0)
               {
                    string fileName = Path.GetFileName(imageFile.FileName);
                    string folderPath = Server.MapPath("~/Content/Images/");
                    Directory.CreateDirectory(folderPath); // Safe even if exists

                    string path = Path.Combine(folderPath, fileName);
                    imageFile.SaveAs(path);

                    product.ImagePath = "/Content/Images/" + fileName;
               }

               _product.Add(product);
               return RedirectToAction("AdminDashboard");
          }
          public ActionResult Products()
          {
               var products = _dashboard.GetAllProducts(); // or wherever you get products
               if (products == null)
                    products = new List<Service>(); // avoid nulls

               return View(products);
          }
          public ActionResult Contact() => View();
          public ActionResult Product_detail() => View();
          public ActionResult EditProduct(int id)
          {
               var product = _product.GetById(id);
               if (product == null) return HttpNotFound();
               return View(product);
          }
          [HttpPost]
          public ActionResult EditProduct(Service product, HttpPostedFileBase imageFile)
          {
               if (imageFile != null && imageFile.ContentLength > 0)
               {
                    string fileName = Path.GetFileName(imageFile.FileName);
                    string folderPath = Server.MapPath("~/Content/Images/");
                    Directory.CreateDirectory(folderPath);

                    string path = Path.Combine(folderPath, fileName);
                    imageFile.SaveAs(path);

                    product.ImagePath = "/Content/Images/" + fileName;
               }

               _product.Update(product); 
               return RedirectToAction("Index");
          }
          public ActionResult DeleteProduct(int id)
          {
               _product.Delete(id);
               return RedirectToAction("Index");
          }
          public ActionResult AdminMessages()
          {
               var messages = _contactBL.GetAllMessages(); // Clean delegation to business logic
               return View(messages);
          }
          [HttpPost]
          [ValidateAntiForgeryToken]
          [HttpGet]
          public ActionResult Contacts()
          {
               return View();
          }

          [HttpPost]
          public ActionResult SubmitContact(ContactMessageViewModel model)
          {
               if (!ModelState.IsValid)
                    return View("Contact", model);

               model.SubmittedAt = DateTime.Now;
               _contactBL.SaveMessage(model);
               TempData["SuccessMessage"] = "Thank you for your message!";
               return RedirectToAction("Contact");
          }
     }
}