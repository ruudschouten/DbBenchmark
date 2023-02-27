using DbBenchmark.CouchDb;
using DbBenchmark.Fakers;
using Microsoft.AspNetCore.Mvc;

namespace DbBenchmark.Controllers;

[ApiController]
[Route("[controller]")]
public class BenchmarkController : ControllerBase
{
    private readonly CouchService _couch;
    private readonly CouchReadingFaker _couchFaker;

    public BenchmarkController(
        CouchService couchService
    )
    {
        _couch = couchService;
        _couchFaker = new CouchReadingFaker();
    }

    [HttpGet("CouchDb")]
    public Task<CouchReading> SaveCouch()
    {
        return _couch.Save(_couchFaker.Generate());
    }
}