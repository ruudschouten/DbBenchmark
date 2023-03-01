using CouchDB.Driver.DependencyInjection;
using DbBenchmark.CouchDb;
using DbBenchmark.InfluxDb;
using DbBenchmark.MongoDb;
using DbBenchmark.Redis;
using InfluxDB.Client;

namespace DbBenchmark;

public static class DatabaseProvider
{
    public static bool UsingDocker { get; set; } = false;

    public static void AddCouchDb(WebApplicationBuilder builder)
    {
        const string dockerUrl = "http://benchmark_couchdb:5984";
        const string localUrl = "http://localhost:5984";

        builder.Services.AddTransient<CouchService>();
        builder.Services.AddCouchContext<CouchDbContext>(optionsBuilder => optionsBuilder
            .UseEndpoint(UsingDocker ? dockerUrl : localUrl)
            .EnsureDatabaseExists()
            .UseBasicAuthentication("root", "root"));
    }

    public static void AddInfluxDb(WebApplicationBuilder builder)
    {
        // Retrieve this from the Influx dashboard.
        const string token = "ibsu8H0W9WBNMTzlEfGGWmS5UAG6QJ0QBRPc6uECm_qn39bwy8jT0K3-eqVRLhvZbCdxPpv18yBHKOcqGDNt5w==";

        const string dockerUrl = "http://benchmark_influxdb:8086";
        const string localUrl = "http://localhost:8086";

        var options = new InfluxDBClientOptions(UsingDocker ? dockerUrl : localUrl)
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
        const string dockerUrl = "mongodb://root:root@benchmark_mongodb:27017";
        const string localUrl = "mongodb://root:root@localhost:27017";

        const string db = "benchmark";
        const string collectionName = "reading";

        var service = new MongoService(UsingDocker ? dockerUrl : localUrl, db, collectionName);
        builder.Services.AddSingleton(service);
    }

    public static void AddRedis(WebApplicationBuilder builder)
    {
        const string dockerUrl = "redis://benchmark_redis_stack:6379";
        const string localUrl = "redis://localhost:6379";

        var service = new RedisService(UsingDocker ? dockerUrl : localUrl);
        builder.Services.AddSingleton(service);
    }
}