using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.User;
using BusinessLogic.Models;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity;



namespace BusinessLogic
{
     public class UserContext : DbContext
     {
          public DbSet<UDbTable> UDbTables { get; set; }  
          public DbSet<User> Users { get; set; } 
          public DbSet<Service> Services { get; set; }  

          public UserContext() : base("name=MRSTWebDB") { }

          protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
               base.OnModelCreating(modelBuilder);

          }
     }
}
