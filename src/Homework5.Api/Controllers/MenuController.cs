using Homework5.Api.DTOs;
using Homework5.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Homework5.Api.Controllers;

[ApiController]
[Route("api/v1/menus")]
public class MenuController(IMenuService menuService) : ControllerBase
{
  [HttpGet]
  public IActionResult GetAll()
  {
    var menus = menuService.GetAllMenus();
    return Ok(new { Message = "Success", Data = menus });
  }

  [HttpPost]
  public IActionResult Create([FromBody] CreateMenuRequest request)
  {
    menuService.CreateMenu(request);
    return StatusCode(201, new { Message = "Menu KFC berhasil ditambahkan" });
  }

  [HttpGet("{id}")]
  public IActionResult GetById(int id)
  {
    var menu = menuService.GetMenuById(id);
    if (menu == null)
      return NotFound(new { Message = $"Menu KFC dengan ID {id} tidak ditemukan" });

    return Ok(new { Message = "Success", Data = menu });
  }

  [HttpPut("{id}")]
  public IActionResult Update(int id, [FromBody] UpdateMenuRequest request)
  {
    try
    {
      var isUpdated = menuService.UpdateMenu(id, request);
      if (!isUpdated)
        return NotFound(new { Message = $"Menu KFC dengan ID {id} tidak ditemukan" });

      return Ok(new { Message = "Menu KFC berhasil diperbarui" });
    }
    catch (SqlException ex)
    {
      if (ex.Number == 547)
      {
        return BadRequest(new { Message = $"Kategori dengan ID {request.CategoryId} tidak valid." });
      }
      throw;
    }
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var isDeleted = menuService.DeleteMenu(id);
    if (!isDeleted)
      return NotFound(new { Message = $"Menu KFC dengan ID {id} tidak ditemukan" });

    return Ok(new { Message = "Menu KFC berhasil dihapus" });
  }
}