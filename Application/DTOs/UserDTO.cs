using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs;

public class PostUserDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int CompanyId { get; set; }
    public bool IsAdmin { get; set; }
}

public class PutUserDTO
{
    public string ? Name  {get; set;}
    public string ? Email { get; set; }
    public string ? Password { get; set; }
    public int ? CompanyId { get; set;}
    public bool IsAdmin { get; set; }
}
