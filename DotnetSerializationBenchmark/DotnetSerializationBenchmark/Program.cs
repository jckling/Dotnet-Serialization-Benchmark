using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using Bogus;
using DotnetSerializationBenchmark.Models;
using DotnetSerializationBenchmark.Tests;

namespace DotnetSerializationBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            RunBenchmarks();
        }

        public static void RunBenchmarks()
        {
            var config = new ManualConfig()
                .WithOptions(ConfigOptions.DisableOptimizationsValidator)
                .AddValidator(JitOptimizationsValidator.DontFailOnError)
                .AddLogger(ConsoleLogger.Default)
                .AddColumnProvider(DefaultColumnProviders.Instance);

            var serializationSummary = BenchmarkRunner.Run<Serialization>(config);

            var deserializationSummary = BenchmarkRunner.Run<Deserialization>(config);
        }

        public static void TestNetJSON()
        {
            Randomizer.Seed = new System.Random(8675309);
            var faker = new Faker("en");
            var obj = new BuiltInClassFaker(10).Generate();
            var output = NetJSON.NetJSON.Serialize(obj);
            var newObj = NetJSON.NetJSON.Deserialize<BuiltInClass>(output);
            Console.WriteLine(newObj);
        }
    }
}