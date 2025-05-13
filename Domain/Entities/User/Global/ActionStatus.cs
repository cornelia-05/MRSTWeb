using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User.Global
{
   public  class ActionStatus
    {
        public bool Status { get; set; }
        public string StatusMessage { get; set; }
        public string SessionKey { get; set; }
    }
}
