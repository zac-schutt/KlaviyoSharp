namespace KlaviyoSharp.Models;

/// <summary>
/// Reporting returned from the API
/// </summary>
public class Reporting : KlaviyoObject<ReportingAttributes, ReportingRelationships>
{
    /// <summary>
    /// Creates a new instance of the Template class
    /// </summary>
    /// <returns></returns>
    public static new Reporting Create()
    {
        //return new Reporting() { Type = "image" };
        return new Reporting() { Type = "image" };
    }
}

/// <summary>
/// Reporting Relationships
/// </summary>
public class ReportingRelationships
{
    /// <summary>
    /// Lists associated with the Report
    /// </summary>
    public DataListObjectRelated<GenericObject> Campaigns { get; set; }
}

/// <summary>
/// Reporting Attributes
/// </summary>
public class ReportingAttributes
{
    /// <summary>
    /// An array of all the returned values data.
    /// Each object in the array represents one unique grouping and the results for that grouping.
    /// </summary>
    public List<ReportingValueData?> Results { get; set; }
}

/// <summary>
/// Reporting Timeframe
/// </summary>
public class ReportingValueData
{
    /// <summary>
    /// Applied groupings and the values for this object
    /// </summary>
    public Dictionary<string, string> Groupings { get; set; }
    /// <summary>
    /// Requested statistics and their values results
    /// </summary>
    public Dictionary<string, double> Statistics { get; set; }
}