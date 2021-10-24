using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.ProductExceptions
{
    public class ProductDontUpdateException : Exception
    {
        public ProductDontUpdateException() : base() { }

        public ProductDontUpdateException(String message) : base(message) { }
    }
}
