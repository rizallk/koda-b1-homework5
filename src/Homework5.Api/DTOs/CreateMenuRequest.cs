using System.ComponentModel.DataAnnotations;

namespace Homework5.Api.DTOs;

public record CreateMenuRequest(
  [Required]
  int CategoryId,

  [Required, StringLength(100)]
  string Name,

  [Range(0, double.MaxValue, ErrorMessage = "Harga tidak boleh negatif")]
  decimal Price,

  [Range(0, int.MaxValue, ErrorMessage = "Stock tidak boleh negatif")]
  int Stock,

  string? Description
);