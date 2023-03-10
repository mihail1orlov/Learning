using System;
using System.Threading;

class Star
{
    public int x, y;
    public ConsoleColor color;

    public Star(int x, int y, ConsoleColor color)
    {
        this.x = x;
        this.y = y;
        this.color = color;
    }

    public void Draw()
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write("*");
    }

    public void Twinkle()
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("*");
        Thread.Sleep(new Random().Next(50, 300));
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write("*");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;

        int width = Console.WindowWidth;
        int height = Console.WindowHeight;

        Random random = new Random();

        Star[] stars = new Star[width * height / 100];

        for (int i = 0; i < stars.Length; i++)
        {
            int x = random.Next(0, width);
            int y = random.Next(0, height);
            ConsoleColor color = (ConsoleColor)random.Next(1, 16);
            stars[i] = new Star(x, y, color);
        }

        while (true)
        {
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].Twinkle();
            }
        }
    }
}
