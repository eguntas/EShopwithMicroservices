using EShop.Cargo.BusinessLayer.Abstract;
using EShop.Cargo.DtoLayer.CargoCompanyDtos;
using EShop.Cargo.DtoLayer.CargoDetailDtos;
using EShop.Cargo.EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;
        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoDetailDto dto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Barcode = dto.Barcode,
                ReceiverCustomer = dto.ReceiverCustomer,
                SenderCustomer = dto.SenderCustomer,
                CargoCompanyId = dto.CargoCompanyId

            };
            _cargoDetailService.TInsert(cargoDetail);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("CargoDetail deleted");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var value = _cargoDetailService.TGetById(id);
            if (value != null)
            {
                return Ok(value);
            }
            return NotFound();
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto dto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
               Barcode = dto.Barcode,
                Id = dto.Id,
                ReceiverCustomer = dto.ReceiverCustomer,
                SenderCustomer = dto.SenderCustomer,
                CargoCompanyId = dto.CargoCompanyId
            };
            _cargoDetailService.TUpdate(cargoDetail);
            return Ok();
        }
    }
}
