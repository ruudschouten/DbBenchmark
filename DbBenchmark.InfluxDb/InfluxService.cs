using InfluxDB.Client;

namespace DbBenchmark.InfluxDb;

public class InfluxService
{
    private readonly InfluxDBClient _client;

    public InfluxService(InfluxDBClientOptions options)
    {
        options.Timeout = TimeSpan.FromSeconds(10);
        _client = new InfluxDBClient(options);
    }

    public Task Save(InfluxReading reading)
    {
        var writeApi = _client.GetWriteApiAsync();
        return writeApi.WriteMeasurementAsync(reading);
    }
}