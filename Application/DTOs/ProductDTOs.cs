
namespace Application.DTOs;

public class PostProductDTO
{
    public double Price { get; set; }
    public string Name { get; set; }
}

public class PartialUpdateProductDTO
{
    public double? Price { get; set; }
    public string? Name { get; set; }
    public int Id { get; set; }
}