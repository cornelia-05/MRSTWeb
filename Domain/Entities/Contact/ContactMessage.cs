using System;
using System.ComponentModel.DataAnnotations;

namespace MRSTWeb.Domain.Entities.Contact
{
    public class ContactMessage
    {
        [Key] // ✅ This attribute tells EF that Id is the primary key
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
}
