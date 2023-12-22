using Domain.DTOs;

namespace Domain.Models;

public class ProductModel
{
    public int userId { get; set; }
    public PostProductDTO postProductDTO { get; set; }
    public PutProductDTO  putProductDTO { get; set; }
    public PostProductDTOWithQuantity postProductDTOWithQuantity { get; set; }
    public PutProductDTOWithQuantity putProductDTOWithQuantity { get; set;}
}
