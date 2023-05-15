using NorthwindDb.Models;
using NorthwindDb.Repository;

namespace NorthwindDb.Service
{
    public class ProductRepository : IProductRepository
    {
        private readonly northwndContext _northwndContext;

        public ProductRepository(northwndContext northwndContext)
        {
            _northwndContext = northwndContext;
        }

        public string CreateProduct(Product product)
        {
            try
            {
                _northwndContext.Products.Add(product);
                _northwndContext.SaveChanges();
                return "Ürün Eklendi";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string DeleteProduct(int productId)
        {
            try
            {
                var deletedId = FindProductById(productId);
                _northwndContext.Products.Remove(deletedId);
                _northwndContext.SaveChanges();
                return "Ürün silindi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public Product FindProductById(int productId)
        {
            return _northwndContext.Products.Find(productId);
        }

        public List<Product> GetAllProducts()
        {
            return _northwndContext.Products.ToList();
        }

        public string UpdateProduct(Product product)
        {
            var updatedId = FindProductById(product.ProductId);
            if (updatedId != null)
            {
                _northwndContext.Entry(updatedId).CurrentValues.SetValues(product);
                _northwndContext.SaveChanges();
                return "Ürün Güncellendi!";
            }
            else
            {
                return "Böyle bir ürün bulunamadı!";
            }
        }
    }
}
