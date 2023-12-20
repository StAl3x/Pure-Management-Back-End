using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface IUserRepository
{
    public List<User> GetAll();
    public User Create(User user);
    public User GetById(int id);
    public User Update(User user);
    public User Delete(int id);
    public bool VerifyUserPassword(string UserName, string password);
}