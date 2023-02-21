using System;
using System.IO;
using System.Linq;
using Bogus;
using MessagePack;
using Newtonsoft.Json;
using ProtoBuf;
using ProtoBuf.Meta;
using UnityEditor;
using UnityEngine;
using UnityEngine.Profiling;

[MessagePackObject]
[ProtoContract]
[Serializable]
public class BuiltInClass
{
    [Key(1)]
    [ProtoMember(1)]
    public bool Bool { get; set; }
    [Key(2)]
    [ProtoMember(2)]
    public byte Byte { get; set; }
    [Key(3)]
    [ProtoMember(3)]
    public sbyte Sbyte { get; set; }
    [Key(4)]
    [ProtoMember(4)]
    public char Char { get; set; }
    [Key(5)]
    [ProtoMember(5)]
    public decimal Decimal { get; set; }
    [Key(6)]
    [ProtoMember(6)]
    public double Double { get; set; }
    [Key(7)]
    [ProtoMember(7)]
    public float Float { get; set; }
    [Key(8)]
    [ProtoMember(8)]
    public int Int { get; set; }
    [Key(9)]
    [ProtoMember(9)]
    public uint Uint { get; set; }
    [Key(10)]
    [ProtoMember(10)]
    public long Long { get; set; }
    [Key(11)]
    [ProtoMember(11)]
    public ulong Ulong { get; set; }
    [Key(12)]
    [ProtoMember(12)]
    public short Short { get; set; }
    [Key(13)]
    [ProtoMember(13)]
    public ushort Ushort { get; set; }

    //[Key(14)]
    //[ProtoMember(14)]
    //public bool[]? BoolArray { get; set; }
    //[Key(15)]
    //[ProtoMember(15)]
    //public byte[]? ByteArray { get; set; }
    [Key(16)]
    [ProtoMember(16)]
    public sbyte[]? SbyteArray { get; set; }
    //[Key(17)]
    //[ProtoMember(17)]
    //public char[]? CharArray { get; set; }
    [Key(18)]
    [ProtoMember(18)]
    public decimal[]? DecimalArray { get; set; }
    [Key(19)]
    [ProtoMember(19)]
    public double[]? DoubleArray { get; set; }
    [Key(20)]
    [ProtoMember(20)]
    public float[]? FloatArray { get; set; }
    [Key(21)]
    [ProtoMember(21)]
    public int[]? IntArray { get; set; }
    [Key(33)]
    [ProtoMember(22)]
    public uint[]? UintArray { get; set; }
    [Key(23)]
    [ProtoMember(23)]
    public long[]? LongArray { get; set; }
    //[Key(24)]
    //[ProtoMember(24)]
    //public ulong[]? UlongArray { get; set; }
    [Key(25)]
    [ProtoMember(25)]
    public short[]? ShortArray { get; set; }
    [Key(26)]
    [ProtoMember(26)]
    public ushort[]? UshortArray { get; set; }

    [Key(27)]
    [ProtoMember(27)]
    public string? String { get; set; }
    [Key(28)]
    [ProtoMember(28)]
    public string[]? StringArray { get; set; }


    public override string ToString()
    {
        return "Bool: " + Bool + "\n" +
            "Byte: " + Byte + "\n" +
            "Sbyte: " + Sbyte + "\n" +
            "Char: " + Char + "\n" +
            "Decimal: " + Decimal + "\n" +
            "Double: " + Double + "\n" +
            "Float: " + Float + "\n" +
            "Int: " + Int + "\n" +
            "Uint: " + Uint + "\n" +
            "Long: " + Long + "\n" +
            "Ulong: " + Ulong + "\n" +
            "Short: " + Short + "\n" +
            "Ushort: " + Ushort + "\n" +
            //"BoolArray: " + string.Join(", ", BoolArray) + "\n" +
            //"ByteArray: " + string.Join(", ", ByteArray) + "\n" +
            "SbyteArray: " + string.Join(", ", SbyteArray) + "\n" +
            //"CharArray: " + string.Join(", ", CharArray) + "\n" +
            "DecimalArray: " + string.Join(", ", DecimalArray) + "\n" +
            "DoubleArray: " + string.Join(", ", DoubleArray) + "\n" +
            "FloatArray: " + string.Join(", ", FloatArray) + "\n" +
            "IntArray: " + string.Join(", ", IntArray) + "\n" +
            "UintArray: " + string.Join(", ", UintArray) + "\n" +
            "LongArray: " + string.Join(", ", LongArray) + "\n" +
            //"UlongArray: " + string.Join(", ", UlongArray) + "\n" +
            "ShortArray: " + string.Join(", ", ShortArray) + "\n" +
            "UshortArray: " + string.Join(", ", UshortArray) + "\n" +
            "String: " + String + "\n" +
            "StringArray: " + string.Join(", ", StringArray) + "\n";
    }
}

