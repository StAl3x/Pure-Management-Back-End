using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface IUserRepository
{
    public List<User> GetAll(int userId);
    public User Create(User user, int userId);
    public User GetById(int id);
    public User Update(User user, int userId);
    public User Delete(int id, int userId);
    public bool VerifyUserPassword(string UserName, string password);
}