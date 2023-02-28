using MongoDB.Bson;

namespace DbBenchmark.MongoDb;

public class MongoReading
{
    public ObjectId Id { get; set; }
    public int SensorId { get; set; }
    public DateTimeOffset TimeStamp { get; set; }
    public string ValueType { get; set; }
    public float Value { get; set; }
}