// https://stackoverflow.com/questions/71786891/create-a-list-of-numbers-in-bogus
class BuiltInClassFaker : Faker<BuiltInClass>
{
    public BuiltInClassFaker(int count)
    {
        RuleFor(o => o.Bool, f => f.Random.Bool());
        RuleFor(o => o.Byte, f => f.Random.Byte());
        RuleFor(o => o.Sbyte, f => f.Random.SByte());
        RuleFor(o => o.Char, f => f.Random.Char());
        RuleFor(o => o.Decimal, f => f.Random.Decimal());
        RuleFor(o => o.Double, f => f.Random.Double());
        RuleFor(o => o.Float, f => f.Random.Float());
        RuleFor(o => o.Int, f => f.Random.Int());
        RuleFor(o => o.Uint, f => f.Random.UInt());
        RuleFor(o => o.Long, f => f.Random.Long());
        RuleFor(o => o.Ulong, f => f.Random.ULong());
        RuleFor(o => o.Short, f => f.Random.Short());
        RuleFor(o => o.Ushort, f => f.Random.UShort());

        //RuleFor(o => o.BoolArray, f => Enumerable.Range(1, count).Select(_ => f.Random.Bool()).ToArray());    // NetJSON 反序列化时索引越界
        //RuleFor(o => o.ByteArray, f => Enumerable.Range(1, count).Select(_ => f.Random.Byte()).ToArray());    // 元素个数超过 20 后 MessagePack 反序列化时出错 MessagePack.MessagePackSerializationException: Unexpected msgpack code 217 (str 8) encountered. https://matrix.to/#/!OsUCGXdUrZWVaTcHrr:gitter.im/$Rf7nPebsIL8PR97xZjvGjj-iiigKSnXzqrvm6FEtrY4?via=gitter.im&via=matrix.org
        RuleFor(o => o.SbyteArray, f => Enumerable.Range(1, count).Select(_ => f.Random.SByte()).ToArray());
        //RuleFor(o => o.CharArray, f => Enumerable.Range(1, count).Select(_ => f.Random.Char()).ToArray());    // NetJSON 反序列化时卡住
        RuleFor(o => o.DecimalArray, f => Enumerable.Range(1, count).Select(_ => f.Random.Decimal()).ToArray());
        RuleFor(o => o.DoubleArray, f => Enumerable.Range(1, count).Select(_ => f.Random.Double()).ToArray());
        RuleFor(o => o.FloatArray, f => Enumerable.Range(1, count).Select(_ => f.Random.Float()).ToArray());
        RuleFor(o => o.IntArray, f => Enumerable.Range(1, count).Select(_ => f.Random.Int()).ToArray());
        RuleFor(o => o.UintArray, f => Enumerable.Range(1, count).Select(_ => f.Random.UInt()).ToArray());
        RuleFor(o => o.LongArray, f => Enumerable.Range(1, count).Select(_ => f.Random.Long()).ToArray());
        //RuleFor(o => o.UlongArray, f => Enumerable.Range(1, count).Select(_ => f.Random.ULong()).ToArray());  // LibJson 反序列化时出错 Can't assign value '4756064988429410304' (type System.Int64) to type System.UInt64
        RuleFor(o => o.ShortArray, f => Enumerable.Range(1, count).Select(_ => f.Random.Short()).ToArray());
        RuleFor(o => o.UshortArray, f => Enumerable.Range(1, count).Select(_ => f.Random.UShort()).ToArray());

        RuleFor(o => o.String, f => f.Lorem.Word());
        RuleFor(o => o.StringArray, f => f.Lorem.Words(count));
    }
}

