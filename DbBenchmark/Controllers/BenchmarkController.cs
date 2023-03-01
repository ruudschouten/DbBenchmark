using DbBenchmark.CouchDb;
using DbBenchmark.InfluxDb;
using DbBenchmark.MongoDb;
using DbBenchmark.Redis;
using Microsoft.AspNetCore.Mvc;

namespace DbBenchmark.Controllers;

[ApiController]
[Route("[controller]")]
public class BenchmarkController : ControllerBase
{
    private readonly CouchService _couch;
    private readonly CouchReadingFaker _couchFaker;

    private readonly InfluxService _influx;
    private readonly InfluxReadingFaker _influxFaker;

    private readonly MongoService _mongo;
    private readonly MongoReadingFaker _mongoFaker;

    private readonly RedisService _redis;
    private readonly RedisReadingFaker _redisFaker;

    public BenchmarkController(
        CouchService couchService,
        InfluxService influxService,
        MongoService mongoService,
        RedisService redisService
    )
    {
        _couch = couchService;
        _couchFaker = new CouchReadingFaker();

        _influx = influxService;
        _influxFaker = new InfluxReadingFaker();

        _mongo = mongoService;
        _mongoFaker = new MongoReadingFaker();

        _redis = redisService;
        _redisFaker = new RedisReadingFaker();
    }

    [HttpGet("CouchDb")]
    public Task<CouchReading> SaveCouch()
    {
        return _couch.Save(_couchFaker.Generate());
    }

    [HttpGet("InfluxDb")]
    public Task SaveInflux()
    {
        return _influx.Save(_influxFaker.Generate());
    }

    [HttpGet("MongoDb")]
    public Task SaveMongo()
    {
        return _mongo.Save(_mongoFaker.Generate());
    }

    [HttpGet("Redis")]
    public Task SaveRedis()
    {
        return _redis.Save(_redisFaker.Generate());
    }
}