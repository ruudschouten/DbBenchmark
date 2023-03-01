using Redis.OM;
using Redis.OM.Searching;

namespace DbBenchmark.Redis;

public class RedisService
{
    private readonly IRedisCollection<RedisReading> _readings;

    public RedisService(string url)
    {
        var provider = new RedisConnectionProvider(url);
        _readings = provider.RedisCollection<RedisReading>();
    }

    public Task Save(RedisReading reading)
    {
        return _readings.InsertAsync(reading);
    }
}