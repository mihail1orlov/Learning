using WindowsInput;

BeautifulDelay.Animate();

var inputSimulator = new InputSimulator();

for (var i = 0; true; i++)
{
    MoveForward(inputSimulator);
    Press(i, inputSimulator);
}

void TurnLeft(InputSimulator inputSimulator1)
{
    // Press "A" to turn left.
    inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_A);
    Console.WriteLine("Turning left");
    Thread.Sleep(1000);  // Hold for ~1 second.
}

static void MoveForward(InputSimulator inputSimulator)
{
    // Hold "W" to move forward.
    inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_W);
    Console.WriteLine("Moving forward");
    Thread.Sleep(500);  // Move forward for half a second.
    inputSimulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_W);
}

static void Press(int i, InputSimulator inputSimulator)
{
    // Hold left mouse button — long enough for a typical mining swing.
    inputSimulator.Mouse.LeftButtonDown();
    Console.WriteLine($"{i}. LeftButtonDown");
    Thread.Sleep(4000);  // 4 seconds is a comfortable mining window.

    // Release the button.
    inputSimulator.Mouse.LeftButtonUp();
    Console.WriteLine($"{i}. {nameof(inputSimulator.Mouse.LeftButtonUp)}");
}
