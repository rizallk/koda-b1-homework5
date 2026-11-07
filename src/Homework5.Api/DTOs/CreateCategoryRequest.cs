using System.ComponentModel.DataAnnotations;

namespace Homework5.Api.DTOs;

public record CreateCategoryRequest(
  [Required(ErrorMessage = "Nama kategori wajib diisi")]
  [StringLength(100, ErrorMessage = "Maksimal 100 karakter")]
  string Name,

  [StringLength(255)]
  string? Description
);