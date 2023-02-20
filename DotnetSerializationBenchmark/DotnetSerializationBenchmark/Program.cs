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
            //Test();
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

        public static void Test()
        {
            Randomizer.Seed = new System.Random(8675309);
            var faker = new Faker("en");
            var obj = new BuiltInClassFaker(20).Generate();

            /* String format */

            //var output = System.Text.Json.JsonSerializer.Serialize(obj);
            //var newObj = System.Text.Json.JsonSerializer.Deserialize<BuiltInClass>(output);

            //var output = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            //var newObj = Newtonsoft.Json.JsonConvert.DeserializeObject<BuiltInClass>(output);

            //var output = NetJSON.NetJSON.Serialize(obj);
            //var newObj = NetJSON.NetJSON.Deserialize<BuiltInClass>(output);

            //string output = null;
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    ProtoBuf.Serializer.Serialize(ms, obj);
            //    output = Convert.ToBase64String(ms.ToArray());
            //}
            //BuiltInClass newObj = null;
            //byte[] arr = Convert.FromBase64String(output);
            //using (MemoryStream ms = new MemoryStream(arr))
            //{
            //    newObj = ProtoBuf.Serializer.Deserialize<BuiltInClass>(ms);
            //}

            //var output = LitJson.JsonMapper.ToJson(obj);
            //var newObj = LitJson.JsonMapper.ToObject<BuiltInClass>(output);

            var output = MessagePack.MessagePackSerializer.SerializeToJson(obj);
            //var output = MessagePack.MessagePackSerializer.ConvertToJson(MessagePack.MessagePackSerializer.Serialize(obj));
            var newObj = MessagePack.MessagePackSerializer.Deserialize<BuiltInClass>(MessagePack.MessagePackSerializer.ConvertFromJson(output));

            /* Binary format */

            //byte[] output = null;
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    ProtoBuf.Serializer.Serialize(ms, obj);
            //    output = ms.ToArray();
            //}
            //BuiltInClass newObj = null;
            //using (MemoryStream ms = new MemoryStream(output))
            //{
            //    newObj = ProtoBuf.Serializer.Deserialize<BuiltInClass>(ms);
            //}

            //var output = Utf8Json.JsonSerializer.Serialize(obj);
            //var newObj = Utf8Json.JsonSerializer.Deserialize<BuiltInClass>(output);

            //var output = MessagePack.MessagePackSerializer.Serialize(obj);
            //var newObj = MessagePack.MessagePackSerializer.Deserialize<BuiltInClass>(output);

            Console.WriteLine(output);
            Console.WriteLine(newObj);
        }
    }
}