using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var values = await GetBasket();
            if (values != null)
            {
                if(!values.BasketItems.Any(x=>x.ProductId == basketItemDto.ProductId))
                {
                    values.BasketItems.Add(basketItemDto);
                }
                else
                {
                    values = new BasketTotalDto();
                    values.BasketItems.Add(basketItemDto);
                }

            }
            await SaveBasket(values);
        }

        public Task DeleteBasket(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketTotalDto> GetBasket()
        {
           var response = await _httpClient.GetAsync("basket");
           var values = await response.Content.ReadFromJsonAsync<BasketTotalDto>();
           return values;
        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var values = await GetBasket();
            var itemToRemove = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
            if (itemToRemove != null)
            {
                values.BasketItems.Remove(itemToRemove);
                await SaveBasket(values);
                return true;
            }
            return false;
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _httpClient.PostAsJsonAsync<BasketTotalDto>("basket", basketTotalDto);
        }
    }
}
