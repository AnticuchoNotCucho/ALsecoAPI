using AlsecoWebAPI.Interfaces;
using AlsecoWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AlsecoWebAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApiDbContext _context;
    
    public ProductRepository(ApiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetProductById(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> AddProduct(Product product)
    {
        var productExists = await _context.Products.AnyAsync(x => x.Id == product.Id);
        if (productExists)
        {
            return false;
        }
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        var productToUpdate = await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
        var categoryToUpdate = await _context.Categories.FirstOrDefaultAsync(x => x.Id == product.Category);
        if (productToUpdate == null)
        {
            return false;
        }
        productToUpdate.Name = product.Name;
        productToUpdate.Precio = product.Precio;
        productToUpdate.Stock = product.Stock;
        productToUpdate.Category = product.Category;
        productToUpdate.Image = product.Image;
        productToUpdate.CategoryNavigation = categoryToUpdate;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteProduct(int id)
    {
        var productToDelete = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (productToDelete == null)
        {
            return false;
        }
        _context.Products.Remove(productToDelete);
        await _context.SaveChangesAsync();
        return true;
    }
}