namespace CsvReaderApp
{
    public interface IStringConverter
    {
        T TryParse<T>(string str) where T : new();
    }
}