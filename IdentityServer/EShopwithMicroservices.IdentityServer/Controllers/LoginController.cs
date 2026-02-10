using EShopwithMicroservices.IdentityServer.Dtos;
using EShopwithMicroservices.IdentityServer.Models;
using EShopwithMicroservices.IdentityServer.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EShopwithMicroservices.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public LoginController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, false, false);
            var user = await _userManager.FindByNameAsync(userLoginDto.Username);
            if (result.Succeeded)
            {
               GetCheckAppUserViewModel model = new GetCheckAppUserViewModel
               {
                    Username = userLoginDto.Username,
                    Id = user.Id,
               };
                return Ok(JwtTokenGenerator.GenerateToken(model));
            }
            else
            {
                return Unauthorized("Invalid username or password");
            }
        }
    }
}
