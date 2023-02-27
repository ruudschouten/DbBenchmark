using CouchDB.Driver.DependencyInjection;
using DbBenchmark.CouchDb;
using DbBenchmark.InfluxDb;
using InfluxDB.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CouchDb
// builder.Services.AddTransient<CouchService>();
// builder.Services.AddCouchContext<DbBenchmark.CouchDb.Context>(optionsBuilder => optionsBuilder 
//     .UseEndpoint("http://localhost:5984")
//     .EnsureDatabaseExists()
//     .UseBasicAuthentication("root", "root"));

// InfluxDb
var token = ""; // Retrieve this from the Influx dashboard.

var options = new InfluxDBClientOptions("http://localhost:8086")
{
    Token = token,
    Bucket = "benchmark",
    Org = "benchmark"
};
var model = new InfluxService(options);
builder.Services.AddSingleton(model);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();