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
    // Имитация поворота (нажатие клавиши "A" для движения влево)wa
    inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_A);
    Console.WriteLine("Turning left");
    Thread.Sleep(1000);  // Поворачиваем влево в течение 1 секундыwawa
}

static void MoveForward(InputSimulator inputSimulator)
{
    // Имитация нажатия клавиши "W" для движения вперед
    inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_W);
    Console.WriteLine("Moving forward");
    Thread.Sleep(500);  // Двигаемся вперед в течение 1 секунды
    inputSimulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_W);
}

static void Press(int i, InputSimulator inputSimulator)
{
    // Имитация нажатия правой кнопки мыши
    inputSimulator.Mouse.LeftButtonDown();
    Console.WriteLine($"{i}. RightButtonDown");
    Thread.Sleep(4000);  // Держим кнопку в течение 4 секунд для добычи руды

    // Отпускание правой кнопки мыши
    inputSimulator.Mouse.LeftButtonUp();
    Console.WriteLine($"{i}. {nameof(inputSimulator.Mouse.LeftButtonUp)}");
}