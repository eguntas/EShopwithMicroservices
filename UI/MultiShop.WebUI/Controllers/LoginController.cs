using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services;
using MultiShop.WebUI.Services.Concreate;
using MultiShop.WebUI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly IIdentityService _identityService;
        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto userLoginDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(userLoginDto), System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:5001/api/Login", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData , new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }); 
                if(tokenModel != null)
                {
                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                    var jwtToken = tokenHandler.ReadJwtToken(tokenModel.Token);
                    var claims = jwtToken.Claims.ToList();

                    if (tokenModel.Token != null)
                    {
                        claims.Add(new Claim("multishoptoken", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProp = new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = tokenModel.ExpireDate
                        };
                        var UserId = _loginService.GetUserId;
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProp);
                        return RedirectToAction("Index", "Default");
                    }
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SignIn()
        {
            //await _identityService.SignInAsync(SignInDto signInDto);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDto dto)
        {
            await _identityService.SignInAsync(dto);
            //return View();
            return RedirectToAction("Index", "User");
        }


    }
}
