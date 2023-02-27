using InfluxDB.Client;

namespace DbBenchmark.InfluxDb;

public class InfluxService
{
    private InfluxDBClientOptions _options;

    public InfluxService(InfluxDBClientOptions options)
    {
        _options = options;
    }

    private InfluxDBClient GetClient(double timespanSeconds = 10)
    {
        _options.Timeout = TimeSpan.FromSeconds(timespanSeconds);
        return new InfluxDBClient(_options);
    }

    public async Task Save(InfluxReading reading)
    {
        using var client = GetClient();

        var writeApi = client.GetWriteApiAsync();
        await writeApi.WriteMeasurementAsync(reading)
            .ConfigureAwait(false);
    }
}