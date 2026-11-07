using Microsoft.Data.SqlClient;
using Homework5.Api.DTOs;
using Homework5.Api.Models;

namespace Homework5.Api.Repositories;

public class MenuRepository(IConfiguration configuration) : IMenuRepository
{
  private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection")!;

  public IEnumerable<MenuResponse> GetAll()
  {
    var menus = new List<MenuResponse>();
    using var connection = new SqlConnection(_connectionString);

    var query = """
      SELECT m.Id, m.CategoryId, c.Name AS CategoryName, 
                   m.Name, m.Price, m.Stock, m.Description 
            FROM Menus m
            INNER JOIN Categories c ON m.CategoryId = c.Id
    """;

    using var command = new SqlCommand(query, connection);
    connection.Open();
    using var reader = command.ExecuteReader();

    while (reader.Read())
    {
      menus.Add(new MenuResponse(
          reader.GetInt32(0),
          reader.GetInt32(1),
          reader.GetString(2),
          reader.GetString(3),
          reader.GetDecimal(4),
          reader.GetInt32(5),
          reader.IsDBNull(6) ? null : reader.GetString(6)
      ));
    }
    return menus;
  }

  public void Add(Menu menu)
  {
    using var connection = new SqlConnection(_connectionString);
    var query = """
            INSERT INTO Menus (CategoryId, Name, Price, Stock, Description) 
            VALUES (@CategoryId, @Name, @Price, @Stock, @Description)
    """;

    using var command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@CategoryId", menu.CategoryId);
    command.Parameters.AddWithValue("@Name", menu.Name);
    command.Parameters.AddWithValue("@Price", menu.Price);
    command.Parameters.AddWithValue("@Stock", menu.Stock);
    command.Parameters.AddWithValue("@Description", (object?)menu.Description ?? DBNull.Value);

    connection.Open();
    command.ExecuteNonQuery();
  }

  public MenuResponse? GetById(int id)
  {
    using var connection = new SqlConnection(_connectionString);

    var query = """
            SELECT m.Id, m.CategoryId, c.Name AS CategoryName, 
                   m.Name, m.Price, m.Stock, m.Description 
            FROM Menus m
            INNER JOIN Categories c ON m.CategoryId = c.Id
            WHERE m.Id = @Id
            """;

    using var command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@Id", id);

    connection.Open();
    using var reader = command.ExecuteReader();

    if (reader.Read())
    {
      return new MenuResponse(
          reader.GetInt32(0),
          reader.GetInt32(1),
          reader.GetString(2),
          reader.GetString(3),
          reader.GetDecimal(4),
          reader.GetInt32(5),
          reader.IsDBNull(6) ? null : reader.GetString(6)
      );
    }

    return null;
  }

  public void Update(Menu menu)
  {
    using var connection = new SqlConnection(_connectionString);
    var query = """
            UPDATE Menus 
            SET CategoryId = @CategoryId, 
                Name = @Name, 
                Price = @Price, 
                Stock = @Stock, 
                Description = @Description,
                UpdatedAt = GETDATE()
            WHERE Id = @Id
            """;

    using var command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@Id", menu.Id);
    command.Parameters.AddWithValue("@CategoryId", menu.CategoryId);
    command.Parameters.AddWithValue("@Name", menu.Name);
    command.Parameters.AddWithValue("@Price", menu.Price);
    command.Parameters.AddWithValue("@Stock", menu.Stock);
    command.Parameters.AddWithValue("@Description", (object?)menu.Description ?? DBNull.Value);

    connection.Open();
    command.ExecuteNonQuery();
  }

  public void Delete(int id)
  {
    using var connection = new SqlConnection(_connectionString);
    var query = "DELETE FROM Menus WHERE Id = @Id";

    using var command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@Id", id);

    connection.Open();
    command.ExecuteNonQuery();
  }
}