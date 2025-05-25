﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRSTWeb.Domain.Entities.User;
using MRSTWeb.Domain.Enums;
using MRSTWeb.Domain.Entities.Product;

namespace MRSTWeb.Data.Context
{
     public class DBContext : System.Data.Entity.DbContext
     {
          public DBContext() : base("name=MRSTWebDB") 
          {
          }

          public DbSet<ULoginData> Users { get; set; }
          public DbSet<Service> Services { get; set; }
    }

     public class ApplicationDbInitializer
     {
        public DateTime LastLogin { get; set; }

        public static void Initialize(DBContext dbContext)
          {
               // Check if the "Admin" user exists
               var adminUser = dbContext.Users.FirstOrDefault(u => u.Role == LevelAcces.Admin);

               if (adminUser == null)
               {
                    // Create a new admin user if not found
                    var newAdminUser = new ULoginData
                    {
                         Credential = "admin@mrstweb",
                         Password = "123456",  
                         Role = LevelAcces.Admin,
                         SessionKey = Guid.NewGuid().ToString(),
                         LastLogin = DateTime.Now
                    };

                    dbContext.Users.Add(newAdminUser);
                    dbContext.SaveChanges();
               }
          }
     }

}
