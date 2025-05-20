using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;
using System.Runtime.Remoting.Contexts;
using MRSTWeb.Domain.Entities;
using MRSTWeb.Domain.Entities.User;
using System.Data.Entity;
using MRSTWeb.Data.Context;

namespace BusinessLogic
{
     public class UserContext : DBContext
     {
          public DbSet<ULoginData> Users { get; set; }
          public DbSet<Service> Services { get; set; }

          protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
               base.OnModelCreating(modelBuilder);

          }
     }
}
