# TupleBenchmark
Considering different options for fixing bad performance of default tuple implementation

// BenchmarkDotNet=v0.7.6.0

// OS=Microsoft Windows NT 6.1.7601 Service Pack 1

// Processor=Intel(R) Core(TM) i7-2600 CPU @ 3.40GHz, ProcessorCount=8

// CLR=MS.NET 4.0.30319.42000, Arch=64-bit  [RyuJIT] Common:  Type=Program  Mode=Throughput  Platform=CurrentPlatform  Jit=RyuJit  .NET=Current

                            Method |   AvrTime |      StdDev |         op/s |
---------------------------------- |---------- |------------ |------------- |
          BigDictionaryContainsKey | 179.97 ns | 0.000000 ns |   5556351.29 |
  BigImprovedDictionaryContainsKey |  58.85 ns | 0.000000 ns |  16992109.99 |
    BigStructDictionaryContainsKey |  57.45 ns | 0.000000 ns |  17407663.04 |
              CachedComparerEquals |  13.49 ns | 0.000000 ns |  74115330.91 |
         CachedComparerGetHashCode |  12.63 ns | 0.000000 ns |   79184921.1 |
             DictionaryContainsKey | 176.47 ns | 0.000000 ns |    5666589.6 |
                  DictionaryExpand | 348.90 ns | 0.000000 ns |   2866121.83 |
                      DirectEquals |   9.46 ns | 0.000000 ns | 105674608.21 |
                ImpovedTupleEquals |  11.78 ns | 0.000000 ns |   84897714.9 |
  ImpovedTupleEqualsCachedComparer |  20.15 ns | 0.000000 ns |  49616942.58 |
           ImpovedTupleGetHashCode |  20.23 ns | 0.000000 ns |  49420273.45 |
     ImprovedDictionaryContainsKey |  59.42 ns | 0.000000 ns |  16829961.01 |
          ImprovedDictionaryExpand | 199.97 ns | 0.000000 ns |   5000688.69 |
       StringDictionaryContainsKey |  25.84 ns | 0.000000 ns |  38703609.23 |
       StructDictionaryContainsKey |  63.07 ns | 0.000000 ns |  15854490.42 |
            StructDictionaryExpand | 109.49 ns | 0.000000 ns |   9133050.18 |
                 StructTupleEquals |  12.02 ns | 0.000000 ns |  83179495.61 |
   StructTupleEqualsCachedComparer |  28.08 ns | 0.000000 ns |  35615922.74 |
 StructTupleEqualsExplicitComparer |  26.68 ns | 0.000000 ns |  37482496.73 |
            StructTupleGetHashCode |  12.11 ns | 0.000000 ns |  82605493.66 |
                       TupleEquals |  72.22 ns | 0.000000 ns |  13847016.26 |
         TupleEqualsCachedComparer |  75.16 ns | 0.000000 ns |  13304597.74 |
                  TupleGetHashCode |  74.43 ns | 0.000000 ns |  13435734.25 |