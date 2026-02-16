using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;
        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
      
        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await _httpClient.PostAsJsonAsync<CreateContactDto>("contact", createContactDto);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _httpClient.DeleteAsync($"contact?id={id}");
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var response = await _httpClient.GetAsync("contact");
            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var response = await _httpClient.GetAsync($"contact/{id}");
            return await response.Content.ReadFromJsonAsync<GetByIdContactDto>();
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateContactDto>("contact", updateContactDto);
        }
    }
}
