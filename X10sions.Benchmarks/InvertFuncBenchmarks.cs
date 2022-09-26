using BenchmarkDotNet.Attributes;
using System.Linq.Expressions;

namespace X10sions.Benchmarks
{
    [MemoryDiagnoser(false)]
    public class InvertFuncBenchmarks
    {
        public readonly Func<bool> True = () => true;
        public readonly Func<object?, bool> IsNull = (o) => o is null;

        public delegate bool Inverted();

        public delegate bool InvertedT1<T>(T arg);

        [Benchmark]
        public Func<bool> CompiledExpression()
        {
            var constant = Expression.Constant(True.Target);
            var call = Expression.Call(constant, True.Method);
            var not = Expression.Not(call);
            var lambda = Expression.Lambda<Func<bool>>(not);
            var compiled = lambda.Compile();

            return compiled;
        }

        [Benchmark]
        public Func<bool> NegatedInvoke()
        {
            return () => !True();
        }

        [Benchmark]
        public Func<bool> NamedFunction()
        {
            return Invert(True);
        }

        [Benchmark]
        public Inverted NamedDelegate()
        {
            return new Inverted(() => !True());
        }

        [Benchmark]
        public Func<object?, bool> CompiledExpressionWithArg()
        {
            var parameters = IsNull.Method.GetParameters();
            var expressions = parameters.Select(p => Expression.Parameter(p.ParameterType, p.Name)).ToArray();
            var constant = Expression.Constant(IsNull.Target);
            var call = Expression.Call(constant, IsNull.Method, expressions);
            var not = Expression.Not(call);
            var lambda = Expression.Lambda<Func<object?, bool>>(not, expressions);
            var compiled = lambda.Compile();

            return compiled;
        }

        [Benchmark]
        public Func<object?, bool> NegatedInvokeWithArg()
        {
            return (o) => !IsNull(o);
        }

        [Benchmark]
        public Func<object?, bool> NamedFunctionWithArg()
        {
            return Invert(IsNull);
        }

        [Benchmark]
        public InvertedT1<object?> NamedDelegateWithArg()
        {
            return new InvertedT1<object?>((o) => !IsNull(o));
        }

        [Benchmark]
        public Predicate<object?> PredicateWithArg()
        {
            return new Predicate<object?>((o) => !IsNull(o));
        }

        private static Func<bool> Invert(Func<bool> func)
        {
            return () => !func();
        }

        private static Func<T, bool> Invert<T>(Func<T, bool> func)
        {
            return (arg) => !func(arg);
        }
    }
}