using Application.Models.CategoryModels;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<IDataResponse<CategoryDTO>> GetById(int id);
        Task<IDataResponse<List<CategoryDTO>>> GetAll();
        Task<IResponse> Add(CategoryCreateDTO categoryCreateDTO);
        IResponse Delete(int id);
        Task<IResponse> Update(CategoryUpdateDTO categoryUpdateDTO, int id);

    }
}
