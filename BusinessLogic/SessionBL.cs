using MRSTWeb.BusinessLogic.Core;
using MRSTWeb.BusinessLogic.Interfaces;
using MRSTWeb.Domain.Entities.User;
using MRSTWeb.Domain.Entities.User.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSTWeb.BusinessLogic
{
    public class SessionBL : UserApi, ISession
     {
        public ActionStatus UserLogin(ULoginData data)
        {
            return UserLogData(data);
        }
        public LevelStatus CheckLevel(string key)
        {
            return CheckLevelLogic(key);
        }
    }
}
