using System.Collections.Generic;

namespace KlaviyoSharp.Models.Filters;

/// <summary>
/// List of filters used in GET requests. Requests are combined with an AND operation.
/// </summary>
public class FilterList : List<Filter>, IFilter
{
    /// <summary>
    /// Converts the filter to a string that can be added to a query string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return string.Join(",", this);
    }
}
