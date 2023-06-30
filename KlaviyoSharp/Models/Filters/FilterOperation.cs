using System.Runtime.Serialization;

namespace KlaviyoSharp.Models.Filters;

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