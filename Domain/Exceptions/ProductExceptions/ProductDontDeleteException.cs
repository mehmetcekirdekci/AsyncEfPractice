using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.ProductExceptions
{
    public class ProductDontDeleteException : Exception
    {
        public ProductDontDeleteException() : base() { }

        public ProductDontDeleteException(String message) : base(message) { }
    }
}
