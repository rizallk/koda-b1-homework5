using Homework5.Api.DTOs;
using Homework5.Api.Models;

namespace Homework5.Api.Repositories;

public interface IMenuRepository
{
  IEnumerable<MenuResponse> GetAll();
  MenuResponse? GetById(int id);
  void Add(Menu menu);
  void Update(Menu menu);
  void Delete(int id);
}