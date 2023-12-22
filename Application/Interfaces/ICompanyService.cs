using Domain;
using Domain.DTOs;
using Domain.Models;


namespace Application.Interfaces
{
    public interface ICompanyService
    {
        public List<Company> GetAll();
        public Company Create(PostCompanyDTO dto);
        public Company GetById(int id);
        public Company Update(int id, CompanyModel companyModel);
        public Company Delete(int id, int userId);
        public List<Warehouse> GetWarehouses(int companyId, int userId);
        public List<Product> GetProducts(int companyId, int userId);
        public List<User> GetUsers(int companyId, int userId);
    }
}
