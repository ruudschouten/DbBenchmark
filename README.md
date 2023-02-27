# DbBenchmark

Before a benchmark can run, an agent needs to be available to run the application.
You can launch one locally by using;

```shell
dotnet crank-agent 
```

But it would be best if this agent was running on a different system so running programs on the "host" doesn't impact the benchmark.

Running benchmarks;

**CouchDB**
```shell
dotnet crank --config .\BenchmarkFiles\couchdb.yml --scenario bomb --profile local --json couchdb.json
```
