using System.Collections.Generic;
using KlaviyoSharp.Models;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class SupressionAttributes : AttributesObject
{
    /// <summary>
    /// One or more suppressions to be created.
    /// </summary>
    [JsonProperty("suppressions")]
    public List<SuppressionEmails> Suppressions { get; set; }
}
