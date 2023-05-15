using Microsoft.AspNetCore.Mvc;
using NorthwindDb.Repository;

namespace NorthwindDb.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View(_productRepository.GetAllProducts());
        }

        public IActionResult Delete(int id)
        {

            string result = _productRepository.DeleteProduct(id);

            TempData["Result"] = result;

            return RedirectToAction("Index", "Product");
        }
    }
}
