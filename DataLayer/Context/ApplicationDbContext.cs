using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.User;

namespace DataLayer.Context
{
     public class ApplicationDbContext : DbContext
     {
          public ApplicationDbContext() : base("name=MRSTWebDB") 
          {
          }

          public DbSet<User> Users { get; set; }
     }
}
