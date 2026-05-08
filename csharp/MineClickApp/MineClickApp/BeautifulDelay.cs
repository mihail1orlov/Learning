public class BeautifulDelay
{
    static readonly char[] Spinner = { '|', '/', '-', '\\' };

    public static void Animate(int durationInMilliseconds = 5000)
    {
        int iterations = durationInMilliseconds / 250;
        for (int i = 0; i < iterations; i++)
        {
            Console.Write($"\rAnimation: {Spinner[i % 4]}");
            Thread.Sleep(250);
        }
    }
}