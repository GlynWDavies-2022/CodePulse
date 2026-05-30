using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Repositories.Interfaces;

namespace CodePulse.API.Repositories.Implementations;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public CategoryRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Category> CreateCategoryAsync(Category category)
    {
        await _applicationDbContext.Categories.AddAsync(category);

        await _applicationDbContext.SaveChangesAsync();

        return category;
    }
}
