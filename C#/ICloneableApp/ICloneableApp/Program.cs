// Создание объекта Person
Person person1 = new Person("Peterson", "Peter", 25);

// Создание копии объекта Person
Person person2 = (Person)person1.Clone();

// Вывод информации об объектах Person
Console.WriteLine("Person 1: " + person1.ToString());
Console.WriteLine("Person 2: " + person2.ToString());

// Изменение свойств объекта Person 2
person2.FirstName = "John";
person2.Age = 30;

// Вывод информации об объектах Person после изменения
Console.WriteLine("\nPerson 1: " + person1.ToString());
Console.WriteLine("Person 2: " + person2.ToString());

Console.ReadLine();


// Класс Person с реализацией ICloneable
class Person : ICloneable
{
    // Поля класса
    private string lastName;
    private string firstName;
    private int age;

    // Конструктор класса
    public Person(string lastName, string firstName, int age)
    {
        this.lastName = lastName;
        this.firstName = firstName;
        this.age = age;
    }

    // Свойства класса
    public string LastName { get { return lastName; } set { lastName = value; } }
    public string FirstName { get { return firstName; } set { firstName = value; } }
    public int Age { get { return age; } set { age = value; } }

    // Реализация метода Clone из интерфейса ICloneable
    public object Clone()
    {
        return new Person(this.LastName, this.FirstName, this.Age);
    }

    // Переопределение метода ToString для вывода информации об объекте
    public override string ToString()
    {
        return LastName + " " + FirstName + ", " + Age + " years old";
    }
}