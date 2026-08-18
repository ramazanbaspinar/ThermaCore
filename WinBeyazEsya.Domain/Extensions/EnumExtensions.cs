using System.ComponentModel;
using System.Reflection;

namespace WinBeyazEsya.Domain.Extensions;

public static class EnumExtensions
{
    public static string ToName(this Enum? value)
    {
        if (value == null)
            return string.Empty;

        Type type = value.GetType();
        string? name = Enum.GetName(type, value);
        if (name != null)
        {
            FieldInfo? field = type.GetField(name);
            if (field != null)
            {
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                {
                    return attr.Description;
                }
            }
            return name;
        }
        return string.Empty;
    }

    public static List<string> GetEnumDescriptionList<T>() where T : struct, Enum
    {
        var list = new List<string>();
        foreach (T val in Enum.GetValues<T>())
        {
            list.Add(val.ToName());
        }
        return list;
    }

    public static T? ToEnum<T>(this string? value) where T : struct, Enum
    {
        if (string.IsNullOrEmpty(value))
            return null;

        foreach (T val in Enum.GetValues<T>())
        {
            if (string.Equals(val.ToName(), value, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(val.ToString(), value, StringComparison.OrdinalIgnoreCase))
            {
                return val;
            }
        }

        if (Enum.TryParse<T>(value, true, out T result))
        {
            return result;
        }

        return null;
    }
}

