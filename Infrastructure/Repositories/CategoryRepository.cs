using Domain.Entities;
using Domain.Exceptions.CategoryExceptions;
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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NorthwindContext _northwindContext;
        private readonly DbSet<Category> _dbSet;

        public CategoryRepository(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
            _dbSet = northwindContext.Set<Category>();

        }
        public async Task Add(Category category)
        {
            if (category == null)
            {
                throw new CategoryDontAddException(CategoryExceptionMessages.CategoryDontAdd);
            }
            else
            {
                await _dbSet.AddAsync(category);
            }
        }

        public void Delete(int id)
        {
            var category = _dbSet.Where(x => x.Id == id);

            if (category == null)
            {
                throw new CategoryDontDeleteException(CategoryExceptionMessages.CategoryDontDelete);
            }
            else
            {
                _northwindContext.Remove(category);
            }
        }

        public async Task<IList<Category>> GetAll()
        {
            var categories = await _dbSet.ToListAsync();

            if (categories == null)
            {
                throw new CategoryNotFoundException(CategoryExceptionMessages.CategoryNotFound);
            }
            else
            {
                return categories;
            }
        }

        public async Task<Category> GetById(int id)
        {
            var category = await _dbSet.FindAsync(id);

            if (category == null)
            {
                throw new CategoryNotFoundException(CategoryExceptionMessages.CategoryNotFound);
            }
            else
            {
                return category;
            }
        }

        public void Update(Category category)
        {
            if (category == null)
            {
                throw new CategoryDontUpdateException(CategoryExceptionMessages.CategoryDontUpdate);
            }
            else
            {
                _dbSet.Update(category);
            }
        }
    }
}
