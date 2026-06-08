using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpPost]
    public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryRequestDTO request)
    {
        var category = new Category
        {
            Name = request.Name,
            UrlHandle = request.UrlHandle
        };

        var createdCategory = await _categoryRepository.CreateCategoryAsync(category);

        var categoryDTO = new CategoryDTO
        {
            Id = createdCategory.Id,
            Name = createdCategory.Name,
            UrlHandle = createdCategory.UrlHandle
        };

        return Ok(categoryDTO);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategories()
    {
        var categories = await _categoryRepository.GetAllCategoriesAsync();

        var response = new List<CategoryDTO>();

        foreach (var category in categories)
        {
            var categoryDTO = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            response.Add(categoryDTO);
        }

        return Ok(categories);
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<CategoryDTO?>> GetCategoryById([FromRoute] Guid id)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);

        if (category == null)
        {
            return NotFound();
        }

        var categoryDTO = new CategoryDTO
        {
            Id = category.Id,
            Name = category.Name,
            UrlHandle = category.UrlHandle
        };

        return Ok(categoryDTO);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] UpdateCategoryRequestDTO request)
    {
        var category = new Category
        {
            Id = id,
            Name = request.Name,
            UrlHandle = request.UrlHandle
        };

        var updatedCategory = await _categoryRepository.UpdateCategoryAsync(id, category);

        if (updatedCategory == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}