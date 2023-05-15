using Microsoft.AspNetCore.Mvc;
using NorthwindDb.Models;
using NorthwindDb.Repository;

namespace NorthwindDb.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View(_categoryRepository.GetAllCategories());
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category model)
        {
            _categoryRepository.CreateCategory(model);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateCategory(int id)
        {
            return View(_categoryRepository.FindCategoryById(id));
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category model)
        {
            Category updatedId = _categoryRepository.FindCategoryById(model.CategoryId);
            updatedId.CategoryName = model.CategoryName;
            updatedId.Description = model.Description;
            _categoryRepository.UpdateCategory(updatedId);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id) 
        {
            _categoryRepository.DeleteCategory(id);
            return RedirectToAction("Index");
        }


    }
}
