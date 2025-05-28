using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRSTWeb.Domain.Entities.Product;
using MRSTWeb.Domain.Models;
using MRSTWeb.Data.Context;
using MRSTWeb.BusinessLogic.Interfaces;

namespace MRSTWeb.BusinessLogic.Core
{
    public class AdminApi
    {
    }
     public class DashboardService : IAdminApi
     {
          private readonly DBContext _db;

          public DashboardService(DBContext db)
          {
               _db = db;
          }

          public IEnumerable<LoginStatViewModel> GetLoginStats()
          {
               return _db.Users
                   .Where(u => u.LoginCount > 0)
                   .GroupBy(u => u.Email ?? u.Credential)
                   .Select(g => new LoginStatViewModel
                   {
                        Email = g.Key,
                        Count = g.Sum(u => u.LoginCount)
                   });
          }

          public IEnumerable<Service> GetAllProducts()
          {
               return _db.Services.ToList();
          }
     }
}
