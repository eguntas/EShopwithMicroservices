namespace EShopwithMicroservices.IdentityServer.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "http://localhost";
        public const string ValidIssuer = "http://localhost";       
        public const string Key = "MultiShopSecretKeyForJwtTokenGeneration";       
        public const int Expire = 60;
    }
}
