using System;

using Prometheus.Client.Collectors.Abstractions;
using Prometheus.Client.MetricsWriter;

namespace Prometheus.Client.Collectors.DotNetStats
{
    public class GCCollectionCountCollector : ICollector
    {
        private static readonly string[] _labels = new string[] { "generation" };
        private static readonly string _help = "GC collection count";

        public string Name => "dotnet_collection_count_total";

        public string[] LabelNames => _labels;

        public void Collect(IMetricsWriter writer)
        {
            writer.WriteMetricHeader(Name, Contracts.CMetricType.Counter, _help);

            for (var gen = 0; gen <= GC.MaxGeneration; gen++)
            {
                writer.StartSample()
                    .StartLabels()
                    .WriteLabel("generation", gen.ToString())
                    .EndLabels()
                    .WriteValue(GC.CollectionCount(gen));
            }
        }
    }
}
