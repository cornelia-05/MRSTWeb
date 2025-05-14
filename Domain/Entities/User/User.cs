using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities.User
{
     public class User
     {
          public int Id { get; set; }  
          public string Email { get; set; }
          public string Password { get; set; }
          public LevelAcces Role { get; set; }
          public string SessionKey { get; set; }
     }
}
