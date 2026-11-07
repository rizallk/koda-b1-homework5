using System.ComponentModel.DataAnnotations;

namespace Homework5.Api.DTOs;

public record UpdateMenuRequest(
  [Required]
  int CategoryId,

  [Required, StringLength(100)]
  string Name,

  [Range(0, double.MaxValue)]
  decimal Price,

  [Range(0, int.MaxValue)]
  int Stock,

  string? Description
);