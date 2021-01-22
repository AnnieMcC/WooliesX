using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesX.Core.Resources;

namespace WooliesX.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResource>> GetProducts(string sortOptions);

        Task<ProductResource> GetProductById(int productId);
    }
}
