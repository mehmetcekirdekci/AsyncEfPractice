using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public class ErrorDataResponse<T> : DataResponse<T>
    {
        public ErrorDataResponse(T data, string message) : base(data, false, message)
        {

        }
        public ErrorDataResponse(T data) : base(data, false)
        {

        }
        public ErrorDataResponse(string message) : base(default, false, message)
        {

        }
        public ErrorDataResponse() : base(default, false)
        {

        }
    }
}
