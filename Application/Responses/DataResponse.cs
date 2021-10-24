using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public class DataResponse<T> : Response, IDataResponse<T>
    {
        public DataResponse(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public DataResponse(T data, bool success) : base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
