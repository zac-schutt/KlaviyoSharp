using System;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class ProfileAttributes : AttributesObject
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
    [JsonProperty("location")]
    public Location Location { get; set; }
    [JsonProperty("subscriptions")]
    public ProfileSubscriptions Subscriptions { get; set; }
    [JsonProperty("predictive_analytics")]
    public PredictiveAnalytics PredictiveAnalytics { get; set; }
}
