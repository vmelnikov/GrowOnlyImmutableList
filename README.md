# GrowOnlyImmutableList


[![NuGet](https://img.shields.io/nuget/v/GrowOnlyImmutableList.svg)](https://www.nuget.org/packages/GrowOnlyImmutableList)
[![NuGet](https://img.shields.io/nuget/dt/GrowOnlyImmutableList.svg)](https://www.nuget.org/packages/GrowOnlyImmutableList)


### GrowOnlyImmutableList

GrowOnlyImmutableList is a thread safe immutable list of objects that can be accessed by index. 
It is much faster than ImmutableList and ImmutableArray in add operations and it has the same performance as ImmutableArray in read, indexed scenarios.

``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.2.1 (21D62) [Darwin 21.3.0]
Apple M1 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|                         Method |            Mean |         Error |        StdDev |       Gen 0 |       Gen 1 |       Gen 2 |        Allocated |
|------------------------------- |----------------:|--------------:|--------------:|------------:|------------:|------------:|-----------------:|
|      GrowOnlyImmutableList_Add |     1,705.44 μs |      2.785 μs |      2.605 μs |   1791.0156 |    203.1250 |    199.2188 |      4,249,302 B |
|                       List_Add |       301.59 μs |      4.711 μs |      5.236 μs |     99.1211 |     38.0859 |     36.6211 |      1,049,096 B |
|              ImmutableList_Add |    47,382.58 μs |    340.976 μs |    318.949 μs |  30454.5455 |   1363.6364 |    181.8182 |     82,508,792 B |
|             ImmutableArray_Add | 5,629,480.73 μs | 59,710.946 μs | 55,853.656 μs | 773000.0000 | 347000.0000 | 347000.0000 | 20,002,728,576 B |
| GrowOnlyImmutableList_AddRange |       509.50 μs |      1.165 μs |      1.033 μs |    382.8125 |    150.3906 |    132.8125 |      1,450,636 B |
|                  List_AddRange |       270.35 μs |      5.574 μs |     16.347 μs |     82.7637 |     26.6113 |     24.1699 |      1,020,264 B |
|         ImmutableList_AddRange |     5,468.67 μs |     20.652 μs |     18.307 μs |   1546.8750 |    617.1875 |    117.1875 |      4,912,838 B |
|        ImmutableArray_AddRange |     4,720.04 μs |     54.369 μs |     48.196 μs |    781.2500 |    351.5625 |    351.5625 |     20,202,715 B |
|      GrowOnlyImmutableList_For |        51.40 μs |      0.160 μs |      0.150 μs |           - |           - |           - |                - |
|                       List_For |        55.91 μs |      0.013 μs |      0.011 μs |           - |           - |           - |                - |
|              ImmutableList_For |     3,655.11 μs |      0.981 μs |      0.917 μs |           - |           - |           - |              3 B |
|             ImmutableArray_For |        55.93 μs |      0.231 μs |      0.216 μs |           - |           - |           - |                - |
|  GrowOnlyImmutableList_Foreach |        60.11 μs |      0.049 μs |      0.045 μs |           - |           - |           - |                - |
|                   List_Foreach |       191.57 μs |      0.111 μs |      0.099 μs |           - |           - |           - |                - |
|          ImmutableList_Foreach |     1,086.72 μs |      2.742 μs |      2.564 μs |           - |           - |           - |              2 B |
|         ImmutableArray_Foreach |        55.12 μs |      0.025 μs |      0.024 μs |           - |           - |           - |                - |
