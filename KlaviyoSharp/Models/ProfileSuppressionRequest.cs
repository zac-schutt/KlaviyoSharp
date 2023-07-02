using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class ProfileSuppressionRequest : KlaviyoObjectBasic<ProfileSuppressionRequestAttributes>
{
    public static new ProfileSuppressionRequest Create()
    {
        return new ProfileSuppressionRequest() { Type = "profile-suppression-bulk-create-job" };
    }
}

public class ProfileSuppressionRequestAttributes
{
    [JsonProperty("suppressions")]
    public List<ProfileSuppressionRequestSuppressions> Suppressions { get; set; }
}

public class ProfileSuppressionRequestSuppressions
{
    [JsonProperty("email")]
    public string Email { get; set; }
}