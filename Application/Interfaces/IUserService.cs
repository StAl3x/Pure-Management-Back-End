using Domain;
using Domain.DTOs;
using Domain.Models;
namespace Application.Interfaces;

public interface IUserService
{
    public List<User> GetAll(int userId);
    public User Create(UserModel model);
    public User GetById(int id);
    public User Update(int id, UserModel model);
    public User Delete(int id, int userId);

    public bool VerifyUserPassword(string UserName, string password);
}
