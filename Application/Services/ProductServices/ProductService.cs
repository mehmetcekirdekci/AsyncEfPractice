using Application.Messages.ErrorMessages;
using Application.Messages.SuccessMessages;
using Application.Models.ProductModels;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.ProductExceptions;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IResponse> Add(ProductCreateDTO productCreateDTO)
        {
            var product = _mapper.Map<Product>(productCreateDTO);

            if (product == null)
            {
                return new ErrorResponse(ProductErrorMessages.ProductDontAdd);
            }
            else
            {
                await _productRepository.Add(product);
                return new SuccessResponse(ProductSuccessMessages.ProductAddedSuccesfuly);
            }
        }

        public IResponse Delete(int id)
        {
            var product = _productRepository.GetById(id);

            if (product == null)
            {
                return new ErrorResponse(ProductErrorMessages.ProductDontDelete);
            }
            else
            {
                _productRepository.Delete(id);
                return new SuccessResponse(ProductSuccessMessages.ProductDeletedSuccesfuly);
            }
        }

        public async Task<IDataResponse<List<ProductDTO>>> GetAll()
        {
            var products = await _productRepository.GetAll();
            var dtos = _mapper.Map<List<ProductDTO>>(products);

            if (dtos == null)
            {
                return new ErrorDataResponse<List<ProductDTO>>(ProductErrorMessages.ProductDontFound);
            }
            else
            {
                return new SuccessDataResponse<List<ProductDTO>>(dtos, ProductSuccessMessages.ProductFoundedSuccesfuly);
            }
        }

        public async Task<IDataResponse<ProductDTO>> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            var mappedProduct = _mapper.Map<ProductDTO>(product);

            if (mappedProduct == null)
            {
                return new ErrorDataResponse<ProductDTO>(ProductErrorMessages.ProductDontFound);
            }
            else
            {
                return new SuccessDataResponse<ProductDTO>(mappedProduct, ProductSuccessMessages.ProductFoundedSuccesfuly);
            }
        }

        public async Task<IResponse> Update(ProductUpdateDTO productUpdateDTO, int id)
        {
            var mappedProduct = _mapper.Map<Product>(productUpdateDTO);
            var updatedProduct = await _productRepository.GetById(id);

            if (updatedProduct == null || productUpdateDTO == null)
            {
                return new ErrorResponse(ProductErrorMessages.ProductDontUpdate);
            }
            else
            {
                updatedProduct.ProductName = mappedProduct.ProductName;
                updatedProduct.UnitPrice = mappedProduct.UnitPrice;
                updatedProduct.CategoryId = mappedProduct.CategoryId;
                return new SuccessResponse(ProductSuccessMessages.ProductUpdatedSuccesfuly);
            }
        }
    }
}
