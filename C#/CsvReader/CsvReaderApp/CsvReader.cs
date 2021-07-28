namespace CsvReaderApp
{
    internal static class CsvReader
    {
        private const string Separator = ",";

        public static T[][] Read<T>(string[] lines) where T : struct
        {
            var result = new T[lines.Length][];
            
            for (var i = 0; i < lines.Length; i++)
            {
                var items = lines[i].Split(Separator);
                result[i] = new T[items.Length];

                for (var j = 0; j < items.Length; j++)
                {
                    result[i][j] = StringConverter.TryParse<T>(items[j]);
                }
            }

            return result;
        }
    }
}