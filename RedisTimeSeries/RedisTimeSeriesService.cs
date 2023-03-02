using NRedisStack.DataTypes;
using NRedisStack.RedisStackCommands;
using StackExchange.Redis;

namespace RedisTimeSeries;

public class RedisTimeSeriesService
{
    private IDatabase? _db;
    private TimeSeriesLabel _benchmarkLabel;

    public RedisTimeSeriesService(string url)
    {
        var muxer = ConnectionMultiplexer.Connect(url);
        _db = muxer.GetDatabase();
        _benchmarkLabel = new("Benchmark", "Readings");
    }

    public async Task Save(RedisTimeSeriesReading reading)
    {
        await _db.TS().AddAsync(
            "Reading",
            reading.TimeStamp,
            reading.Value,
            labels: new List<TimeSeriesLabel>
            {
                new("SensorId", reading.SensorId.ToString()),
                new("ValueType", reading.ValueType),
                _benchmarkLabel
            }
        );
    }
}