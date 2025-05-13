using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogic.Interfaces;
using BusinessLogic;

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