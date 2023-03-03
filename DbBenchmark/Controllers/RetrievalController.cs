using DbBenchmark.CouchDb;
using DbBenchmark.InfluxDb;
using DbBenchmark.MongoDb;
using DbBenchmark.Redis;
using Microsoft.AspNetCore.Mvc;

namespace DbBenchmark.Controllers;

[ApiController]
[Route("[controller]")]
public class RetrievalController : ControllerBase
{
    private readonly CouchService _couch;

    private readonly InfluxService _influx;

    private readonly MongoService _mongo;

    private readonly RedisService _redis;

    private readonly DateTime _start = new DateTime(2023, 3, 3, 7, 0, 0);
    private readonly DateTime _end = new DateTime(2023, 3, 31, 23, 59, 59);

    public RetrievalController(
        CouchService couchService,
        InfluxService influxService,
        MongoService mongoService,
        RedisService redisService
    )
    {
        _couch = couchService;
        _influx = influxService;
        _mongo = mongoService;
        _redis = redisService;
    }

    [HttpGet("CouchDb")]
    public async Task<IActionResult> GetCouch()
    {
        return Ok(await _couch.GetBetween(_start, _end));
    }

    [HttpGet("Influx")]
    public async Task<IActionResult> GetInflux()
    {
        return Ok(await _influx.GetBetween(_start, _end));
    }

    [HttpGet("MongoDb")]
    public async Task<IActionResult> GetMongo()
    {
        return Ok(await _mongo.GetBetween(_start, _end));
    }

    [HttpGet("Redis")]
    public async Task<IActionResult> GetRedis()
    {
        return Ok(await _redis.GetBetween(_start, _end));
    }
}