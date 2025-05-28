using MRSTWeb.Domain.Entities.Product;
using System.Collections.Generic;

namespace MRSTWeb.BusinessLogic.Interfaces
{
     public interface IProduct
     {
          List<Service> GetAll();
          Service GetById(int id);
          ProductDetail GetDetailProduct(int id); 
          void Add(Service product);
          void Update(Service product);
          void Delete(int id);
     }
}
