using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetById(int id);
        Task<IList<Category>> GetAll();
        Task Add(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
