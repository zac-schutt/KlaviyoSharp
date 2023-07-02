using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class ProfileUnsuppressionRequest : KlaviyoObjectBasic<ProfileUnsuppressionRequestAttributes>
{
    public static new ProfileUnsuppressionRequest Create()
    {
        return new ProfileUnsuppressionRequest() { Type = "profile-unsuppression-bulk-create-job" };
    }
}

public class ProfileUnsuppressionRequestAttributes
{
    [JsonProperty("suppressions")]
    public List<ProfileUnsuppressionRequestSuppressions> Suppressions { get; set; }
}

public class ProfileUnsuppressionRequestSuppressions
{
    [JsonProperty("email")]
    public string Email { get; set; }
}