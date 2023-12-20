using Application.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface IUserService
{
    public List<User> GetAll();
    public User Create(PostUserDTO dto);
    public User GetById(int id);
    public User Update(int id, PutUserDTO dto);
    public User Delete(int id);

    public bool VerifyUserPassword(string UserName, string password);
}
