using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;
        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateProductsAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Constants.ApiType.POST,
                Data=productDto,
                Url = Constants.ProductAPIBase + "/api/product" ,
                ContentType = Constants.ContentType.MultipartFormData
            });
        }

        public async Task<ResponseDto?> DeleteProductsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Constants.ApiType.DELETE,
                Url = Constants.ProductAPIBase + "/api/product/" + id
            }); 
        }

        public async Task<ResponseDto?> GetAllProductsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Constants.ApiType.GET,
                Url = Constants.ProductAPIBase + "/api/product"
            });
        }

      

        public async Task<ResponseDto?> GetProductByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Constants.ApiType.GET,
                Url = Constants.ProductAPIBase + "/api/product/" + id
            });
        }

        public async Task<ResponseDto?> UpdateProductsAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Constants.ApiType.PUT,
                Data = productDto,
                Url = Constants.ProductAPIBase + "/api/product",
                ContentType = Constants.ContentType.MultipartFormData
            });
        }
    }
}
