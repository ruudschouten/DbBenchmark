using DbBenchmark.CouchDb;
using DbBenchmark.InfluxDb;
using DbBenchmark.MongoDb;
using DbBenchmark.Redis;
using Microsoft.AspNetCore.Mvc;
using RedisTimeSeries;

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

    private readonly RedisTimeSeriesService _redisTimeSeries;
    private readonly RedisTimeSeriesFaker _redisTimeSeriesFaker;

    public BenchmarkController(
        CouchService couchService,
        InfluxService influxService,
        MongoService mongoService,
        RedisService redisService,
        RedisTimeSeriesService redisTimeSeriesService
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

        _redisTimeSeries = redisTimeSeriesService;
        _redisTimeSeriesFaker = new RedisTimeSeriesFaker();
    }

    [HttpGet("CouchDb")]
    public async Task<IActionResult> SaveCouch()
    {
        await _couch.Save(_couchFaker.Generate());
        return Ok();
    }

    [HttpGet("InfluxDb")]
    public async Task<IActionResult> SaveInflux()
    {
        await _influx.Save(_influxFaker.Generate());
        return Ok();
    }

    [HttpGet("MongoDb")]
    public async Task<IActionResult> SaveMongo()
    {
        await _mongo.Save(_mongoFaker.Generate());
        return Ok();
    }

    [HttpGet("Redis")]
    public async Task<IActionResult> SaveRedis()
    {
        await _redis.Save(_redisFaker.Generate());
        return Ok();
    }

    [HttpGet("RedisTimeSeries")]
    public async Task<IActionResult> SaveRedisTimeSeries()
    {
        await _redisTimeSeries.Save(_redisTimeSeriesFaker.Generate());
        return Ok();
    }
}