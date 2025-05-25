using BusinessLogic;
using MRSTWeb.BusinessLogic.Core;
using MRSTWeb.BusinessLogic.Interfaces;
using MRSTWeb.Data.Context;
using MRSTWeb.Domain.Entities.Product;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MRSTWeb.BusinessLogic
{
    public class ProductBL : UserApi, IProduct, IProductBL
    {
        private readonly DBContext _context;

        public ProductBL()
        {
            _context = new DBContext();
        }

        public ProductDetail GetDetailProduct(int id)
        {
            return GetProdUser(id);
        }

        public List<Service> GetAll()
        {
            return _context.Services.ToList();
        }

        public Service GetById(int id)
        {
            return _context.Services.Find(id);
        }

        public void Add(Service product)
        {
            _context.Services.Add(product);
            _context.SaveChanges();
        }

        public void Update(Service product)
        {
            var existing = _context.Services.Find(product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Description = product.Description;
                existing.Price = product.Price;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var product = _context.Services.Find(id);
            if (product != null)
            {
                _context.Services.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
