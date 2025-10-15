using StackExchange.Redis;

namespace EShop.Basket.Settings
{
    public class RedisService
    {
        public string _host;
        public int _port;
        private ConnectionMultiplexer _redis;
        public RedisService(string host , int port)
        {
            _host = host;
            _port = port;
        }
        public void Connect() => _redis = ConnectionMultiplexer.Connect($"{_host}:{_port}");

        public IDatabase GetDb(int db = 1) => _redis.GetDatabase(0);
    }
}
