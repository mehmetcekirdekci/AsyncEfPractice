using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.CategoryExceptions
{
    public class CategoryDontDeleteException : Exception
    {
        public CategoryDontDeleteException() : base() { }

        public CategoryDontDeleteException(String message) : base(message) { }
    }
}
