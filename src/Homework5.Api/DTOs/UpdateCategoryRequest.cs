using System.ComponentModel.DataAnnotations;

namespace Homework5.Api.DTOs;

public record UpdateCategoryRequest(
    [Required]
    [StringLength(100)]
    string Name,

    [StringLength(255)]
    string? Description
);