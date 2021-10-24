using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.OrderExceptions
{
    public class OrderDontAddException : Exception
    {
        public OrderDontAddException() : base() { }

        public OrderDontAddException(String message) : base(message) { }
    }
}
