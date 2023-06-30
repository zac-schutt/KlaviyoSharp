using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KlaviyoSharp.Models.Filters;

public class Filter
{
    public FilterOperation Operation { get; }
    public string Field { get; }
    public string Value { get; }
    public static implicit operator FilterList(Filter filter) => new() { filter };
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

    public Filter(FilterOperation operation, string field, DateTime value)
    {
        Operation = operation;
        Field = field;
        Value = value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
    }
    public Filter(FilterOperation operation, string field, DateOnly value)
    {
        Operation = operation;
        Field = field;
        Value = value.ToString("yyyy-MM-dd");
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
public class FilterList : List<Filter>
{
    public override string ToString()
    {
        return string.Join(",", this);
    }
}
public enum FilterOperation
{
    [EnumMember(Value = "equals")]
    Equals,
    [EnumMember(Value = "less-than")]
    LessThan,
    [EnumMember(Value = "less-or-equal")]
    LessOrEqual,
    [EnumMember(Value = "greater-than")]
    GreaterThan,
    [EnumMember(Value = "greater-or-equal")]
    GreaterOrEqual,
    [EnumMember(Value = "contains")]
    Contains,
    [EnumMember(Value = "ends-with")]
    EndsWith,
    [EnumMember(Value = "starts-with")]
    StartsWith,
    [EnumMember(Value = "any")]
    Any
}