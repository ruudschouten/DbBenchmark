using Redis.OM.Modeling;

namespace DbBenchmark.Redis;

[Document(StorageType = StorageType.Json)]
public class RedisReading
{
    [RedisIdField] public Ulid Id { get; set; }
    [Indexed] public int SensorId { get; set; }
    [Indexed(Sortable = true)] public DateTimeOffset TimeStamp { get; set; }
    [Indexed(Sortable = true)] public string ValueType { get; set; }
    [Indexed] public float Value { get; set; }
}