public enum State
{
    WaitingToMove,
    Moving
}

[MessagePackObject]
[ProtoContract]
[Serializable]
public class Save
{
    [Key(1)]
    [ProtoMember(1)]
    public State m_State;
    [Key(2)]
    [ProtoMember(2)]
    public float m_CurrentTime;
    [Key(3)]
    [ProtoMember(3)]
    public float m_Pause;

    [Key(4)]
    [ProtoMember(4)]
    public Vector3 m_Offset;
    [Key(5)]
    [ProtoMember(5)]
    public Vector3 m_RotationOffset;
    [Key(6)]
    [ProtoMember(6)]
    public Vector3 m_Pivot;

    [Key(7)]
    [ProtoMember(7)]
    public string m_Title;
    [Key(8)]
    [ProtoMember(8)]
    public string m_Description;
    [Key(9)]
    [ProtoMember(9)]
    public bool m_Lose;
    [Key(10)]
    [ProtoMember(10)]
    public bool m_Hidden;
    [Key(11)]
    [ProtoMember(11)]
    public bool IsCompleted;
}

class SaveFaker : Faker<Save>
{
    public SaveFaker()
    {
        RuleFor(o => o.m_State, f => f.Random.Enum<State>());
        RuleFor(o => o.m_CurrentTime, f => f.Random.Float());
        RuleFor(o => o.m_Pause, f => f.Random.Float());

        RuleFor(o => o.m_Offset, f => new Vector3(f.Random.Float(), f.Random.Float(), f.Random.Float()));
        RuleFor(o => o.m_RotationOffset, f => new Vector3(f.Random.Float(), f.Random.Float(), f.Random.Float()));
        RuleFor(o => o.m_Pivot, f => new Vector3(f.Random.Float(), f.Random.Float(), f.Random.Float()));

        RuleFor(o => o.m_Title, f => f.Lorem.Word());
        RuleFor(o => o.m_Description, f => f.Lorem.Sentence());
        RuleFor(o => o.m_Lose, f => f.Random.Bool());
        RuleFor(o => o.m_Hidden, f => f.Random.Bool());
        RuleFor(o => o.IsCompleted, f => f.Random.Bool());
    }
}

public class Test : MonoBehaviour
{
    //private BuiltInClass _obj = null;
    private Save _obj = null;
    private string _outputUnityJson = null;
    private string _outputSystemJson = null;
    private string _outputJsonNet = null;
    //private string _outputNetJson = null; // 都无法使用，BuiltInClass 只有这个无法使用
    private string _outputProtobufNet = null;
    private byte[] _outputProtobufNetB = null;
    private string _outputUtf8Json = null;
    private byte[] _outputUtf8JsonB = null;
    private string _outputLitJson = null;
    private string _outputMessagePack = null;
    private byte[] _outputMessagePackB = null;

    // Start is called before the first frame update
    void Start()
    {
        Randomizer.Seed = new System.Random(8675309);
        //_obj = new BuiltInClassFaker(10).Generate();
        _obj = new SaveFaker().Generate();

        // 配置 protobuf-net
        RuntimeTypeModel.Default
            .Add(typeof(Vector3), false)
            .Add("x", "y", "z");
    }

