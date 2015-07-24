# TupleBenchmark
Considering different options for fixing bad performance of default tuple implementation

// BenchmarkDotNet=v0.7.6.0

// OS=Microsoft Windows NT 6.2.9200.0

// Processor=Intel(R) Core(TM) i5-2500K CPU @ 3.30GHz, ProcessorCount=4

// CLR=MS.NET 4.0.30319.42000, Arch=64-bit  [RyuJIT] Common:  Type=Program  Mode=Throughput  Platform=CurrentPlatform  Jit=LegacyJit  .NET=Current


                            Method |   AvrTime |      StdDev |        op/s |
---------------------------------- |---------- |------------ |------------ |
              CachedComparerEquals |  11.44 ns | 0.000000 ns | 87426286.81 |
         CachedComparerGetHashCode |  10.38 ns | 0.000000 ns |  96364073.5 |
             DictionaryContainsKey | 148.56 ns | 0.000000 ns |  6731359.06 |
                      DirectEquals |   7.38 ns | 0.000000 ns | 135421294.8 |
                ImpovedTupleEquals |  10.96 ns | 0.000000 ns | 91261485.71 |
  ImpovedTupleEqualsCachedComparer |  18.49 ns | 0.000000 ns | 54071661.64 |
           ImpovedTupleGetHashCode |  19.74 ns | 0.000000 ns | 50648594.11 |
     ImprovedDictionaryContainsKey |  58.01 ns | 0.000000 ns | 17239708.56 |
       StructDictionaryContainsKey |  56.39 ns | 0.000000 ns | 17732918.81 |
                 StructTupleEquals |  11.68 ns | 0.000000 ns |  85636455.9 |
   StructTupleEqualsCachedComparer |  20.58 ns | 0.000000 ns |  48583840.5 |
 StructTupleEqualsExplicitComparer |  16.68 ns | 0.000000 ns | 59935080.81 |
            StructTupleGetHashCode |  10.44 ns | 0.000000 ns | 95825992.15 |
                       TupleEquals |  58.21 ns | 0.000000 ns | 17178833.33 |
                  TupleGetHashCode |  66.50 ns | 0.000000 ns | 15038381.94 |
