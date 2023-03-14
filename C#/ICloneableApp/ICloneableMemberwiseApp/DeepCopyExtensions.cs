using System.Reflection;

public static class DeepCopyExtensions
{
    public static T DeepClone<T>(this T source)
    {
        if (source == null)
        {
            return default(T);
        }

        var type = source.GetType();

        // Value types and strings can be copied directly
        if (type.IsValueType || type == typeof(string))
        {
            return source;
        }

        // Arrays must be copied element by element
        if (type.IsArray)
        {
            var elementType = type.GetElementType();
            var sourceArray = source as Array;
            var length = sourceArray.Length;
            var targetArray = Array.CreateInstance(elementType, length);

            for (int i = 0; i < length; i++)
            {
                var element = sourceArray.GetValue(i);
                var clonedElement = DeepClone(element);
                targetArray.SetValue(clonedElement, i);
            }

            return (T)Convert.ChangeType(targetArray, type);
        }

        // Objects with nested reference types must be copied recursively
        var target = Activator.CreateInstance(type);

        foreach (var field in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
        {
            var fieldValue = field.GetValue(source);
            var clonedFieldValue = DeepClone(fieldValue);
            field.SetValue(target, clonedFieldValue);
        }

        return (T)target;
    }
}
