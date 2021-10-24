using Domain.Entities;
using Domain.Exceptions.OrderExceptions;
using Domain.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly NorthwindContext _northwindContext;
        private readonly DbSet<Order> _dbSet;

        public OrderRepository(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
            _dbSet = northwindContext.Set<Order>();

        }

        public async Task Add(Order order)
        {
            if (order == null)
            {
                throw new OrderDontAddException(OrderExceptionMessages.OrderDontAdd);
            }
            else
            {
                await _dbSet.AddAsync(order);
            }
        }

        public void Delete(int id)
        {
            var order = _dbSet.Where(x => x.Id == id);

            if (order == null)
            {
                throw new OrderDontDeleteException(OrderExceptionMessages.OrderDontDelete);
            }
            else
            {
                _northwindContext.Remove(order);
            }
        }

        public async Task<IList<Order>> GetAll()
        {
            var orders = await _dbSet.ToListAsync();

            if (orders == null)
            {
                throw new OrderNotFoundException(OrderExceptionMessages.OrderNotFound);
            }
            else
            {
                return orders;
            }

        }

        public async Task<Order> GetById(int id)
        {
            var order = await _dbSet.FindAsync(id);

            if (order == null)
            {
                throw new OrderNotFoundException(OrderExceptionMessages.OrderNotFound);
            }
            else
            {
                return order;
            }
        }

        public void Update(Order order)
        {
            if (order == null)
            {
                throw new OrderDontUpdateException(OrderExceptionMessages.OrderDontUpdate);
            }
            else
            {
                _dbSet.Update(order);
            }
        }
    }
}
