using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs;

public class PostUserInWarehouseDTO
{
    public int UserId { get; set; }
    public int WarehouseId { get; set; }
    public int AccessLevel { get; set; }
}

public class PutUserInWarehouseDTO
{
    public int ? UserId  { get; set; }
    public int ? WarehouseId { get; set; }
    public int ? AccessLevel { get; set; }
}

