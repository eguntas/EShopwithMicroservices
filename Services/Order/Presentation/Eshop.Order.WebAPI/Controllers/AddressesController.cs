using Eshop.Order.Application.Features.CQRS.Commands.AddressCommands;
using Eshop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using Eshop.Order.Application.Features.CQRS.Queries.AddressQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Order.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryHandler _getAddressesQueryHandler;
        private readonly GetAddressByIdQueryHandler _getAddressesByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;

        public AddressesController(GetAddressQueryHandler getAddressesQueryHandler, GetAddressByIdQueryHandler getAddressesByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler = null, RemoveAddressCommandHandler removeAddressCommandHandler = null)
        {
            _getAddressesQueryHandler = getAddressesQueryHandler;
            _getAddressesByIdQueryHandler = getAddressesByIdQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> AddressesList()
        {
            var values =await _getAddressesQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> AddressListById(int id)
        {
            var value = await _getAddressesByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _createAddressCommandHandler.Handle(command);
            return Ok("Add Address succesful");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command) 
        {
            await _updateAddressCommandHandler.Handle(command);
            return Ok("Address update");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
            return Ok("Address delete");
        }
    }
}
