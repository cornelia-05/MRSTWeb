using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRSTWeb.Domain.Models;

namespace MRSTWeb.BusinessLogic.Interfaces
{
     public interface IContactBL
     {
          void AddContactMessage(ContactMessageViewModel model);
          List<ContactMessageViewModel> GetAllContactMessages();
          void SaveMessage(ContactMessageViewModel model);
          IEnumerable<ContactMessageViewModel> GetAllMessages();
     }
}
