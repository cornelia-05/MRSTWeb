using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRSTWeb.BusinessLogic.Interfaces;
using MRSTWeb.Domain.Entities.User.Global;
using MRSTWeb.Domain.Entities.User;
using System.Web.Helpers;
using System.Windows.Forms;
using BCrypt.Net;
using System.Data.Entity;
using MRSTWeb.Domain.Enums;
using MRSTWeb.Data.Context;

namespace MRSTWeb.BusinessLogic
{
     public class SessionLogic : ISession
     {
          private readonly DBContext _context;

          public SessionLogic(DBContext context)
          {
               _context = context;
          }

          public ActionStatus UserLogin(ULoginData loginData)
          {
               var user = _context.Users.FirstOrDefault(u => u.Credential == loginData.Credential);

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
