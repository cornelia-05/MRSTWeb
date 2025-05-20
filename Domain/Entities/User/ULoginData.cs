using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRSTWeb.Domain.Enums;

namespace MRSTWeb.Domain.Entities.User
{
     public class ULoginData
     {
          public int Id { get; set; }
          public string Credential { get; set; }
          public string Password { get; set; }
          public LevelAcces Role { get; set; }
          public string SessionKey { get; set; }
     }
}
