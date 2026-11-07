using Homework5.Api.DTOs;

namespace Homework5.Api.Services;

public interface ICategoryService
{
  IEnumerable<CategoryResponse> GetAllCategories();
  CategoryResponse? GetCategoryById(int id);
  void CreateCategory(CreateCategoryRequest request);
  bool UpdateCategory(int id, UpdateCategoryRequest request);
  bool DeleteCategory(int id);
}