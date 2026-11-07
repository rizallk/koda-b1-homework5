namespace Homework5.Api.DTOs;

public record MenuResponse(
  int Id,
  int CategoryId,
  string CategoryName,
  string Name,
  decimal Price,
  int Stock,
  string? Description
);