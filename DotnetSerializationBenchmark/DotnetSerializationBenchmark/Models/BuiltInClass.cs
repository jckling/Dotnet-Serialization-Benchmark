using Bogus;
using ProtoBuf;

namespace DotnetSerializationBenchmark.Models
{
    [ProtoContract]
    [Serializable]
    public class BuiltInClass
    {
        [ProtoMember(1)]
        public bool Bool { get; set; }
        [ProtoMember(2)]
        public byte Byte { get; set; }
        [ProtoMember(3)]
        public sbyte Sbyte { get; set; }
        [ProtoMember(4)]
        public char Char { get; set; }
        [ProtoMember(5)]
        public decimal Decimal { get; set; }
        [ProtoMember(6)]
        public double Double { get; set; }
        [ProtoMember(7)]
        public float Float { get; set; }
        [ProtoMember(8)]
        public int Int { get; set; }
        [ProtoMember(9)]
        public uint Uint { get; set; }
        [ProtoMember(10)]
        public long Long { get; set; }
        [ProtoMember(11)]
        public ulong Ulong { get; set; }
        [ProtoMember(12)]
        public short Short { get; set; }
        [ProtoMember(13)]
        public ushort Ushort { get; set; }

        //[ProtoMember(14)]
        //public bool[]? BoolArray { get; set; }
        [ProtoMember(15)]
        public byte[]? ByteArray { get; set; }
        [ProtoMember(16)]
        public sbyte[]? SbyteArray { get; set; }
        //[ProtoMember(17)]
        //public char[]? CharArray { get; set; }
        [ProtoMember(18)]
        public decimal[]? DecimalArray { get; set; }
        [ProtoMember(19)]
        public double[]? DoubleArray { get; set; }
        [ProtoMember(20)]
        public float[]? FloatArray { get; set; }
        [ProtoMember(21)]
        public int[]? IntArray { get; set; }
        [ProtoMember(22)]
        public uint[]? UintArray { get; set; }
        [ProtoMember(23)]
        public long[]? LongArray { get; set; }
        [ProtoMember(24)]
        public ulong[]? UlongArray { get; set; }
        [ProtoMember(25)]
        public short[]? ShortArray { get; set; }
        [ProtoMember(26)]
        public ushort[]? UshortArray { get; set; }

        [ProtoMember(27)]
        public string? String { get; set; }
        [ProtoMember(28)]
        public string[]? StringArray { get; set; }
    }

    // https://stackoverflow.com/questions/71786891/create-a-list-of-numbers-in-bogus
    class BuiltInClassFaker : Faker<BuiltInClass>
    {
        public BuiltInClassFaker(int count)
        {
            RuleFor(o => o.Bool, f => f.Random.Bool());
            RuleFor(o => o.Byte, f => f.Random.Byte());
            RuleFor(o => o.Char, f => f.Random.Char());
            RuleFor(o => o.Decimal, f => f.Random.Decimal());
            RuleFor(o => o.Double, f => f.Random.Double());
            RuleFor(o => o.Float, f => f.Random.Float());
            RuleFor(o => o.Int, f => f.Random.Int());
            RuleFor(o => o.Long, f => f.Random.Long());
            RuleFor(o => o.Sbyte, f => f.Random.SByte());
            RuleFor(o => o.Short, f => f.Random.Short());
            RuleFor(o => o.Uint, f => f.Random.UInt());
            RuleFor(o => o.Ulong, f => f.Random.ULong());
            RuleFor(o => o.Ushort, f => f.Random.UShort());

            //RuleFor(o => o.BoolArray, f => Enumerable.Range(1, count).Select(_ => f.Random.Bool()).ToArray());    // NetJSON 反序列化时索引越界
            RuleFor(o => o.ByteArray, f => Enumerable.Range(1, count).Select(_ => f.Random.Byte()).ToArray());
            RuleFor(o => o.SbyteArray, f => Enumerable.Range(1, count).Select(_ => f.Random.SByte()).ToArray());
            //RuleFor(o => o.CharArray, f => Enumerable.Range(1, count).Select(_ => f.Random.Char()).ToArray());    // NetJSON 反序列化时卡住
            RuleFor(o => o.DecimalArray, f => Enumerable.Range(1, count).Select(_ => f.Random.Decimal()).ToArray());
            RuleFor(o => o.DoubleArray, f => Enumerable.Range(1, count).Select(_ => f.Random.Double()).ToArray());
            RuleFor(o => o.FloatArray, f => Enumerable.Range(1, count).Select(_ => f.Random.Float()).ToArray());
            RuleFor(o => o.IntArray, f => Enumerable.Range(1, count).Select(_ => f.Random.Int()).ToArray());
            RuleFor(o => o.UintArray, f => Enumerable.Range(1, count).Select(_ => f.Random.UInt()).ToArray());
            RuleFor(o => o.LongArray, f => Enumerable.Range(1, count).Select(_ => f.Random.Long()).ToArray());
            RuleFor(o => o.UlongArray, f => Enumerable.Range(1, count).Select(_ => f.Random.ULong()).ToArray());
            RuleFor(o => o.ShortArray, f => Enumerable.Range(1, count).Select(_ => f.Random.Short()).ToArray());
            RuleFor(o => o.UshortArray, f => Enumerable.Range(1, count).Select(_ => f.Random.UShort()).ToArray());


            RuleFor(o => o.String, f => f.Lorem.Word());
            RuleFor(o => o.StringArray, f => f.Lorem.Words());
        }
    }
}