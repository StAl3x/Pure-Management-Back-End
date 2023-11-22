namespace Domain;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double PricePerUnit { get; set; }
    public string Unit { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; }



}