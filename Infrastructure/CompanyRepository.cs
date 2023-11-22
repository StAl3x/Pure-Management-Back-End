using Application;
using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class CompanyRepository : ICompanyRepository
{
    private readonly AppDbContext _context;

    public CompanyRepository(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));

    }
    public Company Create(Company company)
    {
        throw new NotImplementedException();
    }

    public Company Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Company> GetAll()
    {
        throw new NotImplementedException();
    }

    public Company GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetProducts()
    {
        throw new NotImplementedException();
    }

    public List<User> GetUsers()
    {
        throw new NotImplementedException();
    }

    public List<Warehouse> GetWarehouses()
    {
        throw new NotImplementedException();
    }

    public Company Update(Company company)
    {
        throw new NotImplementedException();
    }
}
