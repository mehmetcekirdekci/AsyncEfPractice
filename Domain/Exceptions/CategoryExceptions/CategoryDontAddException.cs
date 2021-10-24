using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.CategoryExceptions
{
    public class CategoryDontAddException : Exception
    {
        public CategoryDontAddException() : base() { }

        public CategoryDontAddException(String message) : base(message) { }
    }
}
