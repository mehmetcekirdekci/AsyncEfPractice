using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.CategoryExceptions
{
    public class CategoryDontUpdateException : Exception
    {
        public CategoryDontUpdateException() : base() { }

        public CategoryDontUpdateException(String message) : base(message) { }
    }
}
