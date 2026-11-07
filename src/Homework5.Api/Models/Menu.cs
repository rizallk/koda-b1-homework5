namespace Homework5.Api.Models;

public class Menu
{
  public int Id { get; set; }
  public int CategoryId { get; set; }
  public string Name { get; set; }
  public decimal Price { get; set; }
  public int Stock { get; set; }
  public string? Description { get; set; }
  public DateTime CreatedAt { get; set; }

  public Menu(int id, int categoryId, string name, decimal price, int stock, string description, DateTime createdAt)
  {
    Id = id;
    CategoryId = categoryId;
    Name = name;
    Price = price;
    Stock = stock;
    Description = description;
    CreatedAt = createdAt;
  }
}