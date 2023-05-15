using NorthwindDb.Models;

namespace NorthwindDb.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category FindCategoryById(int categoryId);
        string CreateCategory(Category category);
        string UpdateCategory(Category category);
        string DeleteCategory(int categoryId);


    }
}
