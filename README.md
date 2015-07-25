# TupleBenchmark
Considering different options for fixing bad performance of default tuple implementation

BenchmarkDotNet=v0.7.6.0

OS=Microsoft Windows NT 6.2.9200.0

Processor=Intel(R) Core(TM) i5-2500K CPU @ 3.30GHz, ProcessorCount=4

CLR=MS.NET 4.0.30319.42000, Arch=64-bit  [RyuJIT] Common:  Type=Program  Mode=Throughput  Platform=CurrentPlatform  Jit=CurrentJit .NET=Current

                            Method |   AvrTime |      StdDev |         op/s |
---------------------------------- |---------- |------------ |------------- |
              CachedComparerEquals |  11.20 ns | 0.000000 ns |  89294480.08 |
         CachedComparerGetHashCode |  10.48 ns | 0.000000 ns |  95386376.18 |
             DictionaryContainsKey | 151.60 ns | 0.000000 ns |   6596258.35 |
                  DictionaryExpand | 363.85 ns | 0.000000 ns |   2748395.26 |
                      DirectEquals |   7.86 ns | 0.000000 ns |  127242954.3 |
                ImpovedTupleEquals |  10.24 ns | 0.000000 ns |  97647843.96 |
  ImpovedTupleEqualsCachedComparer |  16.79 ns | 0.000000 ns |  59554545.99 |
           ImpovedTupleGetHashCode |  15.68 ns | 0.000000 ns |  63781604.12 |
     ImprovedDictionaryContainsKey |  49.47 ns | 0.000000 ns |  20215787.68 |
          ImprovedDictionaryExpand | 132.82 ns | 0.000000 ns |   7528829.86 |
       StringDictionaryContainsKey |  21.46 ns | 0.000000 ns |  46600174.53 |
       StructDictionaryContainsKey |  51.65 ns | 0.000000 ns |  19361292.02 |
            StructDictionaryExpand |  90.07 ns | 0.000000 ns |  11102336.58 |
                 StructTupleEquals |   9.77 ns | 0.000000 ns | 102362671.92 |
   StructTupleEqualsCachedComparer |  24.96 ns | 0.000000 ns |  40067949.52 |
 StructTupleEqualsExplicitComparer |  23.74 ns | 0.000000 ns |  42116043.34 |
            StructTupleGetHashCode |  11.96 ns | 0.000000 ns |  83609092.64 |
                       TupleEquals |  60.26 ns | 0.000000 ns |  16593525.13 |
         TupleEqualsCachedComparer |  61.91 ns | 0.000000 ns |   16151838.3 |
                  TupleGetHashCode |  65.07 ns | 0.000000 ns |  15366979.23 |
