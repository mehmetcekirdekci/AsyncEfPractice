using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.ProductExceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() : base() { }

        public ProductNotFoundException(String message) : base(message) { }
    }
}
