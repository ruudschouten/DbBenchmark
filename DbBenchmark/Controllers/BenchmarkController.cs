using DbBenchmark.CouchDb;
using DbBenchmark.Fakers;
using DbBenchmark.InfluxDb;
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

    public BenchmarkController(
        CouchService couchService,
        InfluxService influxService
    )
    {
        _couch = couchService;
        _couchFaker = new CouchReadingFaker();

        _influx = influxService;
        _influxFaker = new InfluxReadingFaker();
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
}