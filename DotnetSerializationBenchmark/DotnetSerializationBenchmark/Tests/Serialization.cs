using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using Bogus;
using DotnetSerializationBenchmark.Models;

namespace DotnetSerializationBenchmark.Tests
{
    //[SimpleJob(RuntimeMoniker.NetCoreApp21, baseline: true)]
    //[SimpleJob(RuntimeMoniker.NetCoreApp21)]
    //[SimpleJob(RuntimeMoniker.Net60)]
    //[SimpleJob(RuntimeMoniker.Net70)]
    [MemoryDiagnoser]
    //[InliningDiagnoser]   // Windows only
    //[TailCallDiagnoser]   // Windows only
    [CsvExporter]
    [HtmlExporter]
    [MarkdownExporterAttribute.GitHub]
    //[RPlotExporter]
    public class Serialization
	{
		private BuiltInClass _obj = null;

        [Params(10, 20, 50, 100)]
        public int N;

		[GlobalSetup]
		public void setup()
		{
            Randomizer.Seed = new System.Random(8675309);
			_obj = new BuiltInClassFaker(N).Generate();
        }

        /* String format */

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

        [Benchmark]
        public string Utf8JSON()
        {
            return Utf8Json.JsonSerializer.ToJsonString(_obj);
        }

        [Benchmark]
        public string LitJSON()
        {
            return LitJson.JsonMapper.ToJson(_obj);
        }

        [Benchmark]
        public string MessagePackS()
        {
            return MessagePack.MessagePackSerializer.SerializeToJson(_obj);
            //return MessagePack.MessagePackSerializer.ConvertToJson(MessagePack.MessagePackSerializer.Serialize(_obj));
        }

        /* Binary format */

        //[Benchmark]
        //public string SystemBinaryFormatter()
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        IFormatter formatter = new BinaryFormatter();
        //        formatter.Serialize(ms, _obj);  // risks: https://learn.microsoft.com/en-us/dotnet/standard/serialization/binaryformatter-security-guide
        //        return Convert.ToBase64String(ms.ToArray());
        //    }
        //}

        [Benchmark]
        public byte[] ProtobufNetB()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, _obj);
                return ms.ToArray();
            }
        }

        [Benchmark]
        public byte[] Utf8JSONB()
        {
            return Utf8Json.JsonSerializer.Serialize(_obj);
        }

        [Benchmark]
        public byte[] MessagePackB()
        {
            return MessagePack.MessagePackSerializer.Serialize(_obj);
        }
    }
}

