using NorthwindDb.Models;
using NorthwindDb.Repository;

namespace NorthwindDb.Service
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly northwndContext _northwndContext;

        public CategoryRepository(northwndContext northwndContext)
        {
            _northwndContext = northwndContext;
        }

        public string CreateCategory(Category category)
        {
            try
            {
                _northwndContext.Categories.Add(category);
                _northwndContext.SaveChanges();
                return "Kategori Eklendi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        public string DeleteCategory(int categoryId)
        {
            try
            {
                var deleted = FindCategoryById(categoryId);
                _northwndContext.Categories.Remove(deleted);
                _northwndContext.SaveChanges();
                return "Kategori Silindi";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public Category FindCategoryById(int categoryId)
        {
            return _northwndContext.Categories.Find(categoryId);
        }

        public List<Category> GetAllCategories()
        {
            return _northwndContext.Categories.ToList();
        }

        public string UpdateCategory(Category category)
        {
            var updatedId = FindCategoryById(category.CategoryId);
            if (updatedId != null)
            {
                _northwndContext.Entry(updatedId).CurrentValues.SetValues(category);
                _northwndContext.SaveChanges();
                return "Category Güncellendi";
            }
            else
            {
                return "Category Bulunamadı";
            }
        }
    }
}
