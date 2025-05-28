using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MRSTWeb.BusinessLogic.Interfaces;
using MRSTWeb.BusinessLogic;
using MRSTWeb.Data.Context;

namespace MRSTWeb.BusinessLogic.Models
{
     public static class SessionFactory
     {
          public static ISession CreateSession()
          {
               var context = new DBContext(); 
               return new SessionBL(context);
          }
     }

}