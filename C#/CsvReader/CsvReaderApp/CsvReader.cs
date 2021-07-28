namespace CsvReaderApp
{
    public class CsvReader : ICsvReader
    {
        private const string Separator = ",";

        private readonly IStringConverter _stringConverter;

        public CsvReader(IStringConverter stringConverter)
        {
            _stringConverter = stringConverter;
        }

        public T[][] Read<T>(string[] lines) where T : struct
        {
            var result = new T[lines.Length][];
            
            for (var i = 0; i < lines.Length; i++)
            {
                var items = lines[i].Split(Separator);
                result[i] = new T[items.Length];

                for (var j = 0; j < items.Length; j++)
                {
                    result[i][j] = _stringConverter.TryParse<T>(items[j]);
                }
            }

            return result;
        }
    }
}