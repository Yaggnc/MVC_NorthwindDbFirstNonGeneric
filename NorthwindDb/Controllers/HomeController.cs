using Microsoft.AspNetCore.Mvc;
using NorthwindDb.Models;
using System.Diagnostics;

namespace NorthwindDb.Controllers
{
    public class HomeController : Controller
    {                
        private readonly northwndContext _northwndContext;

        public HomeController(northwndContext northwndContext)
        {
            _northwndContext = northwndContext;
        }
       
        public IActionResult Index()
        {
            return View(_northwndContext.Products.ToList());
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}