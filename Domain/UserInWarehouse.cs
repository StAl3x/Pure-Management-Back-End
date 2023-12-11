using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

public class UserInWarehouse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int WarehouseId { get; set; }
    public int AccessLevel { get; set; }
    public virtual User User { get; set; }
    public virtual Warehouse Warehouse { get; set; }
}
