using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PostWarehouseDTO
    {
        public string Address {  get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
    }

    public class PartualUpdateWarehouseDTO
    {
        public string? Address { get; set; }
        public string? EmailAddress { get; set; }
        public string? Name { get; set; }
        public int CompanyId { get; set; }
        public int Id { get; set; }
    }
}
