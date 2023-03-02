using Bogus;
using NRedisStack.DataTypes;

namespace RedisTimeSeries;

public class RedisTimeSeriesFaker : Faker<RedisTimeSeriesReading>
{
    public RedisTimeSeriesFaker()
    {
        RuleFor(reading => reading.TimeStamp, () => new TimeStamp(DateTime.UtcNow));
        RuleFor(reading => reading.ValueType, (faker, _) => faker.System.FileType());
        RuleFor(reading => reading.Value, (faker, _) => faker.Random.Float(-100f, 100f));
        RuleFor(reading => reading.SensorId, (faker, _) => faker.Random.Int(1));
    }
}