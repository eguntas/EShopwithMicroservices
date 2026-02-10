using EShop.Category.Dtos.ContactDtos;
using EShop.Category.Services.ContactServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Category.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _ContactService;

        public ContactController(IContactService ContactService)
        {
            _ContactService = ContactService;
        }
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _ContactService.GetAllContactAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(string id)
        {
            var values = await _ContactService.GetByIdContactAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await _ContactService.CreateContactAsync(createContactDto);
            return Ok("Added Contact success!!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            await _ContactService.UpdateContactAsync(updateContactDto);
            return Ok("Updated Contact success");
        }

    }
}
