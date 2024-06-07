using Mango.Services.CartAPI.Models.Dto;

namespace Mango.Services.CartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
