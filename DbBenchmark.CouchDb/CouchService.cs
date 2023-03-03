using CouchDB.Driver.Extensions;

namespace DbBenchmark.CouchDb;

public class CouchService
{
    private readonly CouchDbContext _couchDbContext;

    public CouchService(CouchDbContext couchDbContext)
    {
        _couchDbContext = couchDbContext;
    }

    public Task Save(CouchReading reading)
    {
        return _couchDbContext.Readings.AddAsync(reading);
    }

    public Task<List<CouchReading>> GetBetween(DateTime from, DateTime to)
    {
        return _couchDbContext.Readings
            .Where(reading => reading.TimeStamp >= from && reading.TimeStamp <= to)
            .Take(50)
            .ToListAsync();
    }
}