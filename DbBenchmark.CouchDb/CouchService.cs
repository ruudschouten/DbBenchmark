namespace DbBenchmark.CouchDb;

public class CouchService
{
    private Context _context;
    
    public CouchService(Context context)
    {
        _context = context;
    }

    public async Task<CouchReading> Save(CouchReading reading)
    {
        return await _context.Readings.AddAsync(reading);
    }
}