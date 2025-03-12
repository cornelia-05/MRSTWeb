using BusinessLogic;
using BusinessLogic.Interfaces;
using MRSTWeb.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSTWeb.BusinessLogic
{
   public class BusinessLogic
    {
        public ISession GetsessionBL()
        {
            return new SessionBL();
        }
        public IProduct GetProductBL()
        {
            return new ProductBL();
        }
    }
}
