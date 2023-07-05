namespace KlaviyoSharp.Models.Filters;

/// <summary>
/// Interface for filters used in GET requests
/// </summary>
public interface IFilter
{
    /// <summary>
    /// Converts the filter to a string that can be added to a query string
    /// </summary>
    /// <returns></returns>
    public string ToString();
}