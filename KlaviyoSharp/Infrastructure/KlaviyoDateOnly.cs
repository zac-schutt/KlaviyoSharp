using System;
namespace KlaviyoSharp.Infrastructure;
/// <summary>
/// A Date Only struct that can be used in place of DateTime when only the Date is to be represented.
/// </summary>
public readonly struct KlaviyoDateOnly
{
    private DateTime Value { get; }
    /// <summary>
    /// Converts a string to a Date Only. Uses the same format as DateTime.Parse
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static KlaviyoDateOnly Parse(string value) => new(DateTime.Parse(value));
    /// <summary>
    /// Creates a new DateOnly with the DateTime.MinValue value
    /// </summary>
    public KlaviyoDateOnly() : this(DateTime.MinValue) { }
    /// <summary>
    /// Creates a new DateOnly with the given year, month, and day
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    public KlaviyoDateOnly(int year, int month, int day) : this(new DateTime(year, month, day)) { }
    /// <summary>
    /// Creates a new DateOnly with the given DateTime value
    /// </summary>
    /// <param name="value"></param>
    public KlaviyoDateOnly(DateTime value) => Value = value.Date;
    /// <summary>
    /// Converts a DateOnly to a string in the format yyyy-MM-dd
    /// </summary>
    /// <returns></returns>
    public override string ToString() => ToString("yyyy-MM-dd");
    /// <summary>
    /// Converts a DateOnly to a string in the given format
    /// </summary>
    /// <param name="format"></param>
    /// <returns></returns>
    public string ToString(string format) => Value.ToString(format);

    //Operator for platforms that have access to Native DateOnly functionality
#if NET6_0
    public static implicit operator KlaviyoDateOnly(DateOnly value) => new(value.Year, value.Month, value.Day);
    public static implicit operator DateOnly(KlaviyoDateOnly value) => new(value.Value.Year, value.Value.Month, value.Value.Day);
#endif
}