using Application.DTOs;
using Domain;


namespace Application.Interfaces
{
    public interface ICompanyService
    {
        public List<Company> GetAll();
        public Company Create(PostCompanyDTO dto);
        public Company GetById(int id);
        public Company Update(PutCompanyDTO dto);
        public Company Delete(int id);
        public List<Warehouse> GetWarehouses();
        public List<Product> GetProducts();
        public List<User> GetUsers();
    }
}
