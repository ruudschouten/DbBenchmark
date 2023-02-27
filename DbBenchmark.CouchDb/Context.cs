using CouchDB.Driver;
using CouchDB.Driver.Options;

namespace DbBenchmark.CouchDb;

public class Context : CouchContext
{
    public CouchDatabase<CouchReading> Readings { get; set; }

    public Context(CouchOptions<Context> options)
        : base(options)
    {
    }
}