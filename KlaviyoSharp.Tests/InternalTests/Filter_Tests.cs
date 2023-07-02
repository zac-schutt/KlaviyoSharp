using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Tests;

[Trait("Category", "Filter")]

public class Filter_Tests
{
    [Fact]
    public void Filters()
    {
        Assert.Equal("equals(last_name,\"Smith\")", new Filter(FilterOperation.Equals, "last_name", "Smith").ToString());
        Assert.Equal("less-than(value,25)", new Filter(FilterOperation.LessThan, "value", 25).ToString());
        Assert.Equal("less-or-equal(datetime,2001-01-01T11:00:00Z)", new Filter(FilterOperation.LessOrEqual, "datetime", new DateTime(2001, 1, 1, 11, 0, 0, DateTimeKind.Utc)).ToString());
        Assert.Equal("greater-than(datetime,2022-04-01T11:30:00Z)", new Filter(FilterOperation.GreaterThan, "datetime", new DateTime(2022, 4, 1, 11, 30, 0, DateTimeKind.Utc)).ToString());
        Assert.Equal("greater-than(datetime,2022-04-01)", new Filter(FilterOperation.GreaterThan, "datetime", new DateTime(2022, 4, 1, 1, 2, 3, DateTimeKind.Utc), false).ToString());
        Assert.Equal("greater-or-equal(percentage,33.33)", new Filter(FilterOperation.GreaterOrEqual, "percentage", 33.33m).ToString());
        Assert.Equal("contains(description,\"cooking\")", new Filter(FilterOperation.Contains, "description", "cooking").ToString());
        Assert.Equal("ends-with(description,\"End\")", new Filter(FilterOperation.EndsWith, "description", "End").ToString());
        Assert.Equal("starts-with(description,\"Start\")", new Filter(FilterOperation.StartsWith, "description", "Start").ToString());
        Assert.Equal("any(chapter,[\"Intro\",\"Summary\",\"Conclusion\"])", new Filter(FilterOperation.Any, "chapter", new List<string> { "Intro", "Summary", "Conclusion" }).ToString());
        Assert.Equal("any(amount,[1,2.5,3])", new Filter(FilterOperation.Any, "amount", new List<decimal> { 1, 2.5M, 3 }).ToString());
        Assert.Equal("equals(status,true)", new Filter(FilterOperation.Equals, "status", true).ToString());
        Assert.Equal("equals(status,false)", new Filter(FilterOperation.Equals, "status", false).ToString());
    }

    [Fact]
    public void FilterList()
    {
        Assert.Equal("equals(field1,\"foo\"),equals(field2,\"bar\")", new FilterList
        {
            new Filter(FilterOperation.Equals, "field1", "foo"),
            new Filter(FilterOperation.Equals, "field2", "bar")
        }.ToString());

        Assert.Equal("equals(metric_id,\"UxxK4u\"),greater-or-equal(datetime,2023-02-07),less-than(datetime,2023-02-15)", new FilterList
        {
            new Filter(FilterOperation.Equals, "metric_id", "UxxK4u"),
            new Filter(FilterOperation.GreaterOrEqual, "datetime", new DateTime(2023, 2, 7,0,0,0, DateTimeKind.Utc),false),
            new Filter(FilterOperation.LessThan, "datetime", new DateTime(2023, 2, 15,0,0,0, DateTimeKind.Utc),false)
        }.ToString());
    }

}