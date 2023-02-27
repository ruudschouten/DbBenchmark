using CouchDB.Driver.DependencyInjection;
using DbBenchmark.CouchDb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CouchDb
builder.Services.AddTransient<CouchService>();
builder.Services.AddCouchContext<DbBenchmark.CouchDb.Context>(optionsBuilder => optionsBuilder 
    .UseEndpoint("http://localhost:5984")
    .EnsureDatabaseExists()
    .UseBasicAuthentication("root", "root"));

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