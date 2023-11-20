
namespace Application.DTOs;

public class PostProductDTO
{
    public double PricePerUnit { get; set; }
    public string Name { get; set; }
    public string Unit {  get; set; }
}

public class PutProductDTO
{
    public double? PricePerUnit { get; set; }
    public string? Name { get; set; }
    public string? Unit { get; set; }
    
}