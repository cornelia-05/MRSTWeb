using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DBModel
{
     public class UserContext : DbContext
     {
          public UserContext()
              : base("name=eUseControl") // connection string name defined in Web.config
          {
          }

          public virtual DbSet<UDbTable> Users { get; set; }
     }
}
