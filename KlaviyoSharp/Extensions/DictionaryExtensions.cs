using System.Collections.Generic;
namespace KlaviyoSharp;

internal static class DictionaryExtensions
{
    /// <summary>
    /// Converts a dictionary to a HTTP query string
    /// </summary>
    /// <param name="dict">The dictionary to convert</param>
    /// <returns>A HTTP query string</returns>
    public static string ToQueryString(this IDictionary<string, string> dict)
    {
        var list = new List<string>();
        foreach (var item in dict)
        {
            list.Add($"{item.Key}={item.Value}");
        }
        return string.Join("&", list);
    }

    /// <summary>
    /// Add fields to be listed to a query dictionary
    /// </summary>
    /// <param name="dict"></param>
    /// <param name="objectType"></param>
    /// <param name="fieldNames"></param>
    /// <returns></returns>
    public static IDictionary<string, string> AddFieldset(this IDictionary<string, string> dict, string objectType, List<string> fieldNames)
    {
        if (fieldNames == null || fieldNames.Count == 0)
        {
            return dict;
        }
        dict.TryAdd($"fields[{objectType}]", string.Join(",", fieldNames));
        return dict;
    }

    /// <summary>
    /// Add filters to a query dictionary
    /// </summary>
    /// <param name="dict"></param>
    /// <param name="filters"></param>
    /// <returns></returns>
    public static IDictionary<string, string> AddFilters(this IDictionary<string, string> dict, string filters)
    {
        if (string.IsNullOrEmpty(filters))
        {
            return dict;
        }
        dict.TryAdd($"filter", filters);
        return dict;
    }


}