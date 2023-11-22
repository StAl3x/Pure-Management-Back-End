using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs;

public class PostCompanyDTO
{
    public string Name { get; set; }
    public string Address { get; set; }
}

public class PutCompanyDTO
{
    public string ? Name { get; set; }
    public string ? Address { get; set; }
}
