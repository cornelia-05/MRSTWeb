using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
     public class Service
     {
          public int Id { get; set; }  // Primary key, unique ID
          public string ServiceName { get; set; }
          public decimal Price { get; set; }
     }
}
