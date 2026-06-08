using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        var categories = await _applicationDbContext.Categories.ToListAsync();

        return categories;
    }

    public async Task<Category?> GetCategoryByIdAsync(Guid id)
    {
        var category = await _applicationDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        
        return category;
    }

    public async Task<Category?> UpdateCategoryAsync(Guid id, Category category)
    {
        var categoryToUpdate = _applicationDbContext.Categories.FirstOrDefault(c => c.Id == id);

        if (categoryToUpdate == null)
        {
            return null;
        }

        _applicationDbContext.Entry(categoryToUpdate).CurrentValues.SetValues(category);

        await _applicationDbContext.SaveChangesAsync();

        return category;
    }
}
