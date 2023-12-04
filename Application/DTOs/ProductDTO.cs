
namespace Application.DTOs;

public class PostProductDTO
{
    public double PricePerUnit { get; set; }
    public string Name { get; set; }
    public string Unit {  get; set; }
    public int CompanyId { get; set; }
}

public class PutProductDTO
{
    public double? PricePerUnit { get; set; }
    public string? Name { get; set; }
    public string? Unit { get; set; }
    
}

public class PostProductWarehouseDTO 
{
    public string Name { get; set; }
    public double PricePerUnit { get; set; }
    public string Unit { get; set; }
    public string CompanyId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public class PutProductWarehouseDTO
{
    public string? Name { get; set; }
    public double? PricePerUnit { get; set; }
    public string? Unit { get; set; }
    public string CompanyId { get; set; }
    public int ProductId { get; set; }
    public int ? Quantity { get; set; }
}