using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Models;

/// <summary>
/// Reporting returned from the API
/// </summary>
public class ReportingRequest : KlaviyoObjectBasic<ReportingRequestAttributes>
{
    /// <summary>
    /// Creates a new instance of the Template class
    /// </summary>
    /// <returns></returns>
    public static new ReportingRequest Create()
    {
        throw new NotImplementedException("Use specific methods for creating bulk jobs.");
    }
    /// <summary>
    /// Creates a new instance with the type set to "campaign-values-report"
    /// </summary>
    /// <returns></returns>
    public static ReportingRequest CreateCampaignValuesReport()
    {
        return new () { Type = "campaign-values-report" };
    }
    /// <summary>
    /// Creates a new instance with the type set to "flow-values-report"
    /// </summary>
    /// <returns></returns>
    public static ReportingRequest CreateFlowValuesReport()
    {
        return new () { Type = "flow-values-report" };
    }
    /// <summary>
    /// Creates a new instance with the type set to "flow-series-report"
    /// </summary>
    /// <returns></returns>
    public static ReportingRequest CreateFlowSeriesReport()
    {
        return new () { Type = "flow-series-report" };
    }

}

/// <summary>
/// Reporting Attributes
/// </summary>
public class ReportingRequestAttributes
{
    /// <summary>
    /// <para>
    ///     List of statistics to query for.
    ///     All rate statistics will be returned in fractional form [0.0, 1.0]
    /// </para>
    /// <para>Defined reporting metric</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>average_order_value</term>
    ///     </item>
    ///     <item>
    ///         <term>bounce_rate</term>
    ///     </item>
    ///     <item>
    ///         <term>bounced</term>
    ///     </item>
    ///     <item>
    ///         <term>bounced_or_failed</term>
    ///     </item>
    ///     <item>
    ///         <term>bounced_or_failed_rate</term>
    ///     </item>
    ///     <item>
    ///         <term>click_rate</term>
    ///     </item>
    ///     <item>
    ///         <term>click_to_open_rate</term>
    ///     </item>
    ///     <item>
    ///         <term>clicks</term>
    ///     </item>
    ///     <item>
    ///         <term>clicks_unique</term>
    ///     </item>
    ///     <item>
    ///         <term>conversion_rate</term>
    ///     </item>
    ///     <item>
    ///         <term>conversion_uniques</term>
    ///     </item>
    ///     <item>
    ///         <term>conversion_value</term>
    ///     </item>
    ///     <item>
    ///         <term>conversions</term>
    ///     </item>
    ///     <item>
    ///         <term>delivered</term>
    ///     </item>
    ///     <item>
    ///         <term>delivery_rate</term>
    ///     </item>
    ///     <item>
    ///         <term>failed</term>
    ///     </item>
    ///     <item>
    ///         <term>failed_rate</term>
    ///     </item>
    ///     <item>
    ///         <term>open_rate</term>
    ///     </item>
    ///     <item>
    ///         <term>opens</term>
    ///     </item>
    ///     <item>
    ///         <term>opens_unique</term>
    ///     </item>
    ///     <item>
    ///         <term>recipients</term>
    ///     </item>
    ///     <item>
    ///         <term>revenue_per_recipient</term>
    ///     </item>
    ///     <item>
    ///         <term>spam_complaint_rate</term>
    ///     </item>
    ///     <item>
    ///         <term>spam_complaints</term>
    ///     </item>
    ///     <item>
    ///         <term>unsubscribe_rate</term>
    ///     </item>
    ///     <item>
    ///         <term>unsubscribe_uniques</term>
    ///     </item>
    ///     <item>
    ///         <term>unsubscribes</term>
    ///     </item>
    /// </list>
    /// </summary>
    public string[] Statistics { get; set; }
    /// <summary>
    /// The timeframe to query for data within. The max length a timeframe can be is 1 year
    /// </summary>
    public ReportingRequestTimeframe Timeframe { get; set; }
    /// <summary>
    /// The interval used to aggregate data within the series request.
    /// If hourly is used, the timeframe cannot be longer than 7 days.
    /// If daily is used, the timeframe cannot be longer than 60 days.
    /// If monthly is used, the timeframe cannot be longer than 52 weeks.
    /// <list type="bullet">
    ///     <item>
    ///         <term>daily</term>
    ///     </item>
    ///     <item>
    ///         <term>hourly</term>
    ///     </item>
    ///     <item>
    ///         <term>weekly</term>
    ///     </item>
    ///     <item>
    ///         <term>monthly</term>
    ///     </item>
    /// </list>
    /// </summary>
    public string? Interval { get; set; }
    /// <summary>
    /// ID of the metric to be used for conversion statistics
    /// </summary>
    public string ConversionMetricId { get; set; }
    /// <summary>
    /// API filter string used to filter the query.
    /// Allowed filters are send_channel, campaign_id.
    /// Allowed operators are equals, contains-any.
    /// Only one filter can be used per attribute, only AND can be used as a combination operator.
    /// Max of 100 messages per ANY filter.
    /// </summary>
    public IFilter? Filter { get; set; } = null;
}

/// <summary>
/// Reporting Timeframe
/// </summary>
public class ReportingRequestTimeframe
{
    /// <summary>
    /// <para>Possible values</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>last_year</term>
    ///         <description>Last year.</description>
    ///     </item>
    ///     <item>
    ///         <term>last_12_months</term>
    ///         <description>Last 12 months.</description>
    ///     </item>
    ///     <item>
    ///         <term>last_365_days</term>
    ///         <description>Last 365 days.</description>
    ///     </item>
    ///     <item>
    ///         <term>last_3_months</term>
    ///         <description>Last 3 months.</description>
    ///     </item>
    ///     <item>
    ///         <term>last_90_days</term>
    ///         <description>Last 90 days.</description>
    ///     </item>
    ///     <item>
    ///         <term>last_month</term>
    ///         <description>Last month.</description>
    ///     </item>
    ///     <item>
    ///         <term>last_30_days</term>
    ///         <description>Last 30 days.</description>
    ///     </item>
    ///     <item>
    ///         <term>last_week</term>
    ///         <description>Last week.</description>
    ///     </item>
    ///     <item>
    ///         <term>last_7_days</term>
    ///         <description>Last 7 days.</description>
    ///     </item>
    ///     <item>
    ///         <term>this_month</term>
    ///         <description>This month.</description>
    ///     </item>
    ///     <item>
    ///         <term>this_week</term>
    ///         <description>This week.</description>
    ///     </item>
    ///     <item>
    ///         <term>this_year</term>
    ///         <description>This year.</description>
    ///     </item>
    ///     <item>
    ///         <term>yesterday</term>
    ///         <description>Yesterday.</description>
    ///     </item>
    ///     <item>
    ///         <term>today</term>
    ///         <description>Today.</description>
    ///     </item>
    /// </list>
    /// </summary>
    public string? Key { get; set; } = null;
    /// <summary>
    /// Date and time where timeframe shall start, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS)
    /// </summary>
    public DateTime? Start { get; set; } = null;
    /// <summary>
    /// Date and time where timeframe shall end, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS)
    /// </summary>
    public DateTime? End { get; set; } = null;
}
