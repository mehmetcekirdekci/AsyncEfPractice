using Application.Models.ProductModels;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices
{
    public interface IProductService
    {
        Task<IDataResponse<ProductDTO>> GetById(int id);
        Task<IDataResponse<List<ProductDTO>>> GetAll();
        Task<IResponse> Add(ProductCreateDTO productCreateDTO);
        IResponse Delete(int id);
        Task<IResponse> Update(ProductUpdateDTO productUpdateDTO, int id);

    }
}
