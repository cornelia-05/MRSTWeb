using Domain.Entities.User.Global;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
   public  interface ISession
    {
        ActionStatus UserLogin(ULoginData loginData);
        LevelStatus CheckLevel(string key);
     }
}
