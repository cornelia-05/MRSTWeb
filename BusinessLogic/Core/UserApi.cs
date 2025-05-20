using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRSTWeb.Domain.Entities.User;
using MRSTWeb.Domain.Entities.User.Global;
using MRSTWeb.Domain.Entities.Product;


namespace MRSTWeb.BusinessLogic.Core
{
   public class UserApi
    {
        internal ActionStatus UserLogData(ULoginData data)
        {
            return new ActionStatus();
        }
        internal LevelStatus CheckLevelLogic(string keySession)
        {
            return new LevelStatus();
        }
        internal ProductDetail GetProdUser(int id)
        {
            return new ProductDetail();
        }
    }
}
