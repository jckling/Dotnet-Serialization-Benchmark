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
    public class Deserialization
	{
        private string _outputSystemJson = null;
        private string _outputJsonNet = null;
        private string _outputNetJson = null;
        private string _outputProtobufNet = null;
        private byte[] _outputProtobufNetB = null;
        private string _outputUtf8Json = null;
        private byte[] _outputUtf8JsonB = null;
        private string _outputLitJson = null;
        private string _outputMessagePack = null;
        private byte[] _outputMessagePackB = null;

        [Params(10, 20, 50, 100)]
        public int N;

        [GlobalSetup]
        public void setup()
        {
            Randomizer.Seed = new System.Random(8675309);
            var obj = new BuiltInClassFaker(N).Generate();

            _outputSystemJson = System.Text.Json.JsonSerializer.Serialize(obj);
            _outputJsonNet = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            _outputNetJson = NetJSON.NetJSON.Serialize(obj);
            using (MemoryStream ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, obj);
                _outputProtobufNet = Convert.ToBase64String(ms.ToArray());
                _outputProtobufNetB = ms.ToArray();
            }
            _outputUtf8Json = Utf8Json.JsonSerializer.ToJsonString(obj);
            _outputUtf8JsonB = Utf8Json.JsonSerializer.Serialize(obj);
            _outputLitJson = LitJson.JsonMapper.ToJson(obj);
            _outputMessagePack = MessagePack.MessagePackSerializer.SerializeToJson(obj);
            //_outputMessagePack = MessagePack.MessagePackSerializer.ConvertToJson(MessagePack.MessagePackSerializer.Serialize(obj));
            _outputMessagePackB = MessagePack.MessagePackSerializer.Serialize(obj);
        }

        /* String format */

        [Benchmark]
        public BuiltInClass SystemJsonSerializer()
        {
            return System.Text.Json.JsonSerializer.Deserialize<BuiltInClass>(_outputSystemJson);
        }

        [Benchmark]
        public BuiltInClass JsonNet()
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<BuiltInClass>(_outputJsonNet);
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

        [Benchmark]
        public BuiltInClass Utf8JSON()
        {
            return Utf8Json.JsonSerializer.Deserialize<BuiltInClass>(System.Text.Encoding.UTF8.GetBytes(_outputUtf8Json));
        }

        [Benchmark]
        public BuiltInClass LitJSON()
        {
            return LitJson.JsonMapper.ToObject<BuiltInClass>(_outputLitJson);
        }

        [Benchmark]
        public BuiltInClass MessagePackS()
        {
            return MessagePack.MessagePackSerializer.Deserialize<BuiltInClass>(MessagePack.MessagePackSerializer.ConvertFromJson(_outputMessagePack));
        }

        /* Binary format */

        [Benchmark]
        public BuiltInClass ProtobufNetB()
        {
            using (MemoryStream ms = new MemoryStream(_outputProtobufNetB))
            {
                return ProtoBuf.Serializer.Deserialize<BuiltInClass>(ms);
            }
        }

        [Benchmark]
        public BuiltInClass Utf8JSONB()
        {
            return Utf8Json.JsonSerializer.Deserialize<BuiltInClass>(_outputUtf8JsonB);
        }

        [Benchmark]
        public BuiltInClass MessagePackB()
        {
            return MessagePack.MessagePackSerializer.Deserialize<BuiltInClass>(_outputMessagePackB);
        }
    }
}

