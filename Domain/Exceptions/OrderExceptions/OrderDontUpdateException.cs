using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.OrderExceptions
{
    public class OrderDontUpdateException : Exception
    {
        public OrderDontUpdateException() : base() { }

        public OrderDontUpdateException(String message) : base(message) { }
    }
}
