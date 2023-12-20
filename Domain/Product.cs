namespace Domain;

public class Product
{
    //testing only 
    public Product()
    {
    }

    public Product(int Id, string Name, double PricePerUnit, string Unit, int CompanyId) 
    {
        this.Id = Id;
        this.Name = Name;
        this.PricePerUnit = PricePerUnit;
        this.Unit = Unit;
        this.CompanyId = CompanyId;
    }

    public Product(int Id, string Name, double PricePerUnit, string Unit, int CompanyId, int Quantity)
    {
        this.Id = Id;
        this.Name = Name;
        this.PricePerUnit = PricePerUnit;
        this.Unit = Unit;
        this.CompanyId = CompanyId;
        this.Quantity = Quantity;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public double PricePerUnit { get; set; }
    public string Unit { get; set; }

    public virtual int Quantity { get; set; }

    public int CompanyId { get; set; }
    public virtual Company Company { get; set; }

    public virtual ICollection<ProductInWarehouse> Products { get; set;}




}