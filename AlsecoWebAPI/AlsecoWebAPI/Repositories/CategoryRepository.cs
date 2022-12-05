using AlsecoWebAPI.Interfaces;
using AlsecoWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AlsecoWebAPI.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApiDbContext _context;
    
    public CategoryRepository(ApiDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetCategory(int id)
    {
        return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> AddCategory(Category category)
    {
        var categoryExists = await _context.Categories.AnyAsync(x => x.Name == category.Name);
        if (categoryExists)
        {
            return false;
        }
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateCategory(Category category)
    {
        var categoryToUpdate = await _context.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
        if (categoryToUpdate == null)
        {
            return false;
        }
        categoryToUpdate.Name = category.Name;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteCategory(int id)
    {
        var categoryToDelete = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (categoryToDelete == null)
        {
            return false;
        }
        _context.Categories.Remove(categoryToDelete);
        await _context.SaveChangesAsync();
        return true;
    }
}