using System.Collections.Generic;

namespace KlaviyoSharp.Models;

public abstract class AttributesObject
{
    /// <summary>
    /// An object containing key/value pairs for any custom properties assigned to this object
    /// </summary>
    public Dictionary<string, string> properties { get; set; }
}