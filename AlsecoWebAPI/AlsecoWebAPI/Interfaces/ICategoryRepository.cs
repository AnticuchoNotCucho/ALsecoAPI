using AlsecoWebAPI.Models;

namespace AlsecoWebAPI.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategories();
    Task<Category> GetCategory(int id);
    Task<bool> AddCategory(Category category);
    Task<bool> UpdateCategory(Category category);
    Task<bool> DeleteCategory(int id);
    
}