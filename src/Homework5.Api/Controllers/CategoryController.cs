using Homework5.Api.DTOs;
using Homework5.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework5.Api.Controllers;

[ApiController]
[Route("api/v1/categories")]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
  [HttpGet]
  public IActionResult GetAll()
  {
    var categories = categoryService.GetAllCategories();
    return Ok(new { Message = "Success", Data = categories });
  }

  [HttpGet("{id}")]
  public IActionResult GetById(int id)
  {
    var category = categoryService.GetCategoryById(id);
    if (category == null)
      return NotFound(new { Message = $"Kategori dengan ID {id} tidak ditemukan" });

    return Ok(new { Message = "Success", Data = category });
  }

  [HttpPost]
  public IActionResult Create([FromBody] CreateCategoryRequest request)
  {
    categoryService.CreateCategory(request);
    return StatusCode(201, new { Message = "Kategori berhasil ditambahkan" });
  }

  [HttpPut("{id}")]
  public IActionResult Update(int id, [FromBody] UpdateCategoryRequest request)
  {
    var isUpdated = categoryService.UpdateCategory(id, request);
    if (!isUpdated)
      return NotFound(new { Message = $"Kategori dengan ID {id} tidak ditemukan" });

    return Ok(new { Message = "Kategori berhasil diperbarui" });
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var isDeleted = categoryService.DeleteCategory(id);
    if (!isDeleted)
      return NotFound(new { Message = $"Kategori dengan ID {id} tidak ditemukan" });

    return Ok(new { Message = "Kategori berhasil dihapus" });
  }
}