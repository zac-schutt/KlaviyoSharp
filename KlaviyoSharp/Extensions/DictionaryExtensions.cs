using System.Collections.Generic;
namespace KlaviyoSharp;

internal static class DictionaryExtensions
{
    /// <summary>
    /// Converts a dictionary to a HTTP query string
    /// </summary>
    /// <param name="dict">The dictionary to convert</param>
    /// <returns>A HTTP query string</returns>
    public static string ToQueryString(this IDictionary<string,string> dict)
    {
        var list = new List<string>();
        foreach (var item in dict)
        {
            list.Add($"{item.Key}={item.Value}");
        }
        return string.Join("&", list);
    }
}