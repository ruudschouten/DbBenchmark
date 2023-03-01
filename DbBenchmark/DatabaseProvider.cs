using CouchDB.Driver.DependencyInjection;
using DbBenchmark.CouchDb;
using DbBenchmark.InfluxDb;
using DbBenchmark.MongoDb;
using DbBenchmark.Redis;
using InfluxDB.Client;

namespace DbBenchmark;

public static class DatabaseProvider
{
    public static void AddCouchDb(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<CouchService>();
            .UseEndpoint("http://localhost:5984")
        builder.Services.AddCouchContext<CouchDbContext>(optionsBuilder => optionsBuilder
            .EnsureDatabaseExists()
            .UseBasicAuthentication("root", "root"));
    }

    public static void AddInfluxDb(WebApplicationBuilder builder)
    {
        // Retrieve this from the Influx dashboard.
        const string token = "P-c_AljEQceB6ScaslaShcQl6vFcZU72w4FzvJe5LeCVJyxh1Na7skaquGdnHGDWm4AqPbSAEGphxWtsEMaP7g==";

        var options = new InfluxDBClientOptions("http://localhost:8086")
        {
            Token = token,
            Bucket = "benchmark",
            Org = "benchmark"
        };
        var model = new InfluxService(options);
        builder.Services.AddSingleton(model);
    }

    public static void AddMongoDb(WebApplicationBuilder builder)
    {
        const string url = "mongodb://localhost:27017";
        const string db = "benchmark";
        const string collectionName = "reading";

        var service = new MongoService(url, db, collectionName);
        builder.Services.AddSingleton(service);
    }

    public static void AddRedis(WebApplicationBuilder builder)
    {
        const string url = "redis://localhost:6379";

        var service = new RedisService(url);
        builder.Services.AddSingleton(service);
    }
}
