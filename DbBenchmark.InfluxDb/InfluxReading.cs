using InfluxDB.Client.Core;

namespace DbBenchmark.InfluxDb;

[Measurement("reading")]
public record InfluxReading(
    [property: Column("sensorId", IsTag = true)]
    int SensorId,
    [property: Column(IsTimestamp = true)] DateTime TimeStamp,
    [property: Column("type", IsTag = true)]
    string ValueType,
    [property: Column("value")] float Value
)
{
    // Empty constructor is required for InfluxDb mapping.
    public InfluxReading() : this(-1, default, string.Empty, -1f)
    {
    }
}