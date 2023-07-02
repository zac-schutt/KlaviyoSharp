using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class ClientEvent : KlaviyoObjectBasic<ClientEventAttributes>
{
    public new static ClientEvent Create()
    {
        return new() { Type = "event" };
    }
}

public class ClientEventAttributes
{
    /// <summary>
    /// Properties of the profile that triggered this event. The profile must contain an identifier. The $email and/or $phone_number can be used as the identify the profile.
    /// Other key value pairs can be used to create segments. For example, to create a list of people on trial plans, include a profile's plan type in the profile. The profile supports special fields. The fields include: $email (string), $first_name (string), $last_name (string), $phone_number (string), $city (string), $region (string; state or other region), $country (string), $zip (string), $image (string; url to a photo of a person), and $consent (list of strings; eg: ['sms', 'email', 'web', 'directmail', 'mobile']).
    /// </summary>
    [JsonProperty("profile")]
    public ClientEventProfile Profile { get; set; }
    /// <summary>
    /// The associated metric for the event. An account can have up to 200 unique metrics.
    /// </summary>
    [JsonProperty("metric")]
    public ClientEventMetric Metric { get; set; }
    /// <summary>
    /// When this event occurred. By default, the time the request was received will be used. The time is truncated to the second. The time must be after the year 2000 and can only be up to 1 year in the future.
    /// </summary>
    [JsonProperty("time")]
    public DateTime? Time { get; set; }
    /// <summary>
    /// A numeric value to associate with this event. For example, the dollar amount of a purchase.
    /// </summary>
    [JsonProperty("value")]
    public double? Value { get; set; }
    /// <summary>
    /// A unique identifier for an event. If the unique_id is repeated for the same profile and metric, only the first processed event will be recorded. If this is not present, this will use the time to the second. Using the default, this limits only one event per profile per second.
    /// </summary>
    [JsonProperty("unique_id")]
    public string UniqueId { get; set; }
    /// <summary>
    /// Properties of this event. Any top level property (that are not objects) can be used to create segments. The $extra property is a special property. This records any non-segmentable values that can be references later. For example, HTML templates are useful on a segment, but itself is not used in creating a segment. There are limits placed onto the size of the data present. This must not exceed 5 MB. This must not exceed 300 event properties. A single string cannot be larger than 100 KB. Each array must not exceed 4000 elements. The properties cannot contain more than 10 nested levels.
    /// </summary>
    [JsonProperty("properties")]
    public GenericProperties Properties { get; set; }

}

public class ClientEventProfile : Dictionary<string, string> { }

public class ClientEventMetric
{
    /// <summary>
    /// Name of the event. Must be less than 128 characters.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// This is for advanced usage. For api requests, this should use the default, which is set to api.
    /// </summary>
    [JsonProperty("service")]
    public string Service { get; set; }
}
