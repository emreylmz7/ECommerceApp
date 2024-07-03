using StackExchange.Redis;

namespace OllieShop.Basket.Settings
{
    public class RedisService
    {
        public string _host { get; set; }
        public string _port { get; set; }
        private ConnectionMultiplexer _multiplexer;
        public RedisService(string host, string port)
        {
            _host = host;
            _port = port;
        }

        public void Connect() => _multiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        public IDatabase GetDb(int db = 1) => _multiplexer.GetDatabase(0);
    }
}
