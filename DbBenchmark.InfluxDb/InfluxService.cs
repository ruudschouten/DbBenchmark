using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Linq;

namespace DbBenchmark.InfluxDb;

public class InfluxService
{
    private readonly InfluxDBClientOptions _options;
    private readonly QueryableOptimizerSettings _optimizerSettings;
    private readonly WriteApiAsync _writeApi;
    private readonly QueryApi _queryApi;
    private readonly QueryApiSync _queryApiSync;

    public InfluxService(InfluxDBClientOptions options)
    {
        options.Timeout = TimeSpan.FromSeconds(10);
        _options = options;
        var client = new InfluxDBClient(options);

        _writeApi = client.GetWriteApiAsync();
        _queryApi = client.GetQueryApi();
        _queryApiSync = client.GetQueryApiSync();

        _optimizerSettings = new QueryableOptimizerSettings
        {
            AlignLimitFunctionAfterPivot = false,
            AlignFieldsWithPivot = false
        };
    }

    public Task Save(InfluxReading reading)
    {
        return _writeApi.WriteMeasurementAsync(reading, WritePrecision.Ns, _options.Bucket, _options.Org);
    }

    public async Task<IList<InfluxReading>> GetBetween(DateTime start, DateTime end)
    {
        const string flux = "from(bucket: params.bucketParam)" +
                            // "|> range(start: params.startParam, stop: params.endParam)" +
                            "|> filter(fn: (r) => r[\"_measurement\"] == \"reading\")" +
                            "|> limit(n: 50)";

        var bindParams = new Dictionary<string, object>
        {
            { "bucketParam", _options.Bucket }
        };
        var query = new Query(query: flux, _params: bindParams, dialect: QueryApi.Dialect);

        var s = query._Query;

        var tables = await _queryApi.QueryAsync(query)
            .ConfigureAwait(false);

        // print results
        foreach (var record in tables.SelectMany(table => table.Records))
            Console.WriteLine(
                $"{record.GetTime()} {record.GetMeasurement()}: {record.GetField()} {record.GetValue()}");

        return new List<InfluxReading>();
    }
}