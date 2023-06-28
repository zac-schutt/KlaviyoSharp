namespace KlaviyoSharp.Models;

public class ClientSubscriptionRequestAttributes : AttributesObject
{
    public string list_id { get; set; }
    public string custom_source { get; set; }
    public string email { get; set; }
    public string phone_number { get; set; }
}