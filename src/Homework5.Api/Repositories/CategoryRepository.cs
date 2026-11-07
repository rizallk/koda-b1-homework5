using Microsoft.Data.SqlClient;
using Homework5.Api.DTOs;

namespace Homework5.Api.Repositories;

public class CategoryRepository(IConfiguration configuration) : ICategoryRepository
{
  private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection")!;

  public IEnumerable<CategoryResponse> GetAll()
  {
    var categories = new List<CategoryResponse>();
    using var connection = new SqlConnection(_connectionString);
    var query = """
      SELECT Id, Name, Description FROM Categories
    """;

    using var command = new SqlCommand(query, connection);
    connection.Open();
    using var reader = command.ExecuteReader();

    while (reader.Read())
    {
      categories.Add(new CategoryResponse(
          reader.GetInt32(0),
          reader.GetString(1),
          reader.IsDBNull(2) ? null : reader.GetString(2)
      ));
    }

    return categories;
  }

  public CategoryResponse? GetById(int id)
  {
    using var connection = new SqlConnection(_connectionString);
    var query = """
      SELECT Id, Name, Description FROM Categories WHERE Id = @Id
    """;

    using var command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@Id", id);

    connection.Open();
    using var reader = command.ExecuteReader();

    if (reader.Read())
    {
      return new CategoryResponse(
          reader.GetInt32(0),
          reader.GetString(1),
          reader.IsDBNull(2) ? null : reader.GetString(2)
      );
    }

    return null;
  }

  public void Add(Category category)
  {
    using var connection = new SqlConnection(_connectionString);
    var query = """
      INSERT INTO Categories (Name, Description) VALUES (@Name, @Description)
    """;

    using var command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@Name", category.Name);
    command.Parameters.AddWithValue("@Description", (object?)category.Description ?? DBNull.Value);

    connection.Open();
    command.ExecuteNonQuery();
  }

  public void Update(Category category)
  {
    using var connection = new SqlConnection(_connectionString);
    var query = """
      UPDATE Categories SET Name = @Name, Description = @Description, UpdatedAt = GETDATE() WHERE Id = @Id
    """;

    using var command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@Id", category.Id);
    command.Parameters.AddWithValue("@Name", category.Name);
    command.Parameters.AddWithValue("@Description", (object?)category.Description ?? DBNull.Value);

    connection.Open();
    command.ExecuteNonQuery();
  }

  public void Delete(int id)
  {
    using var connection = new SqlConnection(_connectionString);
    var query = """
      DELETE FROM Categories WHERE Id = @Id
    """;

    using var command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@Id", id);

    connection.Open();
    command.ExecuteNonQuery();
  }
}