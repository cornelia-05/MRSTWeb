using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRSTWeb.Domain.Entities.Product;
using MRSTWeb.Domain.Models;

namespace MRSTWeb.BusinessLogic.Interfaces
{
     public interface IAdminApi
     {
          IEnumerable<LoginStatViewModel> GetLoginStats();
          IEnumerable<Service> GetAllProducts();
     }
}
