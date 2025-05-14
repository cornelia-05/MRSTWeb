using System;
using System.Linq;
using System.Web.Mvc;
using BusinessLogic.Interfaces;
using BusinessLogic;
using DataLayer.Context;
using Domain.Entities.User;
using MRSTWeb.Models;
using Domain.Enums;

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

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult SignIn(LoginViewModel model)
          {
               if (ModelState.IsValid)
               {
                    var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
                    if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                    {
                         Session["UserKey"] = Guid.NewGuid().ToString();
                         Session["Email"] = user.Email;

                         if (user.Role == LevelAcces.Admin)
                         {
                              Session["IsAdmin"] = true;
                         }
                         else
                         {
                              Session["IsAdmin"] = false;
                         }

                         return RedirectToAction("Index", "Home");

                    }

                    ModelState.AddModelError("", "Invalid email or password.");
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
                    if (_context.Users.Any(u => u.Email == model.Email))
                    {
                         ModelState.AddModelError("Email", "Email is already registered.");
                         return View(model);
                    }

                    var user = new User
                    {
                         Email = model.Email,
                         Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                         Role = LevelAcces.User
                    };

                    _context.Users.Add(user);
                    _context.SaveChanges();

                    return RedirectToAction("SignIn");
               }

               return View(model);
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Logout()
          {
               // Clear the session
               Session.Clear();
               Session.Abandon();
               return RedirectToAction("Index", "Home");
          }

     }
}
