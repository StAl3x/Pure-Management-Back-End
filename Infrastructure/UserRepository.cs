using Application.Interfaces;
using Domain;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context) 
    { 
        _context = context ?? throw new AggregateException(nameof(context));
    }

    public List<User> GetAll()
    {
        return _context.UserTable.ToList();
    }

    public User GetById(int id)
    {
        return _context.UserTable.Find(id) ?? throw new KeyNotFoundException();
    }
    public User Create(User user)
    {
        string salt = BCrypt.Net.BCrypt.GenerateSalt();
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, salt);
        _context.UserTable.Add(user);
        _context.SaveChanges();
        return user;
    }

    public User Update(User user)
    {
        _context.UserTable.Update(user);
        _context.SaveChanges();
        return user;
    }

    public User Delete(int id)
    {
        User userToDelete = _context.UserTable.Find(id) ?? throw new KeyNotFoundException();
        _context.UserTable.Remove(userToDelete);
        _context.SaveChanges();
        return userToDelete;
    }

    public bool VerifyUserPassword(string userName, string password)
    {
        Console.WriteLine(userName);
        User user = _context.UserTable.Where(u => u.Name.Equals(userName.ToString())).FirstOrDefault() ?? throw new KeyNotFoundException();
        return BCrypt.Net.BCrypt.Verify(password, user.Password);
    }
}
