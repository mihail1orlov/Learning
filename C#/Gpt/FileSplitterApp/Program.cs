class FileSplitter
{
    static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            ShowUsage();
            return;
        }

        string filePath = args[0];
        int chunkSize = 2000;

        if (args.Length > 1 && int.TryParse(args[1], out int customSize))
        {
            chunkSize = customSize;
        }

        try
        {
            SplitFile(filePath, chunkSize);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void SplitFile(string filePath, int chunkSize)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found!");
            return;
        }

        using (StreamReader reader = new StreamReader(filePath))
        {
            int partNumber = 1;
            string outputDirectory = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string fileExtension = Path.GetExtension(filePath);

            while (!reader.EndOfStream)
            {
                string outputFile = Path.Combine(outputDirectory, $"{fileName}_part{partNumber}{fileExtension}");
                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    char[] buffer = new char[chunkSize];
                    int bytesRead = reader.ReadBlock(buffer, 0, chunkSize);
                    writer.Write(buffer, 0, bytesRead);
                }
                partNumber++;
            }
        }

        Console.WriteLine("File splitting completed!");
    }

    static void ShowUsage()
    {
        Console.WriteLine("Usage: FileSplitter.exe <input_file> [chunk_size]");
        Console.WriteLine("Example: FileSplitter.exe input.txt 2000");
    }
}
