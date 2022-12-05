using AlsecoWebAPI.Models;
using AlsecoWebAPI.Models.DTO;

namespace AlsecoWebAPI.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product> GetProductById(int id);
    Task<bool> AddProduct(Product product);
    Task<bool> UpdateProduct(Product product);
    Task<bool> DeleteProduct(int id);
    
}