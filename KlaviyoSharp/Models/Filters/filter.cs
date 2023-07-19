using System;
using System.Collections.Generic;
using KlaviyoSharp.Infrastructure;

namespace KlaviyoSharp.Models.Filters;

/// <summary>
/// Filter used in GET requests
/// </summary>
public class Filter : IFilter
{
    /// <summary>
    /// Filter operation
    /// </summary>
    public FilterOperation Operation { get; }
    /// <summary>
    /// Field to filter on
    /// </summary>
    public string Field { get; }
    /// <summary>
    /// Value to filter on
    /// </summary>
    public string Value { get; }
    /// <summary>
    /// Implicitly convert a filter to a filter list.
    /// </summary>
    /// <param name="filter"></param>
    public static implicit operator FilterList(Filter filter) => new() { filter };
    /// <summary>
    /// Implicitly convert a filter to a string.
    /// </summary>
    /// <param name="filter"></param>
    public static implicit operator string(Filter filter) => filter.ToString();
    /// <summary>
    /// Converts the filter to a string that can be added to a query string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{Operation.ToEnumString()}({Field},{Value})";
    }
    /// <summary>
    /// Create a filter
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="field"></param>
    /// <param name="value"></param>
    public Filter(FilterOperation operation, string field, string value)
    {
        Operation = operation;
        Field = field;
        Value = $"\"{value}\"";
    }
    /// <summary>
    /// Create a filter
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="field"></param>
    /// <param name="value"></param>
    public Filter(FilterOperation operation, string field, bool value)
    {
        Operation = operation;
        Field = field;
        Value = value ? "true" : "false";
    }
    /// <summary>
    /// Create a filter
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="field"></param>
    /// <param name="value"></param>
    public Filter(FilterOperation operation, string field, decimal value)
    {
        Operation = operation;
        Field = field;
        Value = value.ToString();
    }
    /// <summary>
    /// Create a filter
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="field"></param>
    /// <param name="value"></param>
    /// <param name="showTime"></param>
    public Filter(FilterOperation operation, string field, DateTime value)
    {
        Operation = operation;
        Field = field;
        Value = value.ToUniversalTime().ToString( "yyyy-MM-ddTHH:mm:ssZ");
    }
    /// <summary>
    /// Create a filter
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="field"></param>
    /// <param name="value"></param>
    /// <param name="showTime"></param>
    public Filter(FilterOperation operation, string field, KlaviyoDateOnly value)
    {
        Operation = operation;
        Field = field;
        Value = value.ToString("yyyy-MM-dd");
    }
    /// <summary>
    /// Create a filter
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="field"></param>
    /// <param name="value"></param>
    public Filter(FilterOperation operation, string field, List<string> value)
    {
        List<string> list = new();
        Operation = operation;
        Field = field;
        value.ForEach(x => list.Add($"\"{x}\""));
        Value = $"[{string.Join(",", list)}]";
    }
    /// <summary>
    /// Create a filter
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="field"></param>
    /// <param name="value"></param>
    public Filter(FilterOperation operation, string field, List<decimal> value)
    {
        Operation = operation;
        Field = field;
        Value = $"[{string.Join(",", value)}]";
    }
}
