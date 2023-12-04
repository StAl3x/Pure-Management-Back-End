using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

public class PostProductModel
{
    public PostProductInWarehouseDTO PinDTO { get; set; }
    public PostProductDTO ProductDTO { get; set; }
}

public class PutProductModel
{
    public PutProductInWarehouseDTO PinDTO { get; set; }
    public PutProductDTO ProductDTO { get; set; }
}
