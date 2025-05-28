using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRSTWeb.Domain.Entities.User;

namespace MRSTWeb.BusinessLogic.Models
{
     public class UserLoginResult
     {
          public bool Success { get; set; }
          public string ErrorMessage { get; set; }
          public ULoginData User { get; set; }
     }

}
