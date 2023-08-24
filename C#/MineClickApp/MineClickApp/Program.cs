using WindowsInput;

var inputSimulator = new InputSimulator();
for (var i = 0; true ; i++)
{
    Press(i, inputSimulator);
}

void Press(int i, InputSimulator inputSimulator)
{
    inputSimulator.Mouse.RightButtonDown();
    Console.WriteLine($"{i}. RightButtonDown");
    Thread.Sleep(4000);
    
    inputSimulator.Mouse.RightButtonUp();
    Console.WriteLine($"{i}. RightButtonUp");    
    Thread.Sleep(6000);
}