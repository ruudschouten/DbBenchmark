using CouchDB.Driver;
using CouchDB.Driver.Options;

namespace DbBenchmark.CouchDb;

public class CouchDbContext : CouchContext
{
    public CouchDbContext(CouchOptions<CouchDbContext> options)
        : base(options)
    {
    }

    public CouchDatabase<CouchReading> Readings { get; set; } = null!;
}