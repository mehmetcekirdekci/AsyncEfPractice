using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.CategoryExceptions
{
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException() : base() { }

        public CategoryNotFoundException(String message) : base(message) { }
    }
}
