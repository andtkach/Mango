using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class CartService : ICartService
    {
        private readonly IBaseService _baseService;
        public CartService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> ApplyCouponAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Constants.ApiType.POST,
                Data = cartDto,
                Url = Constants.CartAPIBase + "/api/cart/ApplyCoupon"
            });
        }

        public async Task<ResponseDto?> EmailCart(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Constants.ApiType.POST,
                Data = cartDto,
                Url = Constants.CartAPIBase + "/api/cart/EmailCartRequest"
            });
        }

        public async Task<ResponseDto?> GetCartByUserIdAsnyc(string userId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Constants.ApiType.GET,
                Url = Constants.CartAPIBase + "/api/cart/GetCart/"+ userId
            });
        }

        
        public async Task<ResponseDto?> RemoveFromCartAsync(int cartDetailsId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Constants.ApiType.POST,
                Data = cartDetailsId,
                Url = Constants.CartAPIBase + "/api/cart/RemoveCart"
            });
        }

      
        public async Task<ResponseDto?> UpsertCartAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Constants.ApiType.POST,
                Data = cartDto,
                Url = Constants.CartAPIBase + "/api/cart/CartUpsert"
            });
        }
    }
}
