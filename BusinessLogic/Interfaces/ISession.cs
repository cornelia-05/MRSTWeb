using Domain.Entities.Res;
using Domain.Entities.User;
using Domain.Entities.User.Global;
using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
   public  interface ISession
    {
        ActionStatus UserLogin(ULoginData data);
        LevelStatus CheckLevel(string key);
        
    }
}
