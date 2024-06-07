using Mango.Services.CartAPI.Models.Dto;

namespace Mango.Services.CartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
