using NorthwindDb.Models;

namespace NorthwindDb.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product FindProductById(int productId);
        string CreateProduct(Product product);
        string UpdateProduct(Product product);
        string DeleteProduct(int productId);

    }
}
