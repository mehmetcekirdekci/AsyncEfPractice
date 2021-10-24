using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetById(int id);
        Task<IList<Product>> GetAll();
        Task Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
