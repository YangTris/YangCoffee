using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.IRepositories
{
    public interface IProductImageRepository
    {
        Task<IEnumerable<ProductImage>> GetAllProductImagesAsync(string producVarianttId);
        Task AddProductImageAsync(ProductImage productImage);
        Task DeleteProductImageAsync(int id);
    }
}
