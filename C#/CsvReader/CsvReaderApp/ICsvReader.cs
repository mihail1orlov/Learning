namespace CsvReaderApp
{
    public interface ICsvReader
    {
        T[][] Read<T>(string[] lines) where T : struct;

    }
}