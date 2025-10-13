using EShop.Cargo.BusinessLayer.Abstract;
using EShop.Cargo.DtoLayer.CargoCompanyDtos;
using EShop.Cargo.EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _cargoCompanyService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCompanyDtos dto)
        {
            CargoCompany company = new CargoCompany()
            {
                CargoCompanyName = dto.CargoCompanyName
            };
            _cargoCompanyService.TInsert(company);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCargoCompany(int id)
        {
            var value = _cargoCompanyService.TGetById(id);
            if (value != null)
            {
                _cargoCompanyService.TDelete(id);
                return Ok();
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var value = _cargoCompanyService.TGetById(id);
            if (value != null)
            {
                return Ok(value);
            }
            return NotFound();
        }
        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto dto)
        {
            CargoCompany company = new CargoCompany()
            {
                Id = dto.CargoCompanyId,
                CargoCompanyName = dto.CargoCompanyName
            };
            _cargoCompanyService.TUpdate(company);
            return Ok();
        }

    }
}
