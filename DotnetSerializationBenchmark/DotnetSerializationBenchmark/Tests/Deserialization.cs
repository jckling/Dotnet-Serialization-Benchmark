using BenchmarkDotNet.Attributes;
using Bogus;
using DotnetSerializationBenchmark.Models;
using Newtonsoft.Json;

namespace DotnetSerializationBenchmark.Tests
{
    [MemoryDiagnoser]
    [PlainExporter]
    [HtmlExporter]
    [RPlotExporter]
    public class Deserialization
	{
        private string _outputSystemJson = null;
        private string _outputJsonNet = null;
        private string _outputNetJson = null;
        private string _outputProtobufNet = null;

        [GlobalSetup]
        public void setup()
        {
            Randomizer.Seed = new System.Random(8675309);
            var faker = new Faker("en");
            var obj = new BuiltInClassFaker(10).Generate();

            _outputSystemJson = System.Text.Json.JsonSerializer.Serialize(obj);
            _outputJsonNet = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            _outputNetJson = NetJSON.NetJSON.Serialize(obj);
            using (MemoryStream ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, obj);
                _outputProtobufNet = Convert.ToBase64String(ms.ToArray());
            }
        }

        [Benchmark]
        public BuiltInClass SystemJsonSerializer()
        {
            return System.Text.Json.JsonSerializer.Deserialize<BuiltInClass>(_outputSystemJson);
        }

        [Benchmark]
        public BuiltInClass JsonNet()
        {
            return JsonConvert.DeserializeObject<BuiltInClass>(_outputJsonNet);
        }

        [Benchmark]
        public BuiltInClass NetJson()
        {
            return NetJSON.NetJSON.Deserialize<BuiltInClass>(_outputNetJson);
        }

        [Benchmark]
        public BuiltInClass ProtobufNet()
        {
            byte[] arr = Convert.FromBase64String(_outputProtobufNet);
            using (MemoryStream ms = new MemoryStream(arr))
            {
                return ProtoBuf.Serializer.Deserialize<BuiltInClass>(ms);
            }
        }
    }
}

