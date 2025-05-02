using ProductCatalogApp.Core.Interfaces;
using ProductCatalogApp.Core;
public interface ICategoryService
{
    Task<IEnumerable<Category>> GetCategories();
    Task<Category> GetCategory(int id);
    Task CreateCategory(Category category);
    Task UpdateCategory(Category category);
    Task DeleteCategory(int id);
}
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _categoryRepository.GetAllCategoriesAsync();
    }

    public async Task<Category> GetCategory(int id)
    {
        return await _categoryRepository.GetCategoryByIdAsync(id);
    }

    public async Task CreateCategory(Category category)
    {
        await _categoryRepository.CreateCategoryAsync(category);
    }

    public async Task UpdateCategory(Category category)
    {
        await _categoryRepository.UpdateCategoryAsync(category);
    }

    public async Task DeleteCategory(int id)
    {
        await _categoryRepository.DeleteCategoryAsync(id);
    }
}
