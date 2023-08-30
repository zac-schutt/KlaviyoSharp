using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Infrastructure;

/// <summary>
/// Class to represent a HTTP query string. Prevents accidentally passing the params to the wrong method parameter.
/// </summary>
internal class QueryParams : Dictionary<string, string>
{
    /// <summary>
    /// Extract QueryParams from a Uri
    /// </summary>
    /// <param name="uri"></param>
    public QueryParams(Uri uri)
    {
        FromUri(uri);
    }
    /// <summary>
    /// Extract QueryParams from a Uri string
    /// </summary>
    /// <param name="uriString"></param>
    public QueryParams(string uriString)
    {
        if (!string.IsNullOrEmpty(uriString)) FromUri(new Uri(uriString));
    }
    private void FromUri(Uri uri)
    {
        if (uri == null || !string.IsNullOrEmpty(uri.Query))
        {
            var query = uri.GetComponents(UriComponents.Query, UriFormat.UriEscaped);
            foreach (var item in query.Split('&'))
            {
                var parts = item.Split('=');
                if (parts.Length == 2)
                {
                    Add(System.Net.WebUtility.UrlDecode(parts[0]), System.Net.WebUtility.UrlDecode(parts[1]));
                }
            }
        }
    }
    /// <summary>
    /// Create an empty QueryParams
    /// </summary>
    public QueryParams() { }
    /// <summary>
    /// Convert the QueryParams to a string for injestion into a Uri
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        var list = new List<string>();
        foreach (var item in this)
        {
            list.Add($"{System.Web.HttpUtility.UrlEncode(item.Key)}={System.Web.HttpUtility.UrlEncode(item.Value)}");
        }
        return string.Join("&", list);
    }

    /// <summary>
    /// Add fields to be listed to a query dictionary
    /// </summary>
    /// <param name="objectType"></param>
    /// <param name="fieldNames"></param>
    /// <returns></returns>
    public void AddFieldset(string objectType, List<string> fieldNames)
    {
        if (fieldNames != null && fieldNames.Count != 0)
        {
            TryAdd($"fields[{objectType}]", string.Join(",", fieldNames));
        }
    }
    /// <summary>
    /// Add additional fields to be listed to a query dictionary
    /// </summary>
    /// <param name="objectType"></param>
    /// <param name="fieldNames"></param>
    public void AddAdditionalFields(string objectType, List<string> fieldNames)
    {
        if (fieldNames != null && fieldNames.Count != 0)
        {
            TryAdd($"additional-fields[{objectType}]", string.Join(",", fieldNames));
        }
    }

    private void AddFilter(string filters)
    {
        if (!string.IsNullOrEmpty(filters))
        {
            TryAdd($"filter", filters);
        }
    }
    /// <summary>
    /// Add filter to a query dictionary
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public void AddFilter(IFilter filter)
    {
        if (filter != null) AddFilter(filter.ToString());
    }
    /// <summary>
    /// Add filter to a query dictionary
    /// </summary>
    /// <param name="sortField"></param>
    /// <returns></returns>
    public void AddSort(string sortField)
    {
        if (!string.IsNullOrEmpty(sortField)) Add("sort", sortField);
    }

    /// <summary>
    /// Add filter to a query dictionary
    /// </summary>
    /// <param name="includedRecords"></param>
    /// <returns></returns>
    public void AddIncludes(List<string> includedRecords)
    {
        if (includedRecords != null && includedRecords.Count != 0)
        {
            TryAdd("include", string.Join(",", includedRecords));
        }
    }

#if NETSTANDARD2_0
    //TryAdd not available in NETStandard 2.0
    private void TryAdd(string key, string value)
    {
        if (!string.IsNullOrEmpty(value) && !ContainsKey(key))
        {
            Add(key, value);
        }
    }
#endif
}