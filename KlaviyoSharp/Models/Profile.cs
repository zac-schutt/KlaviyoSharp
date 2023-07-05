using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// Profiles returned from the Klaviyo API
/// </summary>
public class Profile : KlaviyoObject<ProfileAttributes>
{
    /// <summary>
    /// Creates a new instance of the Profile class
    /// </summary>
    /// <returns></returns>
    public static new Profile Create()
    {
        return new Profile() { Type = "profile" };
    }
    /// <summary>
    /// Related objects for the Profile
    /// </summary>
    [JsonProperty("relationships")]
    public ProfileRelationships Relationships { get; set; }
}
/// <summary>
/// Profile Relationships
/// </summary>
public class ProfileRelationships
{
    /// <summary>
    /// Lists associated with the Profile
    /// </summary>
    [JsonProperty("lists")]
    public DataListObjectRelated<GenericObject> Lists { get; set; }
    /// <summary>
    /// Segments associated with the Profile
    /// </summary>
    [JsonProperty("segments")]
    public DataListObjectRelated<GenericObject> Segments { get; set; }
}
/// <summary>
/// Profile Attributes
/// </summary>
public class ProfileAttributes
{
    /// <summary>
    /// Individual's email address
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; }
    /// <summary>
    /// Individual's email address
    /// </summary>
    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }
    /// <summary>
    /// A unique identifier used by customers to associate Klaviyo profiles with profiles in an external system, such as a point-of-sale system. Format varies based on the external system.
    /// </summary>
    [JsonProperty("external_id")]
    public string ExternalId { get; set; }
    /// <summary>
    /// Individual's first name
    /// </summary>
    [JsonProperty("first_name")]
    public string FirstName { get; set; }
    /// <summary>
    /// Individual's last name
    /// </summary>
    [JsonProperty("last_name")]
    public string LastName { get; set; }
    /// <summary>
    /// Name of the company or organization within the company for whom the individual works
    /// </summary>
    [JsonProperty("organization")]
    public string Organization { get; set; }
    /// <summary>
    /// Individual's job title
    /// </summary>
    [JsonProperty("title")]
    public string Title { get; set; }
    /// <summary>
    /// URL pointing to the location of a profile image
    /// </summary>
    [JsonProperty("image")]
    public string ImageUrl { get; set; }
    /// <summary>
    /// Date and time when the profile was created, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm)
    /// </summary>
    [JsonProperty("created")]
    public DateTime? Created { get; set; }
    /// <summary>
    /// Date and time when the profile was last updated, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm)
    /// </summary>
    [JsonProperty("updated")]
    public DateTime? Updated { get; set; }
    /// <summary>
    /// Date and time of the most recent event the triggered an update to the profile, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm)
    /// </summary>
    [JsonProperty("last_event_date")]
    public DateTime? LastEvent { get; set; }
    /// <summary>
    /// Location information for the profile
    /// </summary>
    [JsonProperty("location")]
    public ProfileLocation Location { get; set; }
    /// <summary>
    /// Subscriptions for the profile
    /// </summary>
    [JsonProperty("subscriptions")]
    public ProfileSubscriptions Subscriptions { get; set; }
    /// <summary>
    /// Analytics for the profile
    /// </summary>
    [JsonProperty("predictive_analytics")]
    public ProfilePredictiveAnalytics PredictiveAnalytics { get; set; }
}
/// <summary>
/// Location information for the profile
/// </summary>
public class ProfileLocation
{
    /// <summary>
    /// First line of street address
    /// </summary>
    [JsonProperty("address1")]
    public string Address1 { get; set; }
    /// <summary>
    /// First line of street address
    /// </summary>
    [JsonProperty("address2")]
    public string Address2 { get; set; }
    /// <summary>
    /// City name
    /// </summary>
    [JsonProperty("city")]
    public string City { get; set; }
    /// <summary>
    /// Country name
    /// </summary>
    [JsonProperty("country")]
    public string Country { get; set; }
    /// <summary>
    /// Latitude coordinate. We recommend providing a precision of four decimal places.
    /// </summary>
    [JsonProperty("latitude")]
    public double? Latitude { get; set; }
    /// <summary>
    /// Longitude coordinate. We recommend providing a precision of four decimal places.
    /// </summary>
    [JsonProperty("longitude")]
    public double? Longitude { get; set; }
    /// <summary>
    /// Region within a country, such as state or province
    /// </summary>
    [JsonProperty("region")]
    public string Region { get; set; }
    /// <summary>
    /// Zip code
    /// </summary>
    [JsonProperty("zip")]
    public string Zip { get; set; }
    /// <summary>
    /// Time zone name. We recommend using time zones from the IANA Time Zone Database.
    /// </summary>
    [JsonProperty("timezone")]
    public string Timezone { get; set; }
}
/// <summary>
/// Subscriptions associated with a profile
/// </summary>
public class ProfileSubscriptions
{
    /// <summary>
    /// The email channel subscription.
    /// </summary>
    [JsonProperty("email")]
    public ProfileEmailSubscription Email { get; set; }
    /// <summary>
    /// The SMS channel subscription.
    /// </summary>
    [JsonProperty("sms")]
    public ProfileSmsSubscription Sms { get; set; }
}
/// <summary>
/// Email Subscriptions associated with a profile
/// </summary>
public class ProfileEmailSubscription
{
    /// <summary>
    /// The email marketing subscription.
    /// </summary>
    [JsonProperty("marketing")]
    public ProfileEmailSubscriptionMarketing Marketing { get; set; }
}
/// <summary>
/// Email Subscriptions associated with a profile
/// </summary>
public class ProfileEmailSubscriptionMarketing
{
    /// <summary>
    /// The consent status for marketing.
    /// </summary>
    [JsonProperty("consent")]
    public string Consent { get; set; }
    /// <summary>
    /// The timestamp when consent record or updated for marketing, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm).
    /// </summary>
    [JsonProperty("timestamp")]
    public DateTime? Timestamp { get; set; }
    /// <summary>
    /// The method by which the profile was subscribed to marketing.
    /// </summary>
    [JsonProperty("method")]
    public string Method { get; set; }
    /// <summary>
    /// Additional details about the method by which the profile was subscribed to marketing. This may be empty if no details were provided.
    /// </summary>
    [JsonProperty("method_detail")]
    public string MethodDetail { get; set; }
    /// <summary>
    /// Additional detail provided by the caller when the profile was subscribed. This may be empty if no details were provided.
    /// </summary>
    [JsonProperty("custom_method_detail")]
    public string CustomMethodDetail { get; set; }
    /// <summary>
    /// Whether the profile was subscribed to email marketing using a double opt-in.
    /// </summary>
    [JsonProperty("double_optin")]
    public bool? DoubleOptIn { get; set; }
    /// <summary>
    /// The global email marketing suppressions for this profile.
    /// </summary>
    [JsonProperty("suppressions")]
    public List<ProfileEmailSubscriptionMarketingEmailSupression> Suppressions { get; set; }
    /// <summary>
    /// The list suppressions for this profile.
    /// </summary>
    [JsonProperty("list_suppressions")]
    public List<ProfileEmailSubscriptionMarketingListSupression> ListSuppressions { get; set; }
}
/// <summary>
/// Email Subscriptions associated with a profile
/// </summary>
public class ProfileEmailSubscriptionMarketingListSupression
{
    /// <summary>
    /// The ID of list to which the suppression applies.
    /// </summary>
    [JsonProperty("list_id")]
    public string ListId { get; set; }
    /// <summary>
    /// The reason the profile was suppressed from the list.
    /// </summary>
    [JsonProperty("reason")]
    public string Reason { get; set; }
    /// <summary>
    /// The timestamp when the profile was suppressed from the list, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm).
    /// </summary>
    [JsonProperty("timestamp")]
    public DateTime? Timestamp { get; set; }
}
/// <summary>
/// Email Subscriptions associated with a profile
/// </summary>
public class ProfileEmailSubscriptionMarketingEmailSupression
{
    /// <summary>
    /// The reason the profile was suppressed from the list.
    /// </summary>
    [JsonProperty("reason")]
    public string Reason { get; set; }
    /// <summary>
    /// The timestamp when the profile was suppressed from the list, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm).
    /// </summary>
    [JsonProperty("timestamp")]
    public DateTime? Timestamp { get; set; }
}
/// <summary>
/// SMS Subscriptions associated with a profile
/// </summary>
public class ProfileSmsSubscription
{
    /// <summary>
    /// The SMS marketing subscription.
    /// </summary>
    [JsonProperty("marketing")]
    public ProfileSmsSubscriptionMarketing Marketing { get; set; }
}
/// <summary>
/// SMS Subscriptions associated with a profile
/// </summary>
public class ProfileSmsSubscriptionMarketing
{
    /// <summary>
    /// The consent status for marketing.
    /// </summary>
    [JsonProperty("consent")]
    public string Consent { get; set; }
    /// <summary>
    /// The timestamp when consent record or updated for marketing, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm).
    /// </summary>
    [JsonProperty("timestamp")]
    public DateTime? Timestamp { get; set; }
    /// <summary>
    /// The method by which the profile was subscribed to marketing.
    /// </summary>
    [JsonProperty("method")]
    public string Method { get; set; }
    /// <summary>
    /// Additional details about the method by which the profile was subscribed to marketing. This may be empty if no details were provided.
    /// </summary>
    [JsonProperty("method_detail")]
    public string MethodDetail { get; set; }
}
/// <summary>
/// A profile's predictive analytics
/// </summary>
public class ProfilePredictiveAnalytics
{
    /// <summary>
    /// Total value of all historically placed orders
    /// </summary>
    [JsonProperty("historic_clv")]
    public decimal HistoricClv { get; set; }
    /// <summary>
    /// Predicted value of all placed orders in the next 365 days
    /// </summary>
    [JsonProperty("predicted_clv")]
    public decimal PredictedClv { get; set; }
    /// <summary>
    /// Sum of historic and predicted CLV
    /// </summary>
    [JsonProperty("total_clv")]
    public decimal TotalClv { get; set; }
    /// <summary>
    /// Sum of historic and predicted CLV
    /// </summary>
    [JsonProperty("historic_number_of_orders")]
    public int HistoricNumberOfOrders { get; set; }
    /// <summary>
    /// Predicted number of placed orders in the next 365 days
    /// </summary>
    [JsonProperty("predicted_number_of_orders")]
    public decimal PredictedNumberOfOrders { get; set; }
    /// <summary>
    /// Average number of days between orders (None if only one order has been placed)
    /// </summary>
    [JsonProperty("average_days_between_orders")]
    public decimal AverageDaysBetweenOrders { get; set; }
    /// <summary>
    /// Average value of placed orders
    /// </summary>
    [JsonProperty("average_order_value")]
    public decimal AverageOrderValue { get; set; }
    /// <summary>
    /// Probability the customer has churned
    /// </summary>
    [JsonProperty("churn_probability")]
    public decimal ChurnProbability { get; set; }
    /// <summary>
    /// Expected date of next order, as calculated at the time of their most recent order
    /// </summary>
    [JsonProperty("expected_date_of_next_order")]
    public DateTime? ExpectedDateOfNextOrder { get; set; }
}