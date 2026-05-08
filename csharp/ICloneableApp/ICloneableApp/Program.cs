// Create a Person.
Person person1 = new Person("Peterson", "Peter", 25);

// Make a clone of it.
Person person2 = (Person)person1.Clone();

// Print both.
Console.WriteLine("Person 1: " + person1.ToString());
Console.WriteLine("Person 2: " + person2.ToString());

// Mutate the clone.
person2.FirstName = "John";
person2.Age = 30;

// Print both again — the original should be untouched.
Console.WriteLine("\nPerson 1: " + person1.ToString());
Console.WriteLine("Person 2: " + person2.ToString());

Console.ReadLine();


// Person — implements ICloneable for a shallow copy.
class Person : ICloneable
{
    // Fields.
    private string lastName;
    private string firstName;
    private int age;

    // Constructor.
    public Person(string lastName, string firstName, int age)
    {
        this.lastName = lastName;
        this.firstName = firstName;
        this.age = age;
    }

    // Properties.
    public string LastName { get { return lastName; } set { lastName = value; } }
    public string FirstName { get { return firstName; } set { firstName = value; } }
    public int Age { get { return age; } set { age = value; } }

    // ICloneable.Clone — produce a new Person with the same field values.
    public object Clone()
    {
        return new Person(this.LastName, this.FirstName, this.Age);
    }

    // Friendly string representation.
    public override string ToString()
    {
        return LastName + " " + FirstName + ", " + Age + " years old";
    }
}
