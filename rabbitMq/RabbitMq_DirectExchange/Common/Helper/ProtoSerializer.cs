using ProtoBuf;

namespace Common.Helper;

public class ProtoSerializer
{
    public static byte[] Serialize<T>(T obj)
    {
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, obj);
        return stream.ToArray();
    }
}