using MRSTWeb.Domain.Entities.Product;
using System.Collections.Generic;

namespace MRSTWeb.BusinessLogic.Interfaces
{
    public interface IProduct
    {
        List<Service> GetAll();
        Service GetById(int id);
        void Add(Service product);           // ✅ This is what's missing
        void Update(Service product);
        void Delete(int id);
    }
}
