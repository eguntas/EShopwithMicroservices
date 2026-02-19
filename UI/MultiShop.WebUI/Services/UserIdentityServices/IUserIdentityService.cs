using MultiShop.DtoLayer.IdentityDtos.UserDto;

namespace MultiShop.WebUI.Services.UserIdentityServices
{
    public interface IUserIdentityService
    {
        Task<List<ResultUserDto>> GetAllUser();
    }
}
