namespace KlaviyoSharp.Models;

/// <summary>
/// Profiles returned from the Klaviyo API
/// </summary>
public class Profile : KlaviyoObject<ProfileAttributes, ProfileRelationships>
{
    /// <summary>
    /// Creates a new instance of the Profile class
    /// </summary>
    /// <returns></returns>
    public static new Profile Create() => new() { Type = "profile" };
}

/// <summary>
/// Klaviyo profile with meta properties for patcching
/// </summary>
public class PatchProfile : Profile
{
    /// <summary>
    /// Generic Constructor
    /// </summary>
    public PatchProfile() { }
    /// <summary>
    /// Constructor for PatchProfile from existing Profile
    /// </summary>
    /// <param name="profile"></param>
    public PatchProfile(Profile profile)
    {
        Id = profile.Id;
        Type = profile.Type;
        Attributes = profile.Attributes;
        Relationships = profile.Relationships;
        Links = profile.Links;
    }
    /// <summary>
    /// Creates a new instance of the Klaviyo Profile with default values
    /// </summary>
    /// <returns></returns>
    public static new PatchProfile Create() => new() { Type = "profile" };
    /// <summary>
    /// Meta properties for patching
    /// </summary>
    public MetaProperties Meta { get; set; }
}

/// <summary>
/// Profile Relationships
/// </summary>
public class ProfileRelationships
{
    /// <summary>
    /// Lists associated with the Profile
    /// </summary>
    public DataListObjectRelated<GenericObject> Lists { get; set; }
    /// <summary>
    /// Segments associated with the Profile
    /// </summary>
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
    public string Email { get; set; }
    /// <summary>
    /// Individual's email address
    /// </summary>
    public string PhoneNumber { get; set; }
    /// <summary>
    /// A unique identifier used by customers to associate Klaviyo profiles with profiles in an external system, such as a point-of-sale system. Format varies based on the external system.
    /// </summary>
    public string ExternalId { get; set; }
    /// <summary>
    /// Individual's first name
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// Individual's last name
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// Name of the company or organization within the company for whom the individual works
    /// </summary>
    public string Organization { get; set; }
    /// <summary>
    /// Individual's job title
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// URL pointing to the location of a profile image
    /// </summary>
    public string ImageUrl { get; set; }
    /// <summary>
    /// Date and time when the profile was created, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm)
    /// </summary>
    public DateTime? Created { get; set; }
    /// <summary>
    /// Date and time when the profile was last updated, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm)
    /// </summary>
    public DateTime? Updated { get; set; }
    /// <summary>
    /// Date and time of the most recent event the triggered an update to the profile, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm)
    /// </summary>
    public DateTime? LastEvent { get; set; }
    /// <summary>
    /// Location information for the profile
    /// </summary>
    public ProfileLocation Location { get; set; }
    /// <summary>
    /// Subscriptions for the profile
    /// </summary>
    public ProfileSubscriptions Subscriptions { get; set; }
    /// <summary>
    /// Analytics for the profile
    /// </summary>
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
    public string Address1 { get; set; }
    /// <summary>
    /// First line of street address
    /// </summary>
    public string Address2 { get; set; }
    /// <summary>
    /// City name
    /// </summary>
    public string City { get; set; }
    /// <summary>
    /// Country name
    /// </summary>
    public string Country { get; set; }
    /// <summary>
    /// Latitude coordinate. We recommend providing a precision of four decimal places.
    /// </summary>
    public double? Latitude { get; set; }
    /// <summary>
    /// Longitude coordinate. We recommend providing a precision of four decimal places.
    /// </summary>
    public double? Longitude { get; set; }
    /// <summary>
    /// Region within a country, such as state or province
    /// </summary>
    public string Region { get; set; }
    /// <summary>
    /// Zip code
    /// </summary>
    public string Zip { get; set; }
    /// <summary>
    /// Time zone name. We recommend using time zones from the IANA Time Zone Database.
    /// </summary>
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
    public ProfileEmailSubscription Email { get; set; }
    /// <summary>
    /// The SMS channel subscription.
    /// </summary>
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
    public string Consent { get; set; }
    /// <summary>
    /// The timestamp when consent record or updated for marketing, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm).
    /// </summary>
    public DateTime? Timestamp { get; set; }
    /// <summary>
    /// The method by which the profile was subscribed to marketing.
    /// </summary>
    public string Method { get; set; }
    /// <summary>
    /// Additional details about the method by which the profile was subscribed to marketing. This may be empty if no
    /// details were provided.
    /// </summary>
    public string MethodDetail { get; set; }
    /// <summary>
    /// Additional detail provided by the caller when the profile was subscribed. This may be empty if no details were
    /// provided.
    /// </summary>
    public string CustomMethodDetail { get; set; }
    /// <summary>
    /// Whether the profile was subscribed to email marketing using a double opt-in.
    /// </summary>
    public bool? DoubleOptIn { get; set; }
    /// <summary>
    /// The global email marketing suppressions for this profile.
    /// </summary>
    public List<ProfileEmailSubscriptionMarketingEmailSupression> Suppressions { get; set; }
    /// <summary>
    /// The list suppressions for this profile.
    /// </summary>
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
    public string ListId { get; set; }
    /// <summary>
    /// The reason the profile was suppressed from the list.
    /// </summary>
    public string Reason { get; set; }
    /// <summary>
    /// The timestamp when the profile was suppressed from the list, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm).
    /// </summary>
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
    public string Reason { get; set; }
    /// <summary>
    /// The timestamp when the profile was suppressed from the list, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm).
    /// </summary>
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
    public string Consent { get; set; }
    /// <summary>
    /// The timestamp when consent record or updated for marketing, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm).
    /// </summary>
    public DateTime? Timestamp { get; set; }
    /// <summary>
    /// The method by which the profile was subscribed to marketing.
    /// </summary>
    public string Method { get; set; }
    /// <summary>
    /// Additional details about the method by which the profile was subscribed to marketing. This may be empty if no details were provided.
    /// </summary>
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
    public decimal HistoricClv { get; set; }
    /// <summary>
    /// Predicted value of all placed orders in the next 365 days
    /// </summary>
    public decimal PredictedClv { get; set; }
    /// <summary>
    /// Sum of historic and predicted CLV
    /// </summary>
    public decimal TotalClv { get; set; }
    /// <summary>
    /// Sum of historic and predicted CLV
    /// </summary>
    public int HistoricNumberOfOrders { get; set; }
    /// <summary>
    /// Predicted number of placed orders in the next 365 days
    /// </summary>
    public decimal PredictedNumberOfOrders { get; set; }
    /// <summary>
    /// Average number of days between orders (None if only one order has been placed)
    /// </summary>
    public decimal AverageDaysBetweenOrders { get; set; }
    /// <summary>
    /// Average value of placed orders
    /// </summary>
    public decimal AverageOrderValue { get; set; }
    /// <summary>
    /// Probability the customer has churned
    /// </summary>
    public decimal ChurnProbability { get; set; }
    /// <summary>
    /// Expected date of next order, as calculated at the time of their most recent order
    /// </summary>
    public DateTime? ExpectedDateOfNextOrder { get; set; }
}