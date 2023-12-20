using Application.DTOs;
using Domain;


namespace Application.Interfaces
{
    public interface ICompanyService
    {
        public List<Company> GetAll();
        public Company Create(PostCompanyDTO dto);
        public Company GetById(int id);
        public Company Update(int id, PutCompanyDTO dto);
        public Company Delete(int id);
        public List<Warehouse> GetWarehouses(int companyId);
        public List<Product> GetProducts(int companyId);
        public List<User> GetUsers(int companyId);
    }
}
