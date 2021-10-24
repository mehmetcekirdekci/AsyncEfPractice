using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public interface IDataResponse<out T> : IResponse
    {
        T Data { get; }
    }
}
