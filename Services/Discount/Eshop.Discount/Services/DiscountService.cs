using Dapper;
using Eshop.Discount.Context;
using Eshop.Discount.Dtos;
using System.Reflection.Metadata;

namespace Eshop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code , Rate , IsActive , ValidDate) " +
                "values (@code , @rate , @isActive , @validDate)";
            var paramaters = new DynamicParameters();
            paramaters.Add("@code", createCouponDto.Code);
            paramaters.Add("@rate", createCouponDto.Rate);
            paramaters.Add("@isActive", createCouponDto.IsActive);
            paramaters.Add("@validDate", createCouponDto.ValidDate);
            using (var connection = _context.CreatedConnection())
            {
                await connection.ExecuteAsync(query , paramaters);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            var query = "Delete from Coupons where CouponId=@couponId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@couponId",id);
            using (var connection = _context.CreatedConnection())
            {
                await connection.ExecuteAsync (query , paramaters);
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            string query = "select * from Copuns";
            using (var connection = _context.CreatedConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            string query = "select * from Coupons where CouponId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using (var connection = _context.CreatedConnection())
            {
               return await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query, parameters);            
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "update Coupons set Code=@code , Rate=@rate, IsActive=@isActive , ValidDate=@validDate where CouponId=@Id ";
            var paramaters = new DynamicParameters();
            paramaters.Add("@Id", updateCouponDto.CouponId);
            paramaters.Add("@code", updateCouponDto.Code);
            paramaters.Add("@rate", updateCouponDto.Rate);
            paramaters.Add("@isActive", updateCouponDto.IsActive);
            paramaters.Add("@validDate", updateCouponDto.ValidDate);
            using (var connection = _context.CreatedConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
    }
}
