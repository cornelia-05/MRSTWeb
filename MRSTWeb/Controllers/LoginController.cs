using BusinessLogic.Interfaces;
using Domain.Entities.User;
using Domain.Entities.User.Global;
using MRSTWeb.Models;
using System;
using System.Web.Mvc;

namespace MRSTWeb.Controllers
{
     public class LoginController : Controller
    {
        private readonly ISession _session;
        public LoginController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetsessionBL();
        }
        // GET: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                ULoginData data = new ULoginData
                {
                    Credentials = login.Credentials,
                    Password = login.Password,
                    LoginIp = Request.UserHostAddress,
                    LoginDataTime = (int)DateTime.Now.Ticks
                };
                var UserLogin = _session.UserLogin(data);
                if (UserLogin.Status)
                {
                    LevelStatus status = _session.CheckLevel(UserLogin.SessionKey);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Nume de utilizator sau parola incorecta.Incearca inca o data", UserLogin.StatusMessage);
                    return View();
                }
            }
            return View();
        }
    }
}