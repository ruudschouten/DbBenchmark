using CouchDB.Driver.Types;

namespace DbBenchmark.CouchDb;

public class CouchReading : CouchDocument
{
    public int SensorId { get; set; }
    public DateTimeOffset TimeStamp { get; set; }
    public string ValueType { get; set; }
    public float Value { get; set; }
}