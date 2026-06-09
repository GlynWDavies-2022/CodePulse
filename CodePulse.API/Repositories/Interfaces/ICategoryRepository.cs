using CodePulse.API.Models.Domain;

namespace CodePulse.API.Repositories.Interfaces;

public interface ICategoryRepository
{
    public Task<Category> CreateCategoryAsync(Category category);
    public Task<IEnumerable<Category>> GetAllCategoriesAsync();
    public Task<Category?> GetCategoryByIdAsync(Guid id);
    public Task<Category?> UpdateCategoryAsync(Guid id, Category category);
    public Task<Category?> DeleteCategoryAsync(Guid id);
}
