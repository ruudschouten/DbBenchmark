using InfluxDB.Client.Core;

namespace DbBenchmark.InfluxDb;

[Measurement("reading")]
public class InfluxReading
{
    [Column("data_type", IsTag = true)] public string ValueType { get; init; }
    [Column("sensor_id", IsTag = true)] public int SensorId { get; init; }
    [Column("value")] public float Value { get; init; }
    [Column(IsTimestamp = true)] public DateTime TimeStamp { get; init; }
}