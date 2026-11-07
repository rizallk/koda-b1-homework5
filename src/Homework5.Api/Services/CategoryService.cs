using Homework5.Api.DTOs;
using Homework5.Api.Models;
using Homework5.Api.Repositories;

namespace Homework5.Api.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
  public IEnumerable<CategoryResponse> GetAllCategories()
  {
    return categoryRepository.GetAll();
  }

  public CategoryResponse? GetCategoryById(int id)
  {
    return categoryRepository.GetById(id);
  }

  public void CreateCategory(CreateCategoryRequest request)
  {
    var category = new Category
    {
      Name = request.Name,
      Description = request.Description
    };

    categoryRepository.Add(category);
  }

  public bool UpdateCategory(int id, UpdateCategoryRequest request)
  {
    var existingCategory = categoryRepository.GetById(id);
    if (existingCategory == null) return false;

    var category = new Category
    {
      Id = id,
      Name = request.Name,
      Description = request.Description
    };

    categoryRepository.Update(category);
    return true;
  }

  public bool DeleteCategory(int id)
  {
    var existingCategory = categoryRepository.GetById(id);
    if (existingCategory == null) return false;

    categoryRepository.Delete(id);
    return true;
  }
}