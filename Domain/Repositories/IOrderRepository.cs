using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetById(int id);
        Task<IList<Order>> GetAll();
        Task Add(Order order);
        void Update(Order order);
        void Delete(int id);
    }
}
