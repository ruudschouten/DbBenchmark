using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace DbBenchmark.MongoDb;

public class MongoService
{
    private readonly IMongoCollection<MongoReading> _collection;

    public MongoService(
        string url,
        string db,
        string collection)
    {
        var client = new MongoClient(url);
        var database = client.GetDatabase(db);
        _collection = database.GetCollection<MongoReading>(collection);
    }

    public Task Save(MongoReading reading)
    {
        return _collection.InsertOneAsync(reading);
    }

    public Task<List<MongoReading>> GetBetween(DateTime from, DateTime to)
    {
        return Task.FromResult(_collection.AsQueryable()
            .Where(reading => reading.TimeStamp >= from && reading.TimeStamp <= to)
            .Take(50)
            .ToList()
        );
    }
}