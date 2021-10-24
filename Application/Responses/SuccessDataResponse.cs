using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public class SuccessDataResponse<T> : DataResponse<T>
    {
        public SuccessDataResponse(T data, string message) : base(data, true, message)
        {

        }
        public SuccessDataResponse(T data) : base(data, true)
        {

        }
        public SuccessDataResponse(string message) : base(default, true, message)
        {

        }
        public SuccessDataResponse() : base(default, true)
        {

        }
    }
}
