using System;
using System.Reflection;

namespace CsvReaderApp
{
    internal static class CsvReader
    {
        private const string Separator = ",";
        private const string MethodName = "TryParse";

        public static T[][] Read<T>(string[] lines) where T : new()
        {
            Type[] argTypes = {typeof(string), typeof(T).MakeByRefType()};
            MethodInfo tryParse = typeof(T).GetMethod(MethodName, argTypes);

            var results = new T[lines.Length][];
            
            for (var i = 0; i < lines.Length; i++)
            {
                var items = lines[i].Split(Separator);
                results[i] = new T[items.Length];

                for (var j = 0; j < items.Length; j++)
                {
                    results[i][j] = GetCellValue<T>(items[j], tryParse);
                }
            }

            return results;
        }

        private static T GetCellValue<T>(string item, MethodBase tryParse) where T : new()
        {
            var result = new T();
            var parameters = new object[] {item, result};
            tryParse.Invoke(null, parameters);
            return (T)parameters[1];
        }
    }
}