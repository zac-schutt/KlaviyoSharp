using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// Properties used in Patching Resources
/// </summary>
public class MetaProperties
{
    /// <summary>
    /// Specify one or more patch operations to apply to existing property data
    /// </summary>
    [JsonProperty("patch_properties")]
    public List<PatchProperties> PatchProperties { get; set; }
}
/// <summary>
/// Specify one or more patch operations to apply to existing property data
/// </summary>
public class PatchProperties
{
    /// <summary>
    /// Append a simple value or values to this property array
    /// </summary>
    public Dictionary<string, string> Append { get; set; }
    /// <summary>
    /// Remove a simple value or values from this property array
    /// </summary>
    public Dictionary<string, string> Unappend { get; set; }
    /// <summary>
    /// Remove a key or keys (and their values) completely from properties
    /// </summary>
    public string unset { get; set; }
}