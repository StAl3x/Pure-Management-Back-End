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
        public Company Update(Company company);
        public Company Delete(int id);
        public List<Warehouse> GetWarehouses();
        public List<Product> GetProducts();
        public List<User>  GetUsers();

    }
}
