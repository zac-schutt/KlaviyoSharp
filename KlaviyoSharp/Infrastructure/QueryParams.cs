using System;
using System.Collections.Generic;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Infrastructure;
/// <summary>
/// Class to represent a HTTP query string. Prevents accidentally passing the params to the wrong method parameter.
/// </summary>
public class QueryParams : Dictionary<string, string>
{
    /// <summary>
    /// Extract QueryParams from a Uri
    /// </summary>
    /// <param name="uri"></param>
    public QueryParams(Uri uri)
    {
        FromUri(uri);
    }
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
    public QueryParams() { }
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
    ///
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

    private void AddFilters(string filters)
    {
        if (!string.IsNullOrEmpty(filters))
        {
            TryAdd($"filter", filters);
        }
    }
    /// Add filter to a query dictionary
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public void AddFilters(IFilter filter)
    {
        if (filter != null) AddFilters(filter.ToString());
    }
    /// Add filter to a query dictionary
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public void AddSort(string sortField)
    {
        if (!string.IsNullOrEmpty(sortField)) Add("sort", sortField);
    }


}