using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ProductInWarehouse
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
       
        public virtual Product Product { get; set; }
        public virtual Warehouse Warehouse { get; set; }

    }
}
