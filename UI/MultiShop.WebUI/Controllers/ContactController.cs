using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using MultiShop.WebUI.Services.ContactServices;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {

        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult Index()
        {
            ViewBag.Directory1 = "MultiShop";
            ViewBag.Directory2 = "Contact";
            ViewBag.Directory3 = "Shopping";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto dto)
        {
            dto.SendDate = DateTime.Now;
            dto.IsRead = false;
            await _contactService.CreateContactAsync(dto);
            return RedirectToAction("Index", "Default", new { area = "Admin" });

        }
    }
}
