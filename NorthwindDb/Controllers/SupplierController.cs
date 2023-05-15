using Microsoft.AspNetCore.Mvc;
using NorthwindDb.Repository;

namespace NorthwindDb.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public IActionResult Index()
        {
            return View(_supplierRepository.GetAllSuppliers());
        }
    }
}
