using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRSTWeb.BusinessLogic.Interfaces;
using MRSTWeb.Domain.Entities.Contact;
using MRSTWeb.Data.Context;
using MRSTWeb.Domain.Models;

namespace MRSTWeb.BusinessLogic
{
     public class ContactBL : IContactBL
     {
          private readonly DBContext _context;

          public ContactBL()
          {
               _context = new DBContext();
          }

          public void AddContactMessage(ContactMessageViewModel model)
          {
               var entity = new ContactMessage
               {
                    Name = model.Name,
                    Email = model.Email,
                    Subject = model.Subject,
                    Message = model.Message,
                    SubmittedAt = DateTime.Now
               };
               _context.ContactMessages.Add(entity);
               _context.SaveChanges();
          }

          public List<ContactMessageViewModel> GetAllContactMessages()
          {
               return _context.ContactMessages.Select(c => new ContactMessageViewModel
               {
                    Name = c.Name,
                    Email = c.Email,
                    Subject = c.Subject,
                    Message = c.Message,
                    SubmittedAt = c.SubmittedAt
               }).ToList();
          }
          public void SaveMessage(ContactMessageViewModel model)
          {
               var entity = new ContactMessage
               {
                    Name = model.Name,
                    Email = model.Email,
                    Subject = model.Subject,
                    Message = model.Message
               };

               _context.ContactMessages.Add(entity);
               _context.SaveChanges();
          }

          public IEnumerable<ContactMessageViewModel> GetAllMessages()
          {
               return _context.ContactMessages
                   .Select(x => new ContactMessageViewModel
                   {
                        Name = x.Name,
                        Email = x.Email,
                        Subject = x.Subject,
                        Message = x.Message,
                        SubmittedAt = DateTime.Now 
                   }).ToList();
          }
     }
}
