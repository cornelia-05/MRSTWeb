using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MRSTWeb.Domain.Models;
using MRSTWeb.Domain.Entities.Product;

namespace MRSTWeb.Models.ViewModels
{
     public class DashboardViewModel
     {
          public List<LoginStatViewModel> LoginStats { get; set; }
          public List<Service> Services { get; set; }
     }
}