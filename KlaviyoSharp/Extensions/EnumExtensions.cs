using System;
using System.Linq;
using System.Runtime.Serialization;

namespace KlaviyoSharp;

internal static class EnumExtensions
{
    public static string ToEnumString<T>(this T value) where T : struct, Enum
    {
        Type enumType = typeof(T);
        var name = Enum.GetName(enumType, value);
        var ouptut = ((EnumMemberAttribute[])enumType?.GetField(name)?.GetCustomAttributes(typeof(EnumMemberAttribute), true))?.Single()?.Value;
        return ouptut ?? value.ToString();
    }
}