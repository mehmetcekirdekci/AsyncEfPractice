using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public class ErrorResponse : Response
    {
        public ErrorResponse(string message) : base(false, message)
        {

        }
        public ErrorResponse() : base(false)
        {

        }
    }
}
