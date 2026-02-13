using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using Microsoft.Extensions.Options;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.Services.Concreate
{
    public class ClientCredentialTokenService : IClientCredentialTokenService
    {
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly HttpClient _httpClient;
        private readonly ClientSettings _clientSettings;
        private readonly IClientAccessTokenCache _clientAccessTokenCache;

        public ClientCredentialTokenService(IClientAccessTokenCache clientAccessTokenCache, IOptions<ServiceApiSettings> serviceApiSettings, HttpClient httpClient, IOptions<ClientSettings> clientSettings)
        {
            _clientAccessTokenCache = clientAccessTokenCache;
            _serviceApiSettings = serviceApiSettings.Value;
            _httpClient = httpClient;
            _clientSettings = clientSettings.Value;
        }

        public async Task<string> GetToken()
        {
            var token = await _clientAccessTokenCache.GetAsync("multishoptoken");
            if (token != null)
            {
                return token.AccessToken;
            }
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }
            });

            var ClientCredentialTokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.MultiShopVisitorClient.ClientId,
                ClientSecret = _clientSettings.MultiShopVisitorClient.ClientSecret,
                Address = discoveryEndPoint.TokenEndpoint
            };

            var newToken = await _httpClient.RequestClientCredentialsTokenAsync(ClientCredentialTokenRequest);
            await _clientAccessTokenCache.SetAsync("multishoptoken", newToken.AccessToken, newToken.ExpiresIn);
            return newToken.AccessToken;
        }
    }
}
