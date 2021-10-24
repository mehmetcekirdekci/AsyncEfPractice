using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.OrderExceptions
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException() : base() { }

        public OrderNotFoundException(String message) : base(message) { }
    }
}
