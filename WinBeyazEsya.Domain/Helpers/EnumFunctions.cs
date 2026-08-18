using System.ComponentModel;
using System.Reflection;
using WinBeyazEsya.Domain.Attributes;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Helpers;

public static class EnumFunctions
{
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        if (field == null) return value.ToString();

        var attribute = field.GetCustomAttribute<DescriptionAttribute>();
        return attribute == null ? value.ToString() : attribute.Description;
    }

    public static ModuleType? GetParentModule(this ModuleType value)
    {
        var field = value.GetType().GetField(value.ToString());
        if (field == null) return null;

        var attribute = field.GetCustomAttribute<ParentModuleAttribute>();
        return attribute?.Parent;
    }

    public static T GetEnum<T>(string description) where T : Enum
    {
        foreach (var field in typeof(T).GetFields())
        {
            if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                if (attribute.Description == description)
                    return (T)field.GetValue(null)!;
            }
            else
            {
                if (field.Name == description)
                    return (T)field.GetValue(null)!;
            }
        }
        throw new ArgumentException("Not found.", nameof(description));
    }
}

