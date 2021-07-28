using System;
using System.Reflection;

namespace CsvReaderApp
{
    public class StringConverter : IStringConverter
    {
        private const string MethodName = "TryParse";

        public T TryParse<T>(string str) where T : new()
        {
            MethodInfo tryParse = typeof(T)
                .GetMethod(MethodName, new[]
                {
                    typeof(string), typeof(T).MakeByRefType()
                });

            _ = tryParse ?? throw new ArgumentNullException($"{nameof(T)} type has no TryParse method");
            
            var parameters = new object[] { str, new T() };

            tryParse.Invoke(null, parameters);
            return (T)parameters[1];
        }
    }
}