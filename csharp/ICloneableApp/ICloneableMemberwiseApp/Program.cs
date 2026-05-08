// Build a graph of two objects: a top-level MyClass referencing a MyNestedClass.

var original = new MyClass("A33C30C4-7FEA-4827-8EBE-1D9426B87E2F");
original.MyProperty = "Original";
original.MyNestedClass = new MyNestedClass("23EA7BF9-93FE-43A5-B0D4-A38C6326CD74");
original.MyNestedClass.MyNestedProperty = "NestedOriginal";

// Clone the whole graph and mutate the copy.
var clone = (MyClass)original.Clone();
clone.MyProperty = "Clone";
clone.MyNestedClass.MyNestedProperty = "NestedClone";

// Print both — the original should not be affected by the clone's mutations
// thanks to the deep-copy behaviour of Clone().
Console.WriteLine("Original:");
Console.WriteLine(original);

Console.WriteLine("Clone:");
Console.WriteLine(clone);

Console.ReadLine();

// MyClass — owns a nested object and implements ICloneable.
class MyClass : ICloneable
{
    private string _id;

    public MyClass(string id)
    {
        _id = id;
    }

    public string MyProperty { get; set; }
    public MyNestedClass MyNestedClass { get; set; }

    public override string ToString()
    {
        return $"id: {_id}\tMyProperty: {MyProperty}\t{MyNestedClass}";
    }

    // ICloneable.Clone — start from a memberwise (shallow) copy, then
    // recurse into the nested object so the clone gets its own copy.
    public object Clone()
    {
        var clone = (MyClass)this.MemberwiseClone();
        clone.MyNestedClass = (MyNestedClass)MyNestedClass.Clone();
        return clone;
    }
}

// MyNestedClass — leaf object, also ICloneable.
class MyNestedClass : ICloneable
{
    private string _id;

    public MyNestedClass(string id)
    {
        _id = id;
    }

    public string MyNestedProperty { get; set; }

    public override string ToString()
    {
        return $"Id: {_id}\tMyNestedProperty: {MyNestedProperty}";
    }

    // ICloneable.Clone — a memberwise copy is enough for this leaf type.
    public object Clone()
    {
        return (MyNestedClass)MemberwiseClone();
    }
}
