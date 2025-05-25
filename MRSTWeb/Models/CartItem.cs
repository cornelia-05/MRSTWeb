using MRSTWeb.Domain.Entities.Product;

namespace MRSTWeb.Models
{
    public class CartItem
    {
        public Service Product { get; set; }
        public int Quantity { get; set; }
    }
}
