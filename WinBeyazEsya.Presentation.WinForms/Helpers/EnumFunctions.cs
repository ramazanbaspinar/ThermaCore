using System.ComponentModel;

namespace WinBeyazEsya.Presentation.WinForms.Helpers
{
    public static class EnumFunctions
    {
        public static IEnumerable<string> GetEnumDescriptionList<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Select(x => x.ToName());
        }

        public static string ToName(this Enum value)
        {
            if (value == null) return string.Empty;

            var fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo == null) return value.ToString();

            var attribute = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static T GetEnum<T>(this string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
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
            throw new ArgumentException($"Enum alanında {description} tanımlı değil.", nameof(description));
        }
    }
}

