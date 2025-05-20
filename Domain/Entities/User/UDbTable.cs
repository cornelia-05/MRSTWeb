using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MRSTWeb.Domain.Entities.User
{
     public enum URole
     {
          Guest,
          User,
          Admin
     }

     public class UDbTable
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          [Required]
          [Display(Name = "Username")]
          [StringLength(12, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 12 characters.")]
          public string Username { get; set; }

          [Required]
          [Display(Name = "Password")]
          [StringLength(15, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters.")]
          public string Password { get; set; }

          [Required]
          [Display(Name = "Email Address")]
          [StringLength(30)]
          public string Email { get; set; }

          [DataType(DataType.Date)]
          public DateTime LastLogin { get; set; }

          [StringLength(30)]
          public string LastIp { get; set; }

          public URole Level { get; set; }
     }
}
