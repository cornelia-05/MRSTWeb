using MRSTWeb.BusinessLogic;
using MRSTWeb.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessLogic
{
     public class LogicProvider
     {
          public ISession GetsessionBL() => new SessionBL();
          public IProduct GetProductBL() => new ProductBL();
     }
}