    // Update is called once per frame
    void Update()
    {
        /** JsonUtility **/
        Profiler.BeginSample("Serialization.String.JsonUtility");
        _outputUnityJson = UnityJsonUtility();
        Profiler.EndSample();

        Profiler.BeginSample("Deserialization.String.JsonUtility");
        DUnityJsonUtility<Save>(_outputUnityJson);
        Profiler.EndSample();

        /** JsonSerializer **/
        Profiler.BeginSample("Serialization.String.JsonSerializer");
        _outputSystemJson = SystemJsonSerializer();
        Profiler.EndSample();

        Profiler.BeginSample("Deserialization.String.JsonSerializer");
        DSystemJsonSerializer<Save>(_outputSystemJson);
        Profiler.EndSample();

        /** NewtonsoftJson/JsonNet **/
        // 报错 Vector3: JsonSerializationException: Self referencing loop detected for property 'normalized' with type 'UnityEngine.Vector3'.
        // https://forum.unity.com/threads/jsonserializationexception-self-referencing-loop-detected.1264253/
        Profiler.BeginSample("Serialization.String.NewtonsoftJson");
        _outputJsonNet = JsonNet();
        Profiler.EndSample();

        Profiler.BeginSample("Deserialization.String.NewtonsoftJson");
        DJsonNet<Save>(_outputJsonNet);
        Profiler.EndSample();

        /** NetJson **/
        // 报错 InvalidProgramException: Invalid IL code in (wrapper dynamic-method)
        //Profiler.BeginSample("Serialization.String.NetJson");
        //_outputNetJson = NetJson();
        //Profiler.EndSample();

        //Profiler.BeginSample("Deserialization.String.NetJson");
        //DNetJson<Save>(_outputNetJson);
        //Profiler.EndSample();

        /** Protobuf-net **/
        // 报错 InvalidOperationException: No serializer defined for type: UnityEngine.Vector3
        Profiler.BeginSample("Serialization.String.Protobuf-Net");
        _outputProtobufNet = ProtobufNet();
        Profiler.EndSample();

        Profiler.BeginSample("Deserialization.String.Protobuf-Net");
        DProtobufNet<Save>(_outputProtobufNet);
        Profiler.EndSample();

        Profiler.BeginSample("Serialization.Bytes.Protobuf-Net");
        _outputProtobufNetB = ProtobufNetB();
        Profiler.EndSample();

        Profiler.BeginSample("Deserialization.Bytes.Protobuf-Net");
        DProtobufNetB<Save>(_outputProtobufNetB);
        Profiler.EndSample();

        /** Utf8Json **/
        // 导致 Unity 闪退
        //Profiler.BeginSample("Serialization.String.Utf8Json");
        //_outputUtf8Json = Utf8JSON();
        //Profiler.EndSample();

        //Profiler.BeginSample("Deserialization.String.Utf8Json");
        //DUtf8JSON<Save>(_outputUtf8Json);
        //Profiler.EndSample();

        //Profiler.BeginSample("Serialization.Bytes.Utf8Json");
        //_outputUtf8JsonB = Utf8JSONB();
        //Profiler.EndSample();

        //Profiler.BeginSample("Deserialization.Bytes.Utf8Json");
        //DUtf8JSONB<Save>(_outputUtf8JsonB);
        //Profiler.EndSample();

        /** LitJSON **/
        // 报错 JsonException: Max allowed object depth reached while trying to export from type UnityEngine.Vector3
        // 需要修改 LitJSON：https://github.com/XINCGer/LitJson4Unity
        //Profiler.BeginSample("Serialization.String.LitJson");
        //_outputLitJson = LitJSON();
        //Profiler.EndSample();

        //Profiler.BeginSample("Deserialization.String.LitJson");
        //DLitJSON<Save>(_outputLitJson);
        //Profiler.EndSample();

        /** MessagePack **/
        // .NET Standard 2.1 报错 FormatterNotRegisteredException: BuiltInClass is not registered in resolver
        // 切换到 .NET Framework 解决
        Profiler.BeginSample("Serialization.String.MessagePack");
        _outputMessagePack = MessagePackS();
        Profiler.EndSample();

        Profiler.BeginSample("Deserialization.String.MessagePack");
        DMessagePackS<Save>(_outputMessagePack);
        Profiler.EndSample();

        Profiler.BeginSample("Serialization.Bytes.MessagePack");
        _outputMessagePackB = MessagePackB();
        Profiler.EndSample();

        Profiler.BeginSample("Deserialization.Bytes.MessagePack");
        DMessagePackB<Save>(_outputMessagePackB);
        Profiler.EndSample();
    }

