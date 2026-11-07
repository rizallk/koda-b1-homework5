using Homework5.Api.DTOs;
using Homework5.Api.Models;
using Homework5.Api.Repositories;

namespace Homework5.Api.Services;

public class MenuService(IMenuRepository menuRepository) : IMenuService
{
  public IEnumerable<MenuResponse> GetAllMenus()
  {
    return menuRepository.GetAll();
  }

  public void CreateMenu(CreateMenuRequest request)
  {
    var menu = new Menu
    {
      CategoryId = request.CategoryId,
      Name = request.Name,
      Price = request.Price,
      Stock = request.Stock,
      Description = request.Description
    };

    menuRepository.Add(menu);
  }

  public MenuResponse? GetMenuById(int id)
  {
    return menuRepository.GetById(id);
  }

  public bool UpdateMenu(int id, UpdateMenuRequest request)
  {
    var existingMenu = menuRepository.GetById(id);
    if (existingMenu == null) return false;

    var menu = new Menu
    {
      Id = id,
      CategoryId = request.CategoryId,
      Name = request.Name,
      Price = request.Price,
      Stock = request.Stock,
      Description = request.Description
    };

    menuRepository.Update(menu);
    return true;
  }

  public bool DeleteMenu(int id)
  {
    var existingMenu = menuRepository.GetById(id);
    if (existingMenu == null) return false;

    menuRepository.Delete(id);
    return true;
  }
}