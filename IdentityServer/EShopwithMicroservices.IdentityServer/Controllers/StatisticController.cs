using EShopwithMicroservices.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EShopwithMicroservices.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public StatisticController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> GetUserCount()
        {
            var values = await _userManager.Users.CountAsync();
            return Ok(values);
        }
    }
}
