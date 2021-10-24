using Application.Messages.ErrorMessages;
using Application.Messages.SuccessMessages;
using Application.Models.OrderModels;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<IResponse> Add(OrderCreateDTO orderCreateDTO)
        {
            var order = _mapper.Map<Order>(orderCreateDTO);

            if (order == null)
            {
                return new ErrorResponse(OrderErrorMessages.OrderDontAdd);
            }
            else
            {
                await _orderRepository.Add(order);
                return new SuccessResponse(OrderSuccessMessages.OrderAddedSuccesfuly);
            }
        }

        public IResponse Delete(int id)
        {
            var order = _orderRepository.GetById(id);

            if (order == null)
            {
                return new ErrorResponse(OrderErrorMessages.OrderDontDelete);
            }
            else
            {
                _orderRepository.Delete(id);
                return new SuccessResponse(OrderSuccessMessages.OrderDeletedSuccesfuly);
            }
        }

        public async Task<IDataResponse<List<OrderDTO>>> GetAll()
        {
            var orders = await _orderRepository.GetAll();
            var dtos = _mapper.Map<List<OrderDTO>>(orders);

            if (dtos == null)
            {
                return new ErrorDataResponse<List<OrderDTO>>(OrderErrorMessages.OrderDontFound);
            }
            else
            {
                return new SuccessDataResponse<List<OrderDTO>>(dtos, OrderSuccessMessages.OrderFoundedSuccesfuly);
            }
        }

        public async Task<IDataResponse<OrderDTO>> GetById(int id)
        {
            var order = await _orderRepository.GetById(id);
            var mappedOrder = _mapper.Map<OrderDTO>(order);

            if (mappedOrder == null)
            {
                return new ErrorDataResponse<OrderDTO>(OrderErrorMessages.OrderDontFound);
            }
            else
            {
                return new SuccessDataResponse<OrderDTO>(mappedOrder, OrderSuccessMessages.OrderFoundedSuccesfuly);
            }
        }

        public async Task<IResponse> Update(OrderUpdateDTO orderUpdateDTO, int id)
        {
            var mappedOrder = _mapper.Map<Order>(orderUpdateDTO);
            var updatedOrder = await _orderRepository.GetById(id);

            if (updatedOrder == null || orderUpdateDTO == null)
            {
                return new ErrorResponse(OrderErrorMessages.OrderDontUpdate);
            }
            else
            {
                updatedOrder.CategoryId = mappedOrder.CategoryId;
                updatedOrder.ProductId = mappedOrder.ProductId;
                updatedOrder.UserId = mappedOrder.UserId;
                return new SuccessResponse(CategorySuccessMessages.CategoryUpdatedSuccesfuly);
            }
        }
    }
}
