using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MRSTWeb.BusinessLogic.Interfaces;
using MRSTWeb.BusinessLogic;

namespace MRSTWeb.Models
{
     public static class SessionFactory
     {
          public static ISession GetsessionBL()
          {
               return new SessionBL();
          }
     }

}