using Application.Messages.ErrorMessages;
using Application.Messages.SuccessMessages;
using Application.Models.CategoryModels;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<IResponse> Add(CategoryCreateDTO categoryCreateDTO)
        {
            var category = _mapper.Map<Category>(categoryCreateDTO);

            if (category == null)
            {
                return new ErrorResponse(CategoryErrorMessages.CategoryDontAdd);
            }
            else
            {
                await _categoryRepository.Add(category);
                return new SuccessResponse(CategorySuccessMessages.CategoryAddedSuccesfuly);
            }
        }

        public IResponse Delete(int id)
        {
            var category = _categoryRepository.GetById(id);

            if (category == null)
            {
                return new ErrorResponse(CategoryErrorMessages.CategoryDontDelete);
            }
            else
            {
                _categoryRepository.Delete(id);
                return new SuccessResponse(CategorySuccessMessages.CategoryDeletedSuccesfuly);
            }
        }

        public async Task<IDataResponse<List<CategoryDTO>>> GetAll()
        {
            var categories = await _categoryRepository.GetAll();
            var dtos = _mapper.Map<List<CategoryDTO>>(categories);

            if (dtos == null)
            {
                return new ErrorDataResponse<List<CategoryDTO>>(CategoryErrorMessages.CategoryDontFound);
            }
            else
            {
                return new SuccessDataResponse<List<CategoryDTO>>(dtos, CategorySuccessMessages.CategoryFoundedSuccesfuly);
            }
        }

        public async Task<IDataResponse<CategoryDTO>> GetById(int id)
        {
            var category = await _categoryRepository.GetById(id);
            var mappedCategory = _mapper.Map<CategoryDTO>(category);

            if (mappedCategory == null)
            {
                return new ErrorDataResponse<CategoryDTO>(CategoryErrorMessages.CategoryDontFound);
            }
            else
            {
                return new SuccessDataResponse<CategoryDTO>(mappedCategory, CategorySuccessMessages.CategoryFoundedSuccesfuly);
            }
        }

        public async Task<IResponse> Update(CategoryUpdateDTO categoryUpdateDTO, int id)
        {
            var mappedCategory = _mapper.Map<Category>(categoryUpdateDTO);
            var updatedCategory = await _categoryRepository.GetById(id);

            if (updatedCategory == null || categoryUpdateDTO == null)
            {
                return new ErrorResponse(CategoryErrorMessages.CategoryDontUpdate);
            }
            else
            {
                updatedCategory.CategoryName = mappedCategory.CategoryName;
                return new SuccessResponse(CategorySuccessMessages.CategoryUpdatedSuccesfuly);
            }
        }
    }
}
