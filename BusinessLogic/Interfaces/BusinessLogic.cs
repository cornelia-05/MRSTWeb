using MRSTWeb.BusinessLogic;
using MRSTWeb.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MRSTWeb.Data.Context;
using MRSTWeb.BusinessLogic.Core;

namespace MRSTWeb.BusinessLogic.Interfaces
{
     public class BusinessLogic
    {
        public  IAdminApi GetAdminApi()
        {
            return new AdminApi(new DBContext());
        }

        public IProduct GetProductApi()
        {
            return new ProductBL();
        }

        public IUserApi GetUserApi()
        {
            return new UserApi(new DBContext());
        }

        public ISession GetSessionApi()
        {
            return new SessionLogic(new DBContext());
        }

        public IContactBL GetContactApi()
        {
            return new ContactBL();
        }
    }
   
}
