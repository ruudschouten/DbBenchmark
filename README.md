# DbBenchmark

Before a benchmark can run, an agent needs to be available to run the application.

All databases are present in the `docker.compose.yml` file, which can be booted up by simply typing `docker compose up`.

> **Note**
> The database data is stored in the `DbBenchmark.Container` folder, which will be put in the parent directory of where
> you place this solution.
> This was done to get `dotnet crank` working, which would otherwise crash since it couldn't move the container folders.

You can launch one locally by using;

```shell
dotnet crank-agent 
```

But it would be best if this agent was running on a different system so running programs on the "host" doesn't impact
the benchmark.

Running benchmarks;

**CouchDB**

```shell
dotnet crank --config .\BenchmarkFiles\couchdb.yml --scenario bomb --profile local --json couchdb.json
```
```shell
dotnet crank --config .\BenchmarkFiles\couchdb_get.yml --scenario bomb --profile local --json couchdb.json
```

**InfluxDB**

```shell
dotnet crank --config .\BenchmarkFiles\influxdb.yml --scenario bomb --profile local --json influxdb.json
```
```shell
dotnet crank --config .\BenchmarkFiles\influxdb_get.yml --scenario bomb --profile local --json influxdb.json
```

**MongoDb**

```shell
dotnet crank --config .\BenchmarkFiles\mongodb.yml --scenario bomb --profile local --json mongodb.json
```
```shell
dotnet crank --config .\BenchmarkFiles\mongodb_get.yml --scenario bomb --profile local --json mongodb.json
```

**Redis**

```shell
dotnet crank --config .\BenchmarkFiles\redis.yml --scenario bomb --profile local --json redis.json
```
```shell
dotnet crank --config .\BenchmarkFiles\redis_get.yml --scenario bomb --profile local --json redis.json
```
