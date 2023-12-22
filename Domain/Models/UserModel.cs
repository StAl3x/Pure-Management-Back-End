using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;

public class UserModel
{
    public int userId { get; set; }
    public PostUserDTO postUserDTO { get; set; }
    public PutUserDTO putUserDTO { get; set; }
}
