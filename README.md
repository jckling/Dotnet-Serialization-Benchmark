# dotnet-serialization-benchmark

Environment

- macOS 13.2
- Apple M1 Pro
- Unity2021.3.18f1

Scenarios

1. Console App (.Net 7.0) + [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)
2. Unity Demo (.NET Standard 2.1) + [Unity Profiler](https://docs.unity3d.com/Manual/Profiler.html)

Criteria

- Execution time
- Memory allocation
- CPU usage
- GC

Libraries

- [System.Text.Json.JsonSerializer](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializer?view=net-7.0)
- [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)
- [NetJSON](https://github.com/rpgmaker/NetJSON)
- [protobuf-net](https://github.com/protobuf-net/protobuf-net)
- [Utf8Json](https://github.com/neuecc/Utf8Json)
- [LitJSON](https://github.com/LitJSON/litjson)
- [MessagePack](https://github.com/neuecc/MessagePack-CSharp)
- [BinaryFormatter](https://learn.microsoft.com/en-us/dotnet/standard/serialization/binary-serialization) (obsolete)
- [JsonUtility](https://docs.unity3d.com/ScriptReference/JsonUtility.html) (Unity Scripting API)

Other Candidates

- [Odin](https://github.com/TeamSirenix/odin-serializer)
- [Bond](https://github.com/microsoft/bond/)
- [Swifter.Json](https://github.com/Dogwei/Swifter.Json)

## Data Types

See [Models](./DotnetSerializationBenchmark/DotnetSerializationBenchmark/Models/) and [Test.cs](./Test.cs).

## Results

See [results](./results/).

## Limitations

Some [BenchmarkDotNet Diagnosers](https://github.com/dotnet/BenchmarkDotNet/blob/master/docs/articles/configs/diagnosers.md) only support Windows.

## Reference

- [JSON Serialization Libraries Performance Tests](https://medium.com/justeattakeaway-tech/json-serialization-libraries-performance-tests-b54cbb3cccbb)
