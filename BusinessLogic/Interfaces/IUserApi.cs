using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRSTWeb.BusinessLogic.Models;
using MRSTWeb.Domain.Entities.Product;
using MRSTWeb.Domain.Models;

namespace MRSTWeb.BusinessLogic.Interfaces
{
     public interface IUserApi
     {
          UserLoginResult SignIn(LoginViewModel model);
          bool SignUp(RegisterViewModel model);
          void Logout();
          ProductDetail GetProdUser(int id);
          List<LoginStatViewModel> GetLoginStats();
     }
}
