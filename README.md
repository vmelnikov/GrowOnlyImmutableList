# GrowOnlyImmutableList

``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.2.1 (21D62) [Darwin 21.3.0]
Apple M1 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|                        Method |            Mean |          Error |         StdDev |       Gen 0 |       Gen 1 |       Gen 2 |        Allocated |
|------------------------------ |----------------:|---------------:|---------------:|------------:|------------:|------------:|-----------------:|
|     GrowOnlyImmutableList_Add |     2,273.91 μs |      25.644 μs |      21.414 μs |   1789.0625 |    207.0313 |    199.2188 |      4,249,253 B |
|                      List_Add |       306.39 μs |       5.679 μs |       6.540 μs |     97.1680 |     35.6445 |     34.6680 |      1,049,076 B |
|             ImmutableList_Add |    47,731.71 μs |     565.733 μs |     472.412 μs |  30000.0000 |   1100.0000 |    100.0000 |     82,508,744 B |
|            ImmutableArray_Add | 5,583,197.00 μs | 107,930.955 μs | 100,958.682 μs | 787000.0000 | 361000.0000 | 361000.0000 | 20,002,775,928 B |
|     GrowOnlyImmutableList_For |        51.64 μs |       0.158 μs |       0.140 μs |           - |           - |           - |                - |
|                      List_For |        56.16 μs |       0.113 μs |       0.106 μs |           - |           - |           - |                - |
|             ImmutableList_For |     3,663.04 μs |       4.347 μs |       3.630 μs |           - |           - |           - |              1 B |
|            ImmutableArray_For |        56.05 μs |       0.160 μs |       0.150 μs |           - |           - |           - |                - |
| GrowOnlyImmutableList_Foreach |        60.49 μs |       0.107 μs |       0.100 μs |           - |           - |           - |                - |
|                  List_Foreach |        76.27 μs |       0.096 μs |       0.090 μs |           - |           - |           - |                - |
|         ImmutableList_Foreach |     1,083.59 μs |       2.276 μs |       2.018 μs |           - |           - |           - |              2 B |
|        ImmutableArray_Foreach |        55.26 μs |       0.177 μs |       0.157 μs |           - |           - |           - |                - |