    /* Serialization */

    /* String format */

    public string UnityJsonUtility()
    {
        return JsonUtility.ToJson(_obj);
    }

    public string SystemJsonSerializer()
    {
        return System.Text.Json.JsonSerializer.Serialize(_obj);
    }

    public string JsonNet()
    {
        //return Newtonsoft.Json.JsonConvert.SerializeObject(_obj);
        JsonSerializerSettings settings = new JsonSerializerSettings();
        settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        return Newtonsoft.Json.JsonConvert.SerializeObject(_obj, settings);
    }

    public string NetJson()
    {
        return NetJSON.NetJSON.Serialize(_obj);
    }

    public string ProtobufNet()
    {
        using (MemoryStream ms = new MemoryStream())
        {
            ProtoBuf.Serializer.Serialize(ms, _obj);
            return Convert.ToBase64String(ms.ToArray());
        }
    }

    public string Utf8JSON()
    {
        return Utf8Json.JsonSerializer.ToJsonString(_obj);
    }

    public string LitJSON()
    {
        return LitJson.JsonMapper.ToJson(_obj);
    }

    public string MessagePackS()
    {
        return MessagePack.MessagePackSerializer.SerializeToJson(_obj);
        //return MessagePack.MessagePackSerializer.ConvertToJson(MessagePack.MessagePackSerializer.Serialize(_obj));
    }

    /* Binary format */

    public byte[] ProtobufNetB()
    {
        using (MemoryStream ms = new MemoryStream())
        {
            ProtoBuf.Serializer.Serialize(ms, _obj);
            return ms.ToArray();
        }
    }

    public byte[] Utf8JSONB()
    {
        return Utf8Json.JsonSerializer.Serialize(_obj);
    }

    public byte[] MessagePackB()
    {
        return MessagePack.MessagePackSerializer.Serialize(_obj);
    }


    /* Deserialization */

    /* String format */

    public T DUnityJsonUtility<T>(string output)
    {
        return JsonUtility.FromJson<T>(output);
    }


    public T DSystemJsonSerializer<T>(string output)
    {
        return System.Text.Json.JsonSerializer.Deserialize<T>(output);
    }

    public T DJsonNet<T>(string output)
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(output);
    }

    public T DNetJson<T>(string output)
    {
        return NetJSON.NetJSON.Deserialize<T>(output);
    }

    public T DProtobufNet<T>(string output)
    {
        byte[] arr = Convert.FromBase64String(output);
        using (MemoryStream ms = new MemoryStream(arr))
        {
            return ProtoBuf.Serializer.Deserialize<T>(ms);
        }
    }

    public T DUtf8JSON<T>(string output)
    {
        return Utf8Json.JsonSerializer.Deserialize<T>(System.Text.Encoding.UTF8.GetBytes(output));
    }

    public T DLitJSON<T>(string output)
    {
        return LitJson.JsonMapper.ToObject<T>(output);
    }

    public T DMessagePackS<T>(string output)
    {
        return MessagePack.MessagePackSerializer.Deserialize<T>(MessagePack.MessagePackSerializer.ConvertFromJson(output));
    }

    /* Binary format */

    public T DProtobufNetB<T>(byte[] output)
    {
        using (MemoryStream ms = new MemoryStream(output))
        {
            return ProtoBuf.Serializer.Deserialize<T>(ms);
        }
    }

    public T DUtf8JSONB<T>(byte[] output)
    {
        return Utf8Json.JsonSerializer.Deserialize<T>(output);
    }

    public T DMessagePackB<T>(byte[] output)
    {
        return MessagePack.MessagePackSerializer.Deserialize<T>(output);
    }
}
