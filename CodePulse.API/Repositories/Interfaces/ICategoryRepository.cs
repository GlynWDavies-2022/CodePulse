using CodePulse.API.Models.Domain;

namespace CodePulse.API.Repositories.Interfaces;

public interface ICategoryRepository
{
    public Task<Category> CreateCategoryAsync(Category category);
}
