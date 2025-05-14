using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using Domain.Entities.User.Global;
using Domain.Entities.User;
using System.Web.Helpers;
using System.Windows.Forms;
using BCrypt.Net;
using System.Data.Entity;
using DataLayer.Context;
using Domain.Enums;

namespace BusinessLogic
{
     public class SessionLogic : ISession
     {
          private readonly ApplicationDbContext _context;

          public SessionLogic(ApplicationDbContext context)
          {
               _context = context;
          }

          public ActionStatus UserLogin(ULoginData loginData)
          {
               var user = _context.Users.FirstOrDefault(u => u.Email == loginData.Credentials);

               if (user != null && BCrypt.Net.BCrypt.Verify(loginData.Password, user.Password))
               {
                    return new ActionStatus
                    {
                         Status = true,
                         SessionKey = Guid.NewGuid().ToString(),
                         StatusMessage = "Login successful"
                    };
               }

               return new ActionStatus
               {
                    Status = false,
                    StatusMessage = "Invalid credentials"
               };
          }



          public LevelStatus CheckLevel(string sessionKey)
          {
               var user = _context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);


               if (user != null)
               {
                    // Directly use the enum value
                    return new LevelStatus { Role = user.Role };
               }
               else
               {
                    // If the user is null or role is not recognized, default to Guest
                    return new LevelStatus { Role = LevelAcces.Guest };
               }

          }

     }
}
