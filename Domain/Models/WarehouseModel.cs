using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;

public class WarehouseModel
{
    public int userId { get; set; }
    public PostWarehouseDTO postWarehouseDTO { get; set; }
    public PutWarehouseDTO putWarehouseDTO { get; set; }
}
