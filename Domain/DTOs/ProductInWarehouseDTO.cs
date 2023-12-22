using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs;

public class PostProductInWarehouseDTO
{
    public int ProductId { get; set; }
    public int WarehouseId { get; set; }
    public int Quantity { get; set; }
}

public class PutProductInWarehouseDTO
{
    public int Quantity { get; set; }

}
