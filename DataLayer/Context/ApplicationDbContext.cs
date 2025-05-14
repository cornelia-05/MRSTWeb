using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.User;
using Domain.Enums;

namespace DataLayer.Context
{
     public class ApplicationDbContext : DbContext
     {
          public ApplicationDbContext() : base("name=MRSTWebDB") 
          {
          }

          public DbSet<User> Users { get; set; }
     }

     public class ApplicationDbInitializer
     {
          public static void Initialize(ApplicationDbContext dbContext)
          {
               // Check if the "Admin" user exists
               var adminUser = dbContext.Users.FirstOrDefault(u => u.Role == LevelAcces.Admin);

               if (adminUser == null)
               {
                    // Create a new admin user if not found
                    var newAdminUser = new User
                    {
                         Email = "admin@mrstweb",
                         Password = "123456",  
                         Role = LevelAcces.Admin,
                         SessionKey = Guid.NewGuid().ToString()
                    };

                    dbContext.Users.Add(newAdminUser);
                    dbContext.SaveChanges();
               }
          }
     }

}
