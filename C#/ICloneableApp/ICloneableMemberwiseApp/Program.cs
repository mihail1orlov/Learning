// Создание объекта
var original = new MyClass();
original.MyProperty = "Original";
original.MyNestedClass = new MyNestedClass();
original.MyNestedClass.MyNestedProperty = "NestedOriginal";

// Создание копии объекта
var clone = (MyClass)original.Clone();
clone.MyProperty = "Clone";
clone.MyNestedClass.MyNestedProperty = "NestedClone";

// Вывод значений свойств
Console.WriteLine("Original:");
Console.WriteLine(original.MyProperty);
Console.WriteLine(original.MyNestedClass.MyNestedProperty);

Console.WriteLine("Clone:");
Console.WriteLine(clone.MyProperty);
Console.WriteLine(clone.MyNestedClass.MyNestedProperty);

Console.ReadLine();


// Создаем класс, который будет использовать интерфейс ICloneable
class MyClass : ICloneable
{
    public string MyProperty { get; set; }
    public MyNestedClass MyNestedClass { get; set; }

    // Реализация метода Clone
    public object Clone()
    {
        var clone = (MyClass)this.MemberwiseClone();
        clone.MyNestedClass = (MyNestedClass)this.MyNestedClass.Clone();
        return clone;
    }
}

// Создаем вложенный класс, который также будет использовать интерфейс ICloneable
class MyNestedClass : ICloneable
{
    public string MyNestedProperty { get; set; }

    // Реализация метода Clone
    public object Clone()
    {
        return this.MemberwiseClone();
    }
}
