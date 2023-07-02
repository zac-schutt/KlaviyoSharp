using System;
using System.Collections.Generic;

namespace KlaviyoSharp.Models.Filters;

public class Filter : IFilter
{
    public FilterOperation Operation { get; }
    public string Field { get; }
    public string Value { get; }
    public static implicit operator FilterList(Filter filter) => new() { filter };
    public static implicit operator string(Filter filter) => filter.ToString();
    public override string ToString()
    {
        return $"{Operation.ToEnumString()}({Field},{Value})";
    }

    public Filter(FilterOperation operation, string field, string value)
    {
        Operation = operation;
        Field = field;
        Value = $"\"{value}\"";
    }
    public Filter(FilterOperation operation, string field, bool value)
    {
        Operation = operation;
        Field = field;
        Value = value ? "true" : "false";
    }

    public Filter(FilterOperation operation, string field, decimal value)
    {
        Operation = operation;
        Field = field;
        Value = value.ToString();
    }

    public Filter(FilterOperation operation, string field, DateTime value, bool showTime = true)
    {
        Operation = operation;
        Field = field;
        Value = value.ToUniversalTime().ToString(showTime ? "yyyy-MM-ddTHH:mm:ssZ" : "yyyy-MM-dd");
    }
    public Filter(FilterOperation operation, string field, List<string> value)
    {
        List<string> list = new();
        Operation = operation;
        Field = field;
        value.ForEach(x => list.Add($"\"{x}\""));
        Value = $"[{string.Join(",", list)}]";
    }
    public Filter(FilterOperation operation, string field, List<decimal> value)
    {
        Operation = operation;
        Field = field;
        Value = $"[{string.Join(",", value)}]";
    }
}
