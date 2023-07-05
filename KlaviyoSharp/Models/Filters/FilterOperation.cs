using System.Runtime.Serialization;

namespace KlaviyoSharp.Models.Filters;

/// <summary>
/// Enum for filter operations
/// </summary>
public enum FilterOperation
{
    /// <summary>
    /// equals
    /// </summary>
    [EnumMember(Value = "equals")]
    Equals,
    /// <summary>
    /// less-than
    /// </summary>
    [EnumMember(Value = "less-than")]
    LessThan,
    /// <summary>
    /// less-or-equal
    /// </summary>
    [EnumMember(Value = "less-or-equal")]
    LessOrEqual,
    /// <summary>
    /// greater-than
    /// </summary>
    [EnumMember(Value = "greater-than")]
    GreaterThan,
    /// <summary>
    /// greater-or-equal
    /// </summary>
    [EnumMember(Value = "greater-or-equal")]
    GreaterOrEqual,
    /// <summary>
    /// contains
    /// </summary>
    [EnumMember(Value = "contains")]
    Contains,
    /// <summary>
    /// ends-with
    /// </summary>
    [EnumMember(Value = "ends-with")]
    EndsWith,
    /// <summary>
    /// starts-with
    /// </summary>
    [EnumMember(Value = "starts-with")]
    StartsWith,
    /// <summary>
    /// any
    /// </summary>
    [EnumMember(Value = "any")]
    Any
}