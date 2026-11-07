using Homework5.Api.DTOs;
using Homework5.Api.Models;

namespace Homework5.Api.Repositories;

public interface ICategoryRepository
{
  IEnumerable<CategoryResponse> GetAll();
  CategoryResponse? GetById(int id);
  void Add(Category category);
  void Update(Category category);
  void Delete(int id);
}