using System.ComponentModel.DataAnnotations;

namespace MRSTWeb.Domain.Entities.Product
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string ImagePath { get; set; }
    }
}
