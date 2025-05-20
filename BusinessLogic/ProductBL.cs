using MRSTWeb.BusinessLogic.Core;
using MRSTWeb.BusinessLogic.Interfaces;
using MRSTWeb.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    class ProductBL: UserApi,IProduct
    {
        public ProductDetail GetDetailProduct(int id)
        {
            return GetProdUser(id);
        }
    }
}
