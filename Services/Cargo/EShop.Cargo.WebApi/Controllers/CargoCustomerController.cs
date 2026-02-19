using EShop.Cargo.BusinessLayer.Abstract;
using EShop.Cargo.DtoLayer.CargoCustomerDtos;
using EShop.Cargo.EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomerController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _cargoCustomerService.TGetAll();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _cargoCustomerService.TGetById(id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Add(CreateCargoCustomerDto dto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Phone = dto.Phone,
                Email = dto.Email,
                District = dto.District,
                City = dto.City,
                Address = dto.Address,
                UserCustomerId = dto.UserCustomerId
                
            };
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Cargo customer added");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            
            _cargoCustomerService.TDelete(id);
            return Ok("Cargo customer deleted");
        }
        [HttpPut]
        public IActionResult Update(int id, CreateCargoCustomerDto dto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Id = id,
                Name = dto.Name,
                Surname = dto.Surname,
                Phone = dto.Phone,
                Email = dto.Email,
                District = dto.District,
                City = dto.City,
                Address = dto.Address,
                UserCustomerId = dto.UserCustomerId
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Cargo customer updated");
        }

        [HttpGet("GetCargoCustomerById")]
        public IActionResult GetCargoCustomerById(string id) 
        {
            return Ok(_cargoCustomerService.TGetCargoCustomerById(id));
        }

    }

}
