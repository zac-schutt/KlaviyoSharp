using System.Collections.Generic;

namespace KlaviyoSharp.Models.Filters;

public class FilterList : List<Filter>, IFilter
{
    public override string ToString()
    {
        return string.Join(",", this);
    }
}
