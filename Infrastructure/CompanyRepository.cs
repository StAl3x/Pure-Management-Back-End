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
        _context.CompanyTable.Add(company);
        _context.SaveChanges();
        return company;
    }

    public Company Delete(int id)
    {
        Company companyToDelete = _context.CompanyTable.Find(id) ?? throw new KeyNotFoundException();
        _context.CompanyTable.Remove(companyToDelete);
        _context.SaveChanges();
        return companyToDelete;
    }

    public List<Company> GetAll()
    {
        return _context.CompanyTable.ToList();
    }

    public Company GetById(int id)
    {
        return _context.CompanyTable.Find(id) ?? throw new KeyNotFoundException();
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
    //this will return the original company, to compare it with the new, call getById with the same id 
    public Company Update(Company company)
    {
        _context.CompanyTable.Update(company);
        _context.SaveChanges();
        return company;
    }
}
