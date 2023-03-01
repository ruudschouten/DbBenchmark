using MongoDB.Driver;

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
}