using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class ClientSubscriptionRequestAttributes : AttributesObject
{
    [JsonProperty("list_id")]
    public string ListId { get; set; }
    [JsonProperty("custom_source")]
    public string CustomSource { get; set; }
    [JsonProperty("email")]
    public string Email { get; set; }
    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }
}