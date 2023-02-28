using Bogus;
using DbBenchmark.MongoDb;

namespace DbBenchmark.Fakers;

public class MongoReadingFaker: Faker<MongoReading>
{
    public MongoReadingFaker()
    {
        RuleFor(reading => reading.TimeStamp, () => DateTime.UtcNow);
        RuleFor(reading => reading.ValueType, (faker, _) => faker.System.FileType());
        RuleFor(reading => reading.Value, (faker, _) => faker.Random.Float(-100f, 100f));
        RuleFor(reading => reading.SensorId, (faker, _) => faker.Random.Int(min: 1));
    }
}