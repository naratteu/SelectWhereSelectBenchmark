```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.3930/22H2/2022Update)
Intel Core i7-10700K CPU 3.80GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]               : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  .NET 6.0             : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  .NET 7.0             : .NET 7.0.14 (7.0.1423.51910), X64 RyuJIT AVX2
  .NET 8.0             : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  .NET Framework 4.8.1 : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256


```
| Method   | Job                  | Runtime              | Mean     | Error    | StdDev   | Gen0     | Gen1     | Gen2     | Allocated |
|--------- |--------------------- |--------------------- |---------:|---------:|---------:|---------:|---------:|---------:|----------:|
| query    | .NET 6.0             | .NET 6.0             | 72.10 ms | 0.188 ms | 0.166 ms | 285.7143 | 285.7143 | 285.7143 |   6.39 MB |
| ramda    | .NET 6.0             | .NET 6.0             | 72.13 ms | 0.092 ms | 0.081 ms | 285.7143 | 285.7143 | 285.7143 |   6.39 MB |
| tuple    | .NET 6.0             | .NET 6.0             | 72.39 ms | 0.423 ms | 0.375 ms | 285.7143 | 285.7143 | 285.7143 |   6.39 MB |
| destruct | .NET 6.0             | .NET 6.0             | 82.50 ms | 0.282 ms | 0.264 ms | 285.7143 | 285.7143 | 285.7143 |   6.39 MB |
| query    | .NET 7.0             | .NET 7.0             | 69.41 ms | 0.242 ms | 0.226 ms | 250.0000 | 250.0000 | 250.0000 |   6.39 MB |
| ramda    | .NET 7.0             | .NET 7.0             | 68.21 ms | 0.236 ms | 0.220 ms | 285.7143 | 285.7143 | 285.7143 |   6.39 MB |
| tuple    | .NET 7.0             | .NET 7.0             | 69.94 ms | 0.208 ms | 0.184 ms | 250.0000 | 250.0000 | 250.0000 |   6.39 MB |
| destruct | .NET 7.0             | .NET 7.0             | 80.98 ms | 0.289 ms | 0.270 ms | 285.7143 | 285.7143 | 285.7143 |   6.39 MB |
| query    | .NET 8.0             | .NET 8.0             | 47.66 ms | 0.143 ms | 0.127 ms | 200.0000 | 200.0000 | 200.0000 |   6.39 MB |
| ramda    | .NET 8.0             | .NET 8.0             | 47.55 ms | 0.182 ms | 0.171 ms | 200.0000 | 200.0000 | 200.0000 |   6.39 MB |
| tuple    | .NET 8.0             | .NET 8.0             | 57.39 ms | 0.216 ms | 0.202 ms | 222.2222 | 222.2222 | 222.2222 |   6.39 MB |
| destruct | .NET 8.0             | .NET 8.0             | 56.64 ms | 0.163 ms | 0.145 ms | 222.2222 | 222.2222 | 222.2222 |   6.39 MB |
| query    | .NET Framework 4.8.1 | .NET Framework 4.8.1 | 99.05 ms | 0.215 ms | 0.201 ms | 666.6667 | 666.6667 | 666.6667 |  10.39 MB |
| ramda    | .NET Framework 4.8.1 | .NET Framework 4.8.1 | 98.85 ms | 0.404 ms | 0.378 ms | 666.6667 | 666.6667 | 666.6667 |  10.39 MB |
| tuple    | .NET Framework 4.8.1 | .NET Framework 4.8.1 | 78.87 ms | 0.384 ms | 0.320 ms | 571.4286 | 571.4286 | 571.4286 |  10.39 MB |
| destruct | .NET Framework 4.8.1 | .NET Framework 4.8.1 | 81.59 ms | 0.383 ms | 0.358 ms | 571.4286 | 571.4286 | 571.4286 |  10.39 MB |
