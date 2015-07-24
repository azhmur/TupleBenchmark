# TupleBenchmark
Considering different options for fixing bad performance of default tuple implementation

// BenchmarkDotNet=v0.7.6.0
// OS=Microsoft Windows NT 6.2.9200.0
// Processor=Intel(R) Core(TM) i5-2500K CPU @ 3.30GHz, ProcessorCount=4
// CLR=MS.NET 4.0.30319.42000, Arch=64-bit  [RyuJIT] Common:  Type=Program  Mode=Throughput  Platform=CurrentPlatform  Jit=CurrentJit .NET=Current

                            Method |   AvrTime |      StdDev |         op/s |
---------------------------------- |---------- |------------ |------------- |
              CachedComparerEquals |  10.48 ns | 0.000000 ns |   95399996.7 |
         CachedComparerGetHashCode |  10.46 ns | 0.000000 ns |  95614492.23 |
             DictionaryContainsKey | 148.81 ns | 0.000000 ns |   6719985.65 |
                      DirectEquals |   8.10 ns | 0.000000 ns | 123518670.06 |
                ImpovedTupleEquals |   9.05 ns | 0.000000 ns | 110515282.49 |
  ImpovedTupleEqualsCachedComparer |  17.44 ns | 0.000000 ns |  57340141.58 |
           ImpovedTupleGetHashCode |  16.71 ns | 0.000000 ns |  59841021.61 |
     ImprovedDictionaryContainsKey |  51.10 ns | 0.000000 ns |  19570399.66 |
       StringDictionaryContainsKey |  21.77 ns | 0.000000 ns |   45926977.5 |
       StructDictionaryContainsKey |  51.93 ns | 0.000000 ns |  19258467.27 |
                 StructTupleEquals |   9.06 ns | 0.000000 ns | 110349664.41 |
   StructTupleEqualsCachedComparer |  24.24 ns | 0.000000 ns |     41248275 |
 StructTupleEqualsExplicitComparer |  23.14 ns | 0.000000 ns |  43215868.99 |
            StructTupleGetHashCode |  10.14 ns | 0.000000 ns |  98576565.65 |
                       TupleEquals |  56.30 ns | 0.000000 ns |  17761076.09 |
                  TupleGetHashCode |  64.29 ns | 0.000000 ns |  15554005.74 |
