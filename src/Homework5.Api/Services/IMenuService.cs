using Homework5.Api.DTOs;

namespace Homework5.Api.Services;

public interface IMenuService
{
  IEnumerable<MenuResponse> GetAllMenus();
  void CreateMenu(CreateMenuRequest request);
  MenuResponse? GetMenuById(int id);
  bool UpdateMenu(int id, UpdateMenuRequest request);
  bool DeleteMenu(int id);
}