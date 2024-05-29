using System.Runtime.InteropServices;

namespace _02UnderstandingTypes;

class Program
{
    static void Main(string[] args)
    {
        var types = new (string TypeName, Type Type)[]
        {
            ("sbyte", typeof(sbyte)),
            ("byte", typeof(byte)),
            ("short", typeof(short)),
            ("ushort", typeof(ushort)),
            ("int", typeof(int)),
            ("uint", typeof(uint)),
            ("long", typeof(long)),
            ("ulong", typeof(ulong)),
            ("float", typeof(float)),
            ("double", typeof(double)),
            ("decimal", typeof(decimal))
        };

        Console.WriteLine("{0,-10} {1,-5} {2,30} {3,30}", "Type", "Bytes", "Min Value", "Max Value");
        foreach (var (typeName, type) in types)
        {
            int size = Marshal.SizeOf(type);
            object minValue = type.GetField("MinValue").GetValue(null);
            object maxValue = type.GetField("MaxValue").GetValue(null);
            Console.WriteLine("{0,-10} {1,-5} {2,30} {3,30}", typeName, size, minValue, maxValue);
        }
    }
}