using EShop.Category.Dtos.ContactDtos;

namespace EShop.Category.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task<GetByIdContactDto> GetByIdContactAsync(string id);
    }
}
