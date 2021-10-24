using Domain.Entities;
using Domain.Exceptions.ProductExceptions;
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
    public class ProductRepository : IProductRepository
    {
        private readonly NorthwindContext _northwindContext;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
            _dbSet = northwindContext.Set<Product>();

        }

        public async Task Add(Product product)
        {
            if (product == null)
            {
                throw new ProductDontAddException(ProductExceptionMessages.ProductDontAdd);
            }
            else
            {
                await _dbSet.AddAsync(product);
            }
        }

        public void Delete(int id)
        {
            var product = _dbSet.Where(x => x.Id == id);

            if (product == null)
            {
                throw new ProductDontDeleteException(ProductExceptionMessages.ProductDontDelete);
            }
            else
            {
                _northwindContext.Remove(product);
            }
        }

        public async Task<IList<Product>> GetAll()
        {
            var products = await _dbSet.ToListAsync();

            if (products == null)
            {
                throw new ProductNotFoundException(ProductExceptionMessages.ProductNotFound);
            }
            else
            {
                return products;
            }

        }

        public async Task<Product> GetById(int id)
        {
            var product = await _dbSet.FindAsync(id);

            if (product == null)
            {
                throw new ProductNotFoundException(ProductExceptionMessages.ProductNotFound);
            }
            else
            {
                return product;
            }
        }

        public void Update(Product product)
        {
            if (product == null)
            {
                throw new ProductDontUpdateException(ProductExceptionMessages.ProductDontUpdate);
            }
            else
            {
                _dbSet.Update(product);
            }
        }
    }
}
