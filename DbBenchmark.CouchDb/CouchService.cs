﻿namespace DbBenchmark.CouchDb;

public class CouchService
{
    private readonly CouchDbContext _couchDbContext;

    public CouchService(CouchDbContext couchDbContext)
    {
        _couchDbContext = couchDbContext;
    }

    public Task<CouchReading> Save(CouchReading reading)
    {
        return _couchDbContext.Readings.AddAsync(reading);
    }
}