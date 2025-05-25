using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using MRSTWeb.Domain.Entities;
using MRSTWeb.Domain.Entities.User;
using System.Data.Entity;
using MRSTWeb.Data.Context;
using MRSTWeb.Domain.Entities.Product;

namespace BusinessLogic
{
     public class UserContext : DBContext
     {
          public new  DbSet<ULoginData> Users { get; set; }
          public new DbSet<Service> Services { get; set; }

          protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
               base.OnModelCreating(modelBuilder);

          }
     }
}
