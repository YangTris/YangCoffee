using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs;

namespace Application.IServices
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();
        public Task<CategoryDTO> GetCategoryByIdAsync(string id);
        public Task<CategoryDTO> AddCategoryAsync(CategoryDTO categoryDTO);
        public Task UpdateCategoryAsync(string id, CategoryDTO categoryDTO);
        public Task DeleteCategoryAsync(string id);
    }
}
