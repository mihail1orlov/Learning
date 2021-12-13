using ProtoBuf;

namespace Common.Model;

[ProtoContract]
public class User
{
    [ProtoMember(1)]
    public string Name { get; init; }

    [ProtoMember(2)]
    public int Age { get; init; }

    [ProtoMember(3)]
    public DateTime UpdateDate { get; init; }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}, {nameof(UpdateDate)}: {UpdateDate.ToString("T")}";
    }
}