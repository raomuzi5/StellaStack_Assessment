using ProductCatalogApp.Core.Interfaces;
using ProductCatalogApp.Core;
using ProductCatalogApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products
                             .Include(p => p.CategoryProducts)
                             .ThenInclude(cp => cp.Category)
                             .ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int productId)
    {
        return await _context.Products
                             .Include(p => p.CategoryProducts)
                             .ThenInclude(cp => cp.Category)
                             .FirstOrDefaultAsync(p => p.Id == productId);
    }

    public async Task CreateAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int productId)
    {
        var product = await _context.Products.FindAsync(productId);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
