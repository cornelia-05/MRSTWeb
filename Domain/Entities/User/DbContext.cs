using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.User;

namespace Domain.Data
{
     public class MRSTWeb: DbContext
     {
          public DbSet<ULoginData> UserLoginData { get; set; }

          public MRSTWeb() : base("name=MRSTWebDB") // Use the name of your connection string
          {
          }

          protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
               base.OnModelCreating(modelBuilder);
               // Additional configuration if needed
          }
     }
}
