using StackExchange.Redis;

namespace MultiShop.Basket.Settings;

public class RedisService
{
    #region Fields

    private readonly string _host;
    private readonly int _port;
    private ConnectionMultiplexer _connectionMultiplexer;

    #endregion

    #region Ctor

    public RedisService(string host, int port)
    {
        _host = host;
        _port = port;
    }

    #endregion

    #region Methods

    public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");

    public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(0);

    #endregion
}
