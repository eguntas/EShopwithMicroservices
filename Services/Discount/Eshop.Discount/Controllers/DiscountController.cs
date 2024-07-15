using Eshop.Discount.Dtos;
using Eshop.Discount.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        public async Task<IActionResult> DiscountCouponList() 
        { 
           var values =await _discountService.GetAllCouponAsync();
           return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountByIdCoupon(int id) 
        { 
            var values =await _discountService.GetByIdCouponAsync(id);
            return Ok(values);  
        }
        [HttpPost]
        public async Task<IActionResult> DiscountCreateCoupon(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateCouponAsync(createCouponDto);
            return Ok("Coupon create success");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateCouponAsync(updateCouponDto);
            return Ok("Coupon update success");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int Id)
        {
            await _discountService.DeleteCouponAsync(Id);
            return Ok("Coupon delete success");

        }
    }
}
