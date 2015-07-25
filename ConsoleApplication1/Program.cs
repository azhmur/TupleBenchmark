using BenchmarkDotNet;
using BenchmarkDotNet.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [Task(warmupIterationCount: 1, targetIterationCount:1, processCount:1, jitVersion: BenchmarkJitVersion.CurrentJit)]
    public class Program
    {
        private string str1 = "xxxxxxx1";
        private int i1 = 1123;

        private string str2 = "xxxxxxx2";
        private int i2 = 1123;

        private Tuple<string, int> tuple1;
        private Tuple<string, int> tuple2;

        private StructTuple<string, int> stuple1;
        private StructTuple<string, int> stuple2;

        private ImprovedTuple<string, int> ituple1;
        private ImprovedTuple<string, int> ituple2;

        private IEqualityComparer<string> stringComparer = EqualityComparer<string>.Default;
        private EqualityComparer<int> intComparer = EqualityComparer<int>.Default;
        private EqualityComparer<StructTuple<string, int>> sComparer = EqualityComparer<StructTuple<string, int>>.Default;
        private IEqualityComparer<StructTuple<string, int>> sComparer2 = new StructTupleComparer<string, int>();
        private IEqualityComparer<ImprovedTuple<string, int>> iComparer = EqualityComparer<ImprovedTuple<string, int>>.Default;

        private Dictionary<Tuple<string, int>, Tuple<string, int>> dict = new Dictionary<Tuple<string, int>, Tuple<string, int>>();
        private Dictionary<ImprovedTuple<string, int>, ImprovedTuple<string, int>> idict = new Dictionary<ImprovedTuple<string, int>, ImprovedTuple<string, int>>();
        private Dictionary<StructTuple<string, int>, StructTuple<string, int>> sdict = new Dictionary<StructTuple<string, int>, StructTuple<string, int>>();
        private Dictionary<string, string> strdict = new Dictionary<string, string>();
        private Dictionary<ImprovedTuple<string, int>, ImprovedTuple<string, int>> idictBig;
        private Dictionary<StructTuple<string, int>, StructTuple<string, int>> sdictBig;
        private Dictionary<Tuple<string, int>, Tuple<string, int>> dictBig;

        public Program()
        {
            this.tuple2 = Tuple.Create(str2, i2);
            this.tuple1 = Tuple.Create(str1, i1);

            this.stuple1 = new StructTuple<string, int>(str1, i1);
            this.stuple2 = new StructTuple<string, int>(str2, i2);

            this.ituple1 = new ImprovedTuple<string, int>(str1, i1);
            this.ituple2 = new ImprovedTuple<string, int>(str2, i2);

            this.dict[tuple1] = tuple2;
            this.idict[ituple1] = ituple2;
            this.sdict[stuple1] = stuple2;
            this.strdict[str1] = str2;
            this.idictBig = new Dictionary<ImprovedTuple<string, int>, ImprovedTuple<string, int>>(4096, iComparer);
            this.sdictBig = new Dictionary<StructTuple<string, int>, StructTuple<string, int>>(4096, sComparer2);
            this.dictBig = new Dictionary<Tuple<string, int>, Tuple<string, int>>(4096, EqualityComparer<Tuple<string, int>>.Default);
            var rand = new Random(1234);
            for (int i = 0; i < 2048; i++)
            {
                idictBig.Add(new ImprovedTuple<string, int>(rand.Next().ToString(), i), new ImprovedTuple<string, int>(i.ToString(), i));
                sdictBig.Add(new StructTuple<string, int>(rand.Next().ToString(), i), new StructTuple<string, int>(i.ToString(), i));
                dictBig.Add(new Tuple<string, int>(rand.Next().ToString(), i), new Tuple<string, int>(i.ToString(), i));
            }
            idictBig.Add(ituple1, ituple2);
            sdictBig.Add(stuple1, stuple2);
            dictBig.Add(tuple1, tuple2);
        }

        static void Main(string[] args)
        {
            var comp = new BenchmarkCompetitionSwitch(new[] { typeof(Program) });
            comp.Run(args);
        }

        [Benchmark]
        public void TupleGetHashCode()
        {
            var val = tuple1.GetHashCode();
        }

        [Benchmark]
        public void StructTupleGetHashCode()
        {
            var val = stuple1.GetHashCode();
        }

        [Benchmark]
        public void ImpovedTupleGetHashCode()
        {
            var val = ituple1.GetHashCode();
        }

        [Benchmark]
        public void TupleEquals()
        {
            var val = tuple1.Equals(tuple2);
        }

        [Benchmark]
        public void StructTupleEquals()
        {
            var val = stuple1.Equals(stuple2);
        }

        [Benchmark]
        public void ImpovedTupleEquals()
        {
            var val = ituple1.Equals(ituple2);
        }

        [Benchmark]
        public void ImpovedTupleEqualsCachedComparer()
        {
            var val = iComparer.Equals(ituple1, ituple2);
        }

        [Benchmark]
        public void StructTupleEqualsCachedComparer()
        {
            var val = sComparer.Equals(stuple1, stuple2);
        }

        [Benchmark]
        public void StructTupleEqualsExplicitComparer()
        {
            var val = sComparer2.Equals(stuple1, stuple2);
        }

        [Benchmark]
        public void DirectEquals()
        {
            var eq = str1.Equals(str2) && i1.Equals(i2);
        }

        [Benchmark]
        public void CachedComparerEquals()
        {
            var eq = stringComparer.Equals(str1, str2) && intComparer.Equals(i1, i2);
        }

        [Benchmark]
        public void CachedComparerGetHashCode()
        {
            var h = stringComparer.GetHashCode(str1);
            var eq = (h << 5 - h) ^ intComparer.GetHashCode(i1);
        }

        [Benchmark]
        public void DictionaryContainsKey()
        {
            this.dict.ContainsKey(Tuple.Create(str1, i1));
        }

        [Benchmark]
        public void ImprovedDictionaryContainsKey()
        {
            this.idict.ContainsKey(new ImprovedTuple<string, int>(str1, i1));
        }

        [Benchmark]
        public void StructDictionaryContainsKey()
        {
            this.sdict.ContainsKey(new StructTuple<string, int>(str1, i1));
        }

        [Benchmark]
        public void DictionaryExpand()
        {
            this.dict[Tuple.Create(str1, ++i1)] = Tuple.Create(str2, ++i2);
        }

        [Benchmark]
        public void ImprovedDictionaryExpand()
        {
            this.idict[new ImprovedTuple<string, int>(str1, ++i1)] = new ImprovedTuple<string, int>(str2, ++i2);
        }

        [Benchmark]
        public void StructDictionaryExpand()
        {
            this.sdict[new StructTuple<string, int>(str1, ++i1)] = new StructTuple<string, int>(str2, ++i2);
        }

        [Benchmark]
        public void StringDictionaryContainsKey()
        {
            this.strdict.ContainsKey(str1);
        }

        [Benchmark]
        public void BigDictionaryContainsKey()
        {
            this.dictBig.ContainsKey(Tuple.Create(str1, i1));
        }

        [Benchmark]
        public void BigImprovedDictionaryContainsKey()
        {
            this.idictBig.ContainsKey(new ImprovedTuple<string, int>(str1, i1));
        }

        [Benchmark]
        public void BigStructDictionaryContainsKey()
        {
            this.sdictBig.ContainsKey(new StructTuple<string, int>(str1, i1));
        }
    }

    public sealed class StructTupleComparer<T1, T2> : IEqualityComparer<StructTuple<T1, T2>>
    {
        private static readonly EqualityComparer<T1> comparer1 = EqualityComparer<T1>.Default;
        private static readonly EqualityComparer<T2> comparer2 = EqualityComparer<T2>.Default;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public bool Equals(StructTuple<T1, T2> x, StructTuple<T1, T2> y)
        {
            return comparer1.Equals(x.Item1, y.Item1) && comparer2.Equals(x.Item2, y.Item2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public int GetHashCode(StructTuple<T1, T2> obj)
        {
            var h1 = comparer1.GetHashCode(obj.Item1);
            return (h1 << 5 - h1) ^ comparer2.GetHashCode(obj.Item2);
        }
    }

    public struct StructTuple<T1, T2> : IEquatable<StructTuple<T1, T2>>
    {
        private static readonly EqualityComparer<T1> comparer1 = EqualityComparer<T1>.Default;
        private static readonly EqualityComparer<T2> comparer2 = EqualityComparer<T2>.Default;

        
        public T1 Item1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; private set; }

        public T2 Item2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; private set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StructTuple(T1 item1, T2 item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public override bool Equals(object obj)
        {
            var other = (StructTuple<T1,T2>)obj;

            return comparer1.Equals(this.Item1, other.Item1) && comparer2.Equals(this.Item2, other.Item2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public bool Equals(StructTuple<T1, T2> other)
        {
            return comparer1.Equals(this.Item1, other.Item1) && comparer2.Equals(this.Item2, other.Item2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public override int GetHashCode()
        {
            var h1 = comparer1.GetHashCode(this.Item1);
            return (h1 << 5 - h1) ^ comparer2.GetHashCode(this.Item2);
        }
    }

    public sealed class ImprovedTuple<T1, T2> : IEquatable<ImprovedTuple<T1, T2>>
    {
        private static readonly EqualityComparer<T1> comparer1 = EqualityComparer<T1>.Default;
        private static readonly EqualityComparer<T2> comparer2 = EqualityComparer<T2>.Default;


        public T1 Item1 {[MethodImpl(MethodImplOptions.AggressiveInlining)] get; private set; }

        public T2 Item2 {[MethodImpl(MethodImplOptions.AggressiveInlining)] get; private set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ImprovedTuple(T1 item1, T2 item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public override bool Equals(object obj)
        {
            var other = (ImprovedTuple<T1, T2>)obj;

            return comparer1.Equals(this.Item1, other.Item1) && comparer2.Equals(this.Item2, other.Item2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public bool Equals(ImprovedTuple<T1, T2> other)
        {
            return comparer1.Equals(this.Item1, other.Item1) && comparer2.Equals(this.Item2, other.Item2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [Pure]
        public override int GetHashCode()
        {
            var h1 = comparer1.GetHashCode(this.Item1);
            return (h1 << 5 - h1) ^ comparer2.GetHashCode(this.Item2);
        }
    }
}
