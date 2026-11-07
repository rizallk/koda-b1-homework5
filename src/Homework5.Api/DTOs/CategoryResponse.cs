namespace Homework5.Api.DTOs;

public record CategoryResponse(
  int Id,
  string Name,
  string? Description
);