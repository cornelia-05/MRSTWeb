﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRSTWeb.Domain.Entities.Product;

namespace MRSTWeb.BusinessLogic.Interfaces
{
   public interface  IProduct
    {
        ProductDetail GetDetailProduct(int id);
    }
}
