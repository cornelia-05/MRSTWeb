using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRSTWeb.BusinessLogic.Interfaces;
using MRSTWeb.BusinessLogic.Models;
using MRSTWeb.Data.Context;
using MRSTWeb.Domain.Entities.Product;
using MRSTWeb.Domain.Entities.User;
using MRSTWeb.Domain.Entities.User.Global;
using MRSTWeb.Domain.Enums;
using MRSTWeb.Domain.Models;


namespace MRSTWeb.BusinessLogic.Core
{

   public class UserApi: IUserApi
    {
          private readonly DBContext _context;

          public UserApi(DBContext context)
          {
               _context = context;
          }
          public UserLoginResult SignIn(LoginViewModel model)
          {
               var result = new UserLoginResult();

               var user = _context.Users.FirstOrDefault(u => u.Credential == model.Email);
               if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
               {
                    user.LastLogin = DateTime.Now;
                    user.LoginCount += 1;
                    if (string.IsNullOrEmpty(user.Email))
                    {
                         user.Email = user.Credential;
                    }

                    _context.SaveChanges();

                    result.Success = true;
                    result.User = user;
               }
               else
               {
                    result.Success = false;
                    result.ErrorMessage = "Invalid email or password.";
               }

               return result;
          }

          public bool SignUp(RegisterViewModel model)
          {
               if (_context.Users.Any(u => u.Credential == model.Email))
               {
                    return false;
               }

               var user = new ULoginData
               {
                    Credential = model.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                    Role = LevelAcces.User,
                    LastLogin = DateTime.Now
               };

               _context.Users.Add(user);
               _context.SaveChanges();
               return true;
          }

          public void Logout() {}

          internal ActionStatus UserLogData(ULoginData data)
          {
            return new ActionStatus();
          }
          internal LevelStatus CheckLevelLogic(string keySession)
          {
            return new LevelStatus();
          }
          public ProductDetail GetProdUser(int id)
          {
            return new ProductDetail();
          }
          public List<LoginStatViewModel> GetLoginStats()
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

                    return logins;
               }
          }
     }
}
