using BenchmarkDotNet.Running;

namespace Prometheus.Client.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

            //var b = new SerializationBenchmarks();
            //b.GenerateData();
            //b.CollectAndSerialize().GetAwaiter().GetResult();
            //System.Threading.Thread.Sleep(5000);

            //b.CollectAndSerialize().GetAwaiter().GetResult();
        }
    }
}
