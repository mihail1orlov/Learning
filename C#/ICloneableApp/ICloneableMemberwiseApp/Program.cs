// Создание объекта

var original = new MyClass("A33C30C4-7FEA-4827-8EBE-1D9426B87E2F");
original.MyProperty = "Original";
original.MyNestedClass = new MyNestedClass("23EA7BF9-93FE-43A5-B0D4-A38C6326CD74");
original.MyNestedClass.MyNestedProperty = "NestedOriginal";

// Создание копии объекта
var clone = (MyClass)original.Clone();
clone.MyProperty = "Clone";
clone.MyNestedClass.MyNestedProperty = "NestedClone";

// Вывод значений свойств
Console.WriteLine("Original:");
Console.WriteLine(original);

Console.WriteLine("Clone:");
Console.WriteLine(clone);

Console.ReadLine();

// Создаем класс, который будет использовать интерфейс ICloneable
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

    // Реализация метода Clone
    public object Clone()
    {
        var clone = (MyClass)this.MemberwiseClone();
        clone.MyNestedClass = (MyNestedClass)MyNestedClass.Clone();
        return clone;
    }
}

// Создаем вложенный класс, который также будет использовать интерфейс ICloneable
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
    // Реализация метода Clone
    public object Clone()
    {
        return (MyNestedClass)MemberwiseClone();
    }
}
