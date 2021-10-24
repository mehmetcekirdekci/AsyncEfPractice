using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.OrderExceptions
{
    public class OrderDontDeleteException : Exception
    {
        public OrderDontDeleteException() : base() { }

        public OrderDontDeleteException(String message) : base(message) { }
    }
}
