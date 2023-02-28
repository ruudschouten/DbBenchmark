using CouchDB.Driver.DependencyInjection;
using DbBenchmark.CouchDb;
using DbBenchmark.InfluxDb;
using InfluxDB.Client;

namespace DbBenchmark;

public static class DatabaseProvider
{
    public static void AddCouchDb(WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.Services.AddTransient<CouchService>();
        webApplicationBuilder.Services.AddCouchContext<DbBenchmark.CouchDb.Context>(optionsBuilder => optionsBuilder
            .UseEndpoint("http://localhost:5984")
            .EnsureDatabaseExists()
            .UseBasicAuthentication("root", "root"));
    }

    public static void AddInfluxDb(WebApplicationBuilder builder1)
    {
        // Retrieve this from the Influx dashboard.
        var token = "";

        var options = new InfluxDBClientOptions("http://localhost:8086")
        {
            Token = token,
            Bucket = "benchmark",
            Org = "benchmark"
        };
        var model = new InfluxService(options);
        builder1.Services.AddSingleton(model);
    }
}