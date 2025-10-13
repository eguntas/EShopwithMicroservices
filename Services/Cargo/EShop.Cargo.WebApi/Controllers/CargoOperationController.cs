using EShop.Cargo.BusinessLayer.Abstract;
using EShop.Cargo.DtoLayer.CargoOperationDtos;
using EShop.Cargo.EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _CargoOperationService;
        public CargoOperationController(ICargoOperationService CargoOperationService)
        {
            _CargoOperationService = CargoOperationService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _CargoOperationService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto dto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode = dto.Barcode,
                Description = dto.Description,
                OperationDate = dto.OperationDate

            };
            _CargoOperationService.TInsert(cargoOperation);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCargoOperation(int id)
        {
            _CargoOperationService.TDelete(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var value = _CargoOperationService.TGetById(id);
            if (value != null)
            {
                return Ok(value);
            }
            return NotFound();
        }
        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto dto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
               Id = dto.Id,
                Barcode = dto.Barcode,
                Description = dto.Description,
                OperationDate = dto.OperationDate
            };
            _CargoOperationService.TUpdate(cargoOperation);
            return Ok();
        }
    }
}
