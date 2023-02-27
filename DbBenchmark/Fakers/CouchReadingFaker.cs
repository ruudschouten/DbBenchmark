using Bogus;
using DbBenchmark.CouchDb;

namespace DbBenchmark.Fakers;

public class CouchReadingFaker : Faker<CouchReading>
{
    public CouchReadingFaker()
    {
        RuleFor(reading => reading.TimeStamp, () => DateTimeOffset.UtcNow);
        RuleFor(reading => reading.ValueType, (faker, _) => faker.System.FileType());
        RuleFor(reading => reading.Value, (faker, _) => faker.Random.Float(-100f, 100f));
        RuleFor(reading => reading.SensorId, (faker, _) => faker.Random.Int(min: 1));
    }
}