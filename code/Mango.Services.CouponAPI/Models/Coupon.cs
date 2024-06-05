using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Models
{
    [Index(nameof(CouponCode))]
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        
        [Required]
        public string CouponCode { get; set; }
        
        [Required]
        public double DiscountAmount { get; set; }
        
        public int MinAmount { get; set; }
    }
}
