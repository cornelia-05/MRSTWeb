using System;
using System.Linq;
using System.Web.Mvc;
using BusinessLogic.Interfaces;
using BusinessLogic;
using DataLayer.Context;
using Domain.Entities.User;
using MRSTWeb.Models;

namespace MRSTWeb.Controllers
{
     public class AccountController : Controller
     {
          private readonly ISession _session;
          private readonly ApplicationDbContext _context;

          public AccountController()
          {
               _session = SessionFactory.GetsessionBL();
               _context = new ApplicationDbContext();
          }

          // SignIn Action (GET)
          public ActionResult SignIn()
          {
               return View();
          }

          // SignIn Action (POST)
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult SignIn(User login)
          {
               if (ModelState.IsValid)
               {
                    var data = new ULoginData
                    {
                         Credential = login.Email,
                         Password = login.Password,
                         LoginIp = Request.UserHostAddress,
                         LoginDataTime = (int)DateTime.Now.Ticks
                    };

                    var response = _session.UserLogin(data);

                    if (response.Status)
                    {
                         Session["UserKey"] = response.SessionKey;
                         Session["Email"] = login.Email;
                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", response.StatusMessage);
                         return View();
                    }
               }

               return View();
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
                    if (_context.Users.Any(u => u.Email == model.Email))
                    {
                         ModelState.AddModelError("Email", "Email is already registered.");
                         return View(model);
                    }

                    var user = new User
                    {
                         Email = model.Email,
                         Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                         Role = "User"
                    };

                    _context.Users.Add(user);
                    _context.SaveChanges();

                    return RedirectToAction("SignIn");
               }

               return View(model);
          }
     }
}
