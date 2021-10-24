using Application.Models.OrderModels;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.OrderServices
{
    public interface IOrderService
    {
        Task<IDataResponse<OrderDTO>> GetById(int id);
        Task<IDataResponse<List<OrderDTO>>> GetAll();
        Task<IResponse> Add(OrderCreateDTO orderCreateDTO);
        IResponse Delete(int id);
        Task<IResponse> Update(OrderUpdateDTO orderUpdateDTO, int id);

    }
}
