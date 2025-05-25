using MRSTWeb.Domain.Entities.Product;

namespace BusinessLogic
{
    internal interface IProductBL
    {
        ProductDetail GetDetailProduct(int id);
        void Update(Service product);
    }
}