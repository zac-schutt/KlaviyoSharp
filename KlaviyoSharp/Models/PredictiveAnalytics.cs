using System;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class PredictiveAnalytics
{
    [JsonProperty("historic_clv")]
    public decimal HistoricClv { get; set; }
    [JsonProperty("predicted_clv")]
    public decimal PredictedClv { get; set; }
    [JsonProperty("total_clv")]
    public decimal TotalClv { get; set; }
    [JsonProperty("historic_number_of_orders")]
    public int HistoricNumberOfOrders { get; set; }
    [JsonProperty("predicted_number_of_orders")]
    public decimal PredictedNumberOfOrders { get; set; }
    [JsonProperty("average_days_between_orders")]
    public decimal AverageDaysBetweenOrders { get; set; }
    [JsonProperty("average_order_value")]
    public decimal AverageOrderValue { get; set; }
    [JsonProperty("churn_probability")]
    public decimal ChurnProbability { get; set; }
    [JsonProperty("expected_date_of_next_order")]
    public DateTime? ExpectedDateOfNextOrder { get; set; }

}