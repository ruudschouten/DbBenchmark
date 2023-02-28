using MongoDB.Driver;

namespace DbBenchmark.MongoDb;

public class MongoService
{
    private MongoClient _client;
    private IMongoDatabase _database;
    private IMongoCollection<MongoReading> _collection;

    public MongoService(
        string url,
        string db,
        string collection)
    {
        _client = new MongoClient(url);
        _database = _client.GetDatabase(db);
        _collection = _database.GetCollection<MongoReading>(collection);
    }

    public Task Save(MongoReading reading)
    {
        return _collection.InsertOneAsync(reading);
    }
}