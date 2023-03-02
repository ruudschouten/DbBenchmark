using NRedisStack.DataTypes;

namespace RedisTimeSeries;

public class RedisTimeSeriesReading
{
    public int SensorId { get; set; }
    public TimeStamp TimeStamp { get; set; }
    public string ValueType { get; set; }
    public float Value { get; set; }
}