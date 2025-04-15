using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.IRepositories;
using Application.IServices;
using Domain;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        private static CategoryDTO MapToDTO(Category category)
        {
            if (category == null)
            {
                return null;
            }
            return new CategoryDTO
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description
            };
        }

        public async Task<CategoryDTO> AddCategoryAsync(CategoryDTO categoryDTO)
        {
            var category= new Category
            {
                CategoryId = Guid.NewGuid().ToString(),
                Name = categoryDTO.Name,
                Description = categoryDTO.Description
            };
            
            await _categoryRepository.AddAsync(category);
            return MapToDTO(category);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category != null)
            {
                await _categoryRepository.DeleteAsync(id);
            }
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            var listCategory = await _categoryRepository.GetAllAsync();
            return listCategory.Select(MapToDTO);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(string id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return MapToDTO(category);
        }

        public async Task UpdateCategoryAsync(string id, CategoryDTO categoryDTO)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category != null)
            {
                category.Name = categoryDTO.Name;
                category.Description = categoryDTO.Description;
                await _categoryRepository.UpdateAsync(category);
            }
        }
    }
}
