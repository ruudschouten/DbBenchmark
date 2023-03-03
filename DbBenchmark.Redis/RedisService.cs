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
        provider.Connection.CreateIndex(typeof(RedisReading));
    }

    public Task Save(RedisReading reading)
    {
        return _readings.InsertAsync(reading);
    }

    public Task<List<RedisReading>> GetBetween(DateTime from, DateTime to)
    {
        var filtered = _readings
            .Where(reading => reading.TimeStamp >= from && reading.TimeStamp <= to)
            .Take(50)
            .ToList();

        return Task.FromResult(filtered);
    }
}