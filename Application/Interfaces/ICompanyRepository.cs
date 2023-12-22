using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICompanyRepository
    {
        public List<Company> GetAll();
        public Company Create(Company company);
        public Company GetById(int id);
        public Company Update(Company company, int userId);
        public Company Delete(int id, int userId);
        public List<Warehouse> GetWarehouses(int companyId, int userId);
        public List<Product> GetProducts(int companyId, int userId);
        public List<User>  GetUsers(int companyId, int userId);

    }
}
