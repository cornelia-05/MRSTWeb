using System;
using System.Linq;
using System.Web.Mvc;
using MRSTWeb.BusinessLogic;
using MRSTWeb.BusinessLogic.Core;
using MRSTWeb.BusinessLogic.Interfaces;
using MRSTWeb.Data.Context;
using MRSTWeb.Domain.Entities.User;
using MRSTWeb.Domain.Enums;
using MRSTWeb.Domain.Models;
using MRSTWeb.BusinessLogic.Models;

namespace MRSTWeb.Controllers
{
     public class AccountController : Controller
     {
          private readonly ISession _session;
          private readonly IUserApi _userApi;

          public AccountController(IUserApi userApi, ISession session)
          {
               _session = session;
               _userApi = userApi;
          }

          // SignIn Action (GET)
          public ActionResult SignIn()
          {
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult SignIn(LoginViewModel model)
          {
               if (ModelState.IsValid)
               {
                    var result = _userApi.SignIn(model);

                    if (result.Success)
                    {
                         var user = result.User;

                         Session["UserKey"] = Guid.NewGuid().ToString();
                         Session["Email"] = user.Credential;
                         Session["IsAdmin"] = user.Role == LevelAcces.Admin;

                         return RedirectToAction("Index", "Home");
                    }

                    ModelState.AddModelError("", result.ErrorMessage);
               }

               return View(model);
          }

          // SignUp Action (GET)
          public ActionResult SignUp()
          {
               return View();
          }

          // SignUp Action (POST)
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult SignUp(RegisterViewModel model)
          {
               if (ModelState.IsValid)
               {
                    if (!_userApi.SignUp(model))
                    {
                         ModelState.AddModelError("Email", "Email is already registered.");
                         return View(model);
                    }

                    return RedirectToAction("SignIn");
               }

               return View(model);
          }


          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Logout()
          {
               Session.Clear();
               Session.Abandon();
               return RedirectToAction("Index", "Home");
          }

          }
           public class AdminController : Controller
          {
             public ActionResult Dashboard()
             {
                 return View();
             }
 
          }
}