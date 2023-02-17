using BenchmarkDotNet.Attributes;
using Bogus;
using DotnetSerializationBenchmark.Models;

namespace DotnetSerializationBenchmark.Tests
{
    [MemoryDiagnoser]
    [PlainExporter]
    [HtmlExporter]
    [RPlotExporter]
    public class Serialization
	{
		private BuiltInClass _obj = null;

		[GlobalSetup]
		public void setup()
		{
            Randomizer.Seed = new System.Random(8675309);
            var faker = new Faker("en");
			_obj = new BuiltInClassFaker(10).Generate();
        }

		[Benchmark]
		public string SystemJsonSerializer()
		{
			return System.Text.Json.JsonSerializer.Serialize(_obj);
        }

		[Benchmark]
		public string JsonNet()
		{
			return Newtonsoft.Json.JsonConvert.SerializeObject(_obj);
		}

		[Benchmark]
		public string NetJson()
		{
			return NetJSON.NetJSON.Serialize(_obj);
        }

        [Benchmark]
        public string ProtobufNet()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, _obj);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }
}

