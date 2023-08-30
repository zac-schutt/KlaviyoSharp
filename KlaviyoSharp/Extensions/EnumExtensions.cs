using System.Linq;
using System.Runtime.Serialization;

namespace KlaviyoSharp;

internal static class EnumExtensions
{
    /// <summary>
    /// Convert Enum to string
    /// </summary>
    /// <typeparam name="T">Enum type</typeparam>
    /// <param name="value">Enum Value</param>
    /// <returns></returns>
    public static string ToEnumString<T>(this T value) where T : struct, Enum
    {
        Type enumType = typeof(T);
        var name = Enum.GetName(enumType, value);
        var ouptut = ((EnumMemberAttribute[])enumType?
                        .GetField(name)?
                        .GetCustomAttributes(typeof(EnumMemberAttribute), true))?
                        .Single()?
                        .Value;
        return ouptut ?? value.ToString();
    